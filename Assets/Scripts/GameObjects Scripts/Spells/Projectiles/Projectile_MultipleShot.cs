using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_MultipleShot : Projectile
{
    protected override void Start()
    {
        base.Start();
        // Para garantir que o projetil se mova na direção inicial sem buscar target
        persegueAlvo = false;
        spriteFixa = true;

        Destroy(gameObject, duracao);
    }

    // Sobrescreve InitializeProjectile para receber ângulo de lançamento
    public void InitializeProjectile(Spell spell, Vector3 casterPosition, float angle)
    {
        this.spell = spell;

        // Calcula a direção baseado no ângulo
        float rad = angle * Mathf.Deg2Rad;
        moveDirection = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0).normalized;

        // Posiciona no caster
        transform.position = casterPosition;

        // Rotaciona visualmente
        float rotationZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        // Garante que não busca alvo
        target = null;
        persegueAlvo = false;
        spriteFixa = true;
    }

    protected override void Update()
    {
        // Move sempre na direção inicial
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
