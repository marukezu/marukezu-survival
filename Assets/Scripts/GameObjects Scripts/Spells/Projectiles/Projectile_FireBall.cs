using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_FireBall : Projectile
{
    protected override void ColisaoComTarget(Collider2D collisor)
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Explosion, transform);
        spellPrefab.GetComponent<Stationary>().spell = spell;

        Destroy(gameObject);
    }
}
