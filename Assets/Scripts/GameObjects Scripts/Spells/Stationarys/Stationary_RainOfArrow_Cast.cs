using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_RainOfArrow_Cast : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 4f;
        selfTarget = true;

        StartCoroutine(CastFallingArrow());

        base.PosicionamentoInicial();
    }

    private IEnumerator CastFallingArrow()
    {
        yield return new WaitForSeconds(2f);

        GameObject fallingArrowPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.RainOfArrow_Falling, transform);
        fallingArrowPrefab.GetComponent<Stationary>().spell = spell;
    }
}
