using System.Collections;
using UnityEngine;

public class Hero_GameObject : Creature
{
    // Colisores
    public CircleCollider2D orbAttractor, playerCollider;

    // Componentes principais
    [HideInInspector] public Rigidbody2D heroRigidBody2D;
    [HideInInspector] public SpriteRenderer heroSpriteRenderer;
    [HideInInspector] public Animator heroAnimator;
    [HideInInspector] public Color heroOriginalColor;

    // Componentes scripts
    [HideInInspector] public Hero_Talents heroTalents;
    [HideInInspector] public Hero_Conditions heroConditions;
    [HideInInspector] public Hero_Relics heroRelics;
    [HideInInspector] public Hero_Inputs heroInputs;

    // Dano
    private float damageCooldown = 0.2f;
    private float damageTimer;

    private void Awake()
    {
        // Componentes
        heroRigidBody2D = GetComponent<Rigidbody2D>();
        heroSpriteRenderer = GetComponent<SpriteRenderer>();
        heroAnimator = GetComponent<Animator>();

        heroRelics = GetComponent<Hero_Relics>();
        heroInputs = GetComponent<Hero_Inputs>();

        heroTalents = new Hero_Talents();
        heroConditions = new Hero_Conditions(this);

        heroOriginalColor = heroSpriteRenderer.material.color;
    }

    private void Update()
    {
        heroConditions.ApplyConditions();

        damageTimer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (heroRelics.isRelic_SkeletonActive || heroConditions.isProtected)
                return;

            if (damageTimer <= 0f)
            {
                CausarDanoAoJogador();
                damageTimer = damageCooldown;
            }
        }
    }

    private void CausarDanoAoJogador()
    {
        HeroImage.AddHealthNow(-2);
        AudioManager.Instance.PlaySoundEffectPlayerDamaged(Random.Range(0, 2));

        StartCoroutine(FlashColorDamage());

        if (HeroImage.healthNow <= 0)
        {
            PlayerDeath();
        }
    }

    private IEnumerator FlashColorDamage()
    {
        heroSpriteRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        heroSpriteRenderer.material.color = heroOriginalColor;
    }

    private void PlayerDeath()
    {
        if (isDead) return;

        heroInputs.Movimentacao(Vector2.zero);

        StartCoroutine(GameManager.Instance.CallGameOver());
    }
}
