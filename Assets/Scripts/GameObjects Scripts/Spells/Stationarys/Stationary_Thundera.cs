using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_Thundera : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 0.75f;
        selfTarget = false;

        base.PosicionamentoInicial();
    }
}
