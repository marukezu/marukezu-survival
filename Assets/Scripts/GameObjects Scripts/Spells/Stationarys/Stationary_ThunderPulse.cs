using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_ThunderPulse : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 0.4f;
        selfTarget = false;

        base.PosicionamentoInicial();
    }
}
