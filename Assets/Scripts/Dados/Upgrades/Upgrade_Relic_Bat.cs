using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Upgrade;

public class Upgrade_Relic_Bat : Upgrade
{
    public Upgrade_Relic_Bat(int level) : base(level)
    {
        upgradeIcon = SpritesManager.Instance.upgradesSprites.Relic_Bat_Icon;
        typeUpgrade = UpgradeType.BATRELIC;
        upgradeName = LanguageManager.Get("Upgrade Relic Bat Name");
        upgradeDescription = LanguageManager.Get("Upgrade Relic Bat Description");
        upgradeLevel = level;
    }
}
