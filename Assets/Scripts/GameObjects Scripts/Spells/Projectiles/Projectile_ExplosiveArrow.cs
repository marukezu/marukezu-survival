using UnityEngine;

public class Projectile_ExplosiveArrow : Projectile
{
    protected override void ColisaoComTarget(Collider2D collisor)
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Explosion, transform);
        spellPrefab.GetComponent<Stationary>().Initialize(spell, false, collisor.GetComponent<Creature>());

        Destroy(gameObject);
    }
}
