using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_PoisonKunai : Projectile
{
    protected override void Start()
    {
        base.Start();
        // Garante que siga na direção inicial
        persegueAlvo = false;
        spriteFixa = true;

        Destroy(gameObject, duracao);
    }

    // Inicializa com target opcional
    public override void InitializeProjectile(Spell spell, Creature targetCreature)
    {
        this.spell = spell;

        // Busca um target
        this.target = SpellsManager.Instance.GetRandomTarget(target);
        if (this.target == null)
            Destroy(gameObject);

        if (target != null)
        {
            // Calcula direção inicial apontando para o target
            moveDirection = (target.transform.position - transform.position).normalized;

            // Rotaciona visualmente
            float rotationZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
        else
        {
            // Caso não tenha target, vai para frente
            moveDirection = transform.right;
        }

        // Garante que não atualize direção depois
        persegueAlvo = false;
        spriteFixa = true;
    }

    protected override void Update()
    {
        // Move sempre na direção inicial
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
