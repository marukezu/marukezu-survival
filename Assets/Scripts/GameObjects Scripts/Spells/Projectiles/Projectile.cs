using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("====== Configuração Básica do Projétil ======")]
    public float speed = 5f;
    public float duracao = 5f;

    [Header("====== Comportamento ======")]
    public bool atravessaAlvo;
    public bool persegueAlvo = true;
    public bool spriteFixa;

    protected Creature target;
    protected Spell spell;
    protected Vector3 moveDirection;
    protected int quicadoVezes = 1;

    // Se verdadeiro, ignora qualquer alvo e apenas segue o ângulo inicial
    protected bool usaAnguloFixo;

    protected virtual void Start()
    {
        // Só aponta para o target se não estiver usando ângulo fixo
        if (!usaAnguloFixo)
            ApontarAoTarget();

        if (duracao > 0)
            Destroy(gameObject, duracao);
    }

    protected virtual void Update()
    {
        MoverAoTarget();
    }

    // =========================================================
    // Inicializações
    // =========================================================

    // 🔹 Inicializa mirando em um target
    public virtual void InitializeProjectile(Spell spell, Creature target = null)
    {
        this.spell = spell;
        this.target = target ?? SpellsManager.Instance.GetRandomTarget(null);

        if (this.target == null)
        {
            Destroy(gameObject);
            return;
        }

        usaAnguloFixo = false;
        ApontarAoTarget();
    }

    // 🔹 Inicializa com um ângulo fixo (sem target)
    public virtual void InitializeProjectile(Spell spell, Vector3 casterPosition, float angle, bool atravessa = false)
    {
        this.spell = spell;
        this.target = null;
        usaAnguloFixo = true;
        persegueAlvo = false;
        atravessaAlvo = atravessa;

        transform.position = casterPosition;

        // Calcula direção baseada no ângulo
        float rad = angle * Mathf.Deg2Rad;
        moveDirection = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f).normalized;

        if (!spriteFixa)
        {
            float rotationZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }

    // =========================================================
    // Movimento
    // =========================================================
    protected virtual void ApontarAoTarget()
    {
        if (target == null)
        {
            moveDirection = transform.right;
            return;
        }

        moveDirection = (target.transform.position - transform.position).normalized;

        if (!spriteFixa)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    protected virtual void MoverAoTarget()
    {
        // Caso o projétil use ângulo fixo, apenas segue em frente
        if (usaAnguloFixo)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
            return;
        }

        // Caso ele persiga alvo
        if (persegueAlvo && target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            moveDirection = direction;

            if (!spriteFixa)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
        else if (persegueAlvo && target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += moveDirection * speed * Time.deltaTime;
    }

    // =========================================================
    // Colisão
    // =========================================================
    protected virtual void ColisaoComTarget(Collider2D collisor)
    {
        Combat.DoCombat(spell, collisor.gameObject.GetComponent<Enemy_GameObject>());

        if (spell.JumpQuantity > 0)
        {
            if (quicadoVezes < spell.JumpQuantity)
            {
                target = SpellsManager.Instance.GetRandomTarget(target);
                if (target == null)
                {
                    Destroy(gameObject);
                    return;
                }

                ApontarAoTarget();
                quicadoVezes++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (!atravessaAlvo)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;

        Enemy_GameObject enemy = collision.GetComponent<Enemy_GameObject>();
        if (enemy == null)
            return;

        if (persegueAlvo)
        {
            if (enemy == target)
                ColisaoComTarget(collision);
        }
        else
        {
            ColisaoComTarget(collision);
        }
    }
}
