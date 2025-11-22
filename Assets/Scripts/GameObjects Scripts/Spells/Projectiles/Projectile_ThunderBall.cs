using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_ThunderBall : Projectile
{
    protected override void ColisaoComTarget(Collider2D collisor)
    {
        // Pega o componente Creature do Colisor.
        Creature alvoCollisor = collisor.GetComponent<Creature>();

        // Se o colisor não tiver um componente Creature
        if (alvoCollisor == null)
            return;

        // Instancia o Thunder bolt que perseguirá o alvo.
        GameObject thunderBolt = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.ThunderBolt, transform);
        thunderBolt.GetComponent<Projectile>().InitializeProjectile(spell, alvoCollisor);
    }
}
