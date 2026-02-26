using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Monster;

public class Enemy_GameObject : Creature
{
    [Header("====== Configuração do Enemy ======")]
    public Monster.MonsterType monsterType;
    public bool isSiege;

    // Configuração do inimigo.
    [HideInInspector] public Monster monster;
    [HideInInspector] public float originalSpeed => SetMonsterSpeed();
    [HideInInspector] public bool droppedLoot;

    // Ajuste de Drop.
    [HideInInspector] public int _dropExpOrbChance;
    [HideInInspector] public int _dropRelicChance;

    // Componentes.
    [HideInInspector] public EnemyConditions conditions;
    [HideInInspector] public EnemyAnimations animations;
    [HideInInspector] public GameObject _jogadorGameObject;
    [HideInInspector] public Rigidbody2D _enemyRigidbody;
    [HideInInspector] public SpriteRenderer _enemySpriteRenderer;
    [HideInInspector] public CapsuleCollider2D _capsuleCollider;

    [HideInInspector] public Vector2 direcao;

    // flags
    private bool monsterStarted = false;

    protected virtual void Update()
    {
        if (_jogadorGameObject == null || isDead)
            return;

        // Realiza o comportamento do inimigo.
        EnemyBehaviour();
        conditions.ApplyConditions();

        // Animações
        animations.AtualizarCorSprite();
        animations.AtualizarSpriteFlip();
        
    }

    // ===================================================================
    // ========================= INICIA VALORES ==========================
    // ===================================================================
    public void SetupEnemy(int nivel)
    {        
        _jogadorGameObject = GameObject.FindWithTag("Player");

        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
        if (_enemySpriteRenderer == null)
            _enemySpriteRenderer = GetComponentsInChildren<SpriteRenderer>(true)
    .FirstOrDefault(s => s.gameObject.name == "sprite enemy");

        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>(); 
        conditions = new EnemyConditions(this);
        animations = new EnemyAnimations(this);

        // Cria o monster.
        Monster baseMonster = MonsterList.AllMonsters.FirstOrDefault(m => m.monsterType == monsterType);
        if (baseMonster != null)
            monster = new Monster(baseMonster, nivel);

        monsterStarted = true;
    }

    // ===================================================================
    // ==================== COMPORTAMENTO DO INIMIGO =====================
    // ===================================================================
    protected virtual void EnemyBehaviour()
    {
        SeguirJogador();
    }

    // ===================================================================
    // ========================== MOVIMENTAÇÃO ===========================
    // ===================================================================
    protected void SeguirJogador()
    {
        Vector2 posicaoAtual = _enemyRigidbody.position;
        Vector2 posicaoAlvo = _jogadorGameObject.transform.position;
        direcao = (posicaoAlvo - posicaoAtual).normalized;

        direcao = direcao.normalized;
        _enemyRigidbody.velocity = (monster.Speed * direcao);
    }

    // ===================================================================
    // ======================== ANIMAÇÃO E MORTE =========================
    // ===================================================================
    public void ReceberDano(CombatResult result)
    {
        // Checagem de Crítico.
        if (result.isCritical)
            monster.Health -= result.finalDamage * (HeroImage.GetHeroCriticalMultiplier() / 100);

        else
            monster.Health -= result.finalDamage;

        // Texto de Dano, Efeito do dano.
        animations.Instantiate_DamageText(result);
        Instantiate_DamageEffect(result);

        // "Pisca" Cor quando recebe dano.
        animations.AtivaAnimacaoDano(Color.red);

        if (monster.Health <= 0)
            Death();
    }

    public void Death()
    {
        if (!isDead)
        {
            // Seta variáveis do monster
            GetComponent<Animator>().SetBool("Death", true);
            _capsuleCollider.enabled = false;
            isDead = true;

            // Dropa loot e destrava o bestiário dessa criatura
            DropLoot();
            monster.UnlockBestiaryAfterDeath();

            // Contabiliza mais um inimigo derrotado
            PlayerImage.inimigosDerrotados++;

            // Destroi o gameObject do monster
            Destroy(gameObject, 0.5f);
        }
    }

    private void Instantiate_DamageEffect(CombatResult result)
    {
        switch (result.element)
        {
            case Spell.Elemento.PHYSICAL:
                PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Physical, transform); break;

            case Spell.Elemento.FIRE:
                PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Fire, transform); break;

            case Spell.Elemento.ICE:
                PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Ice, transform); break;

            case Spell.Elemento.THUNDER:
                PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Thunder, transform); break;

            case Spell.Elemento.POISON:
                PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Poison, transform); break;

            default:
                PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Physical, transform); break;
        }
    }

    // ===================================================================
    // =========================== DROP LOOT =============================
    // ===================================================================
    public virtual void DropLoot()
    {
        if (isSiege)
            return;

        // Adiciona o Money.
        PlayerImage.moneyFeito += 1;

        // Dropa o ExpOrb
        if (!droppedLoot)
        {
            // Se o monstro tiver Exp Orb como Loot.
            if (LevelController.Instance.contadorTimerFase <= 1200) // do minuto 0 até 20 minutos
            {
                PrefabManager.Instance.InstantiateItemPrefab(PrefabManager_Itens.ItemType.OrangeExpOrb, transform);
            }
            else if (LevelController.Instance.contadorTimerFase <= 2400) // do minuto 20 até 40 minutos
            {
                PrefabManager.Instance.InstantiateItemPrefab(PrefabManager_Itens.ItemType.PurpleExpOrb, transform);
            }
            else if (LevelController.Instance.contadorTimerFase > 2400) // 40 minutos ou mais
            {
                PrefabManager.Instance.InstantiateItemPrefab(PrefabManager_Itens.ItemType.RedExpOrb, transform);
            }

            droppedLoot = true;
        }
    }

    // ===================================================================
    // ============================= STATUS ==============================
    // ===================================================================
    private float SetMonsterSpeed()
    {
        if (!monsterStarted)
            return 0f;

        float baseSpeed = monster.Speed;

        // Se estiver Frozen.
        if (conditions.isFrozen)
            baseSpeed *= 0.5f;

        return baseSpeed;
    }
}
