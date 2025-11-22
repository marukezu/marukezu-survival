using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Monster;

public class Enemy_GameObject : Creature
{
    [Header("====== Configuração do Enemy ======")]
    public Monster.MonsterType monsterType;
    public bool isSiege;

    // Configuração do inimigo.
    [HideInInspector] public Monster monster;
    [HideInInspector] public float originalSpeed;
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

        // Armazena dados principais
        if (isSiege)
        {
            monster.Speed = 0.15f;
            originalSpeed = 0.15f;

            _enemyRigidbody.mass = 1000;
        }
        else
        {
            originalSpeed = monster.Speed;
        }
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
    public void ReceberDano(float quantidade, Color textColor)
    {
        monster.Health -= quantidade;

        animations.DamageText(quantidade, textColor);

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
}
