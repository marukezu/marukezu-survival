using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Creature
{
    // Componentes
    protected SpriteRenderer spriteRenderer;

    [Header("====== Prefab Configuration ======")]
    public float summonSpeed = 3f;

    protected virtual int SummonLevel { get; set; } // Implementado nas classes que herdam de summon
    protected Creature master => GameManager.Instance.playerHero;
    protected List<Spell> spells;

    protected virtual void Awake()
    {
        // Tenta pegar no próprio GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Se não encontrou, procura em filhos
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        SeguirMestre();
    }

    // Recebe os parametros para iniciar o summon
    public virtual void InitializeSummon(List<Spell> summonSpells)
    {
        spells = new List<Spell>(summonSpells);
    }

    protected virtual void SeguirMestre()
    {
        if (master == null) return;

        // Posição alvo é um pequeno offset em volta do mestre (por exemplo, atrás dele)
        Vector2 targetPosition = master.transform.position;

        // Opcional: manter uma distância mínima do mestre
        float distanciaDesejada = 1.5f;
        float distanciaAtual = Vector2.Distance(transform.position, targetPosition);

        // Se estiver muito longe, move em direção ao mestre
        if (distanciaAtual > distanciaDesejada)
        {
            Vector2 novaPosicao = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                summonSpeed * Time.deltaTime
            );

            transform.position = novaPosicao;

            // Flip Sprite
            if (spriteRenderer != null)
                spriteRenderer.flipX = (novaPosicao.x > master.transform.position.x);
        }
    }
}
