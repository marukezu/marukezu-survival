using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_ScatterArrow : Projectile
{
    private int spawnedArrows = 8;

    protected override void ColisaoComTarget(Collider2D collisor)
    {
        Vector3 collisorPos = collisor.transform.position;

        for (int i = 0; i < spawnedArrows; i++)
        {
            float angle = i * 45f; // 0, 45, 90, 135, ... 315°

            GameObject arrow = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Arrow, collisor.transform);
            Projectile arrowScript = arrow.GetComponent<Projectile>();
            arrowScript.InitializeProjectile(spell, collisorPos, angle, false);
        }

        Destroy(gameObject);
    }
}
