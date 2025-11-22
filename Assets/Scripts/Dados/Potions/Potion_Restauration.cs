using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion_Restauration : Potion
{
    public override int playerHave => PlayerConfig.potionHealing;
    public Potion_Restauration()
    {
        typePotion = PotionType.Restoration;
        potionName = LanguageManager.Get("Potion Restoration");
        potionIcon = SpritesManager.Instance.potionsSprites.potion_restauration_icon;
        potionPrice = 750;
        maxQuantity = 2;
    }

    public override void ConsumePotion()
    {
        if (PlayerConfig.potionHealing <= 0)
            return;

        PlayerConfig.potionHealing--;
        GameManager.Instance.playerHero.StartCoroutine(Restore());
    }

    private IEnumerator Restore()
    {
        for (int i = 0; i < 5; i++)
        {
            // Recupera 1/10 do HP
            HeroImage.AddHealthNow(HeroImage.GetHeroMaxHP() / 10);

            // Instancia o efeito de heal
            PrefabManager.Instance.potionsManager.InstantiatePrefab(typePotion, GameManager.Instance.playerHero.transform);
            yield return new WaitForSeconds(1);
        }
    }
}
