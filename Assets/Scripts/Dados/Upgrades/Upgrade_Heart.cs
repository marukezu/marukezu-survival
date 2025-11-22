using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Upgrade;

public class Upgrade_Heart : Upgrade
{
    public Upgrade_Heart(int level) : base(level)
    {
        upgradeIcon = SpritesManager.Instance.upgradesSprites.Heart_Icon;
        typeUpgrade = UpgradeType.HEART;
        upgradeName = LanguageManager.Get("Upgrade Heart Name");
        upgradeDescription = LanguageManager.Get("Upgrade Heart Description");
        upgradeLevel = level;
    }
}
