using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_Explosion : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 0.75f;

        base.PosicionamentoInicial();
    }
}
