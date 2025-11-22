using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe base para outras herdarem.
public class ThingData
{ 
    public enum DataType
    {
        MONSTER,
        RELIC,
        SPELL,
    }

    public virtual DataType Type { get; set; }
}
