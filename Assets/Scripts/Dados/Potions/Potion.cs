using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion
{
    public enum PotionType
    {
        None,
        Explosive,
        Restoration,
    }
    public PotionType typePotion;
    public string potionName;
    public Sprite potionIcon;
    public int potionPrice;
    public float effectPotency;
    public virtual int playerHave { get; set; } // Quantas dessa poção o player tem
    public int maxQuantity;

    public virtual void ConsumePotion() { }
}
