using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroImage_Summons : MonoBehaviour
{
    public enum SummonType
    {
        FireElemental,
    }

    public static int fireElemental_Quantity = 0;

    public static void ResetSummons()
    {
        fireElemental_Quantity = 0;
    }
}
