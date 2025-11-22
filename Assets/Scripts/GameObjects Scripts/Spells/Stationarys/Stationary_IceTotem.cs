using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_IceTotem : Stationary
{
    protected override void ColisaoComTarget(Collider2D collisor)
    {
        return;
    }
    protected override void PosicionamentoInicial()
    {
        duracao = 3f;
        selfTarget = false;
        Destroy(gameObject, duracao);

        base.PosicionamentoInicial();

        StartCoroutine(InstantiateIceExplosions());
    }

    private IEnumerator InstantiateIceExplosions()
    {
        yield return new WaitForSeconds(1f);

        // Instancia o Ice Explosion.
        GameObject iceExplosion1 = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.IceExplosion, transform);
        iceExplosion1.GetComponent<Stationary>().spell = spell;
    }
}
