using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_RainOfArrow_Falling : Stationary
{
    protected override void PosicionamentoInicial()
    {
        duracao = 2.5f;
        base.PosicionamentoInicial();        
    }
}
