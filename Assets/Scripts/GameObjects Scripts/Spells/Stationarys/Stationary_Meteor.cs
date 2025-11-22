using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_Meteor : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 1.8f;
        selfTarget = false;

        base.PosicionamentoInicial();
    }
}
