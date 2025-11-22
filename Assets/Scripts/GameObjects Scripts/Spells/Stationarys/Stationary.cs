using System.Collections.Generic;
using UnityEngine;

// Para spells que o efeito é em um local especifico.
// Modo de funcionamento:
// O Cast() da spell Instancia o objeto com esse script, ao ser instanciado o script procura um inimigo e se posiciona em cima dele, causando os efeitos.

public class Stationary : MonoBehaviour
{
    protected float duracao = 0f;
    protected bool selfTarget = false;

    [HideInInspector] public Creature target;
    [HideInInspector] public Spell spell;

    protected virtual void Start()
    {
        PosicionamentoInicial();
    }

    protected virtual void Update() { }

    public virtual void Initialize(Spell spell, bool selfTarget = true, Creature target = null) 
    {
        this.spell = spell;
        this.selfTarget = selfTarget;
        this.target = target;
    }

    protected virtual void PosicionamentoInicial()
    {
        if (!selfTarget) // se nao for selftarget
        {
            if (!target) // se nao tiver um target
            {
                // Adquire um target, caso não encontre, destroi o prefab.
                target = SpellsManager.Instance.GetRandomTarget(target);

                if (target != null)
                    transform.position = target.transform.position;
            }
        }
        else if (selfTarget) // se for selftarget
        {
            target = GameManager.Instance.playerHero;
        }

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject, duracao);
    }

    protected virtual void ColisaoComTarget(Collider2D collisor)
    {
        Combat.DoCombat(spell, collisor.gameObject.GetComponent<Enemy_GameObject>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ColisaoComTarget(collision);
        }
    }
}
