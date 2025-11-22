using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion_Explosion : Potion
{
    public override int playerHave => PlayerConfig.potionExplosions;
    public Potion_Explosion() 
    {
        typePotion = PotionType.Explosive;
        potionName = LanguageManager.Get("Potion Explosion");
        potionIcon = SpritesManager.Instance.potionsSprites.potion_explosion_icon;
        potionPrice = 750;
        maxQuantity = 2;
        effectPotency = 9999;
    }

    public override void ConsumePotion()
    {
        if (PlayerConfig.potionExplosions <= 0)
            return;

        PlayerConfig.potionExplosions--;
        PrefabManager.Instance.potionsManager.InstantiatePrefab(typePotion, GameManager.Instance.playerHero.transform);
    }
}
