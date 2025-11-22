using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Upgrade;

public class Upgrade_Gauntlet : Upgrade
{
    public Upgrade_Gauntlet(int level) : base(level)
    {
        upgradeIcon = SpritesManager.Instance.upgradesSprites.Gauntlet_Icon;
        typeUpgrade = UpgradeType.GAUNTLET;
        upgradeName = LanguageManager.Get("Upgrade Gauntlet Name");
        upgradeDescription = LanguageManager.Get("Upgrade Gauntlet Description");
        upgradeLevel = level;
    }
}
