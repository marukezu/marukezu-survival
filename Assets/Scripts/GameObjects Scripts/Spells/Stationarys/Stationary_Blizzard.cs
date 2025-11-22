using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_Blizzard : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 1.75f;
        selfTarget = false;

        base.PosicionamentoInicial();
    }
}
