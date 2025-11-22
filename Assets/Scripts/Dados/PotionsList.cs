using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PotionsList
{
    public static Potion_Explosion Potion_Explosion = new Potion_Explosion();
    public static Potion_Restauration Potion_Restauration = new Potion_Restauration();

    public static List<Potion> potions = new List<Potion>()
    {
        Potion_Explosion, Potion_Restauration,
    };
}
