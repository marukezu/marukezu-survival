using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_IceExplosion : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 1.25f;
        selfTarget = false;
        Destroy(gameObject, duracao);
        // base.PosicionamentoInicial();
    }
}
