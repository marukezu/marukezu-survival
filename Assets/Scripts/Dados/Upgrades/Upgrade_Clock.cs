using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Clock : Upgrade
{
    public Upgrade_Clock(int level) : base(level)
    {
        upgradeIcon = SpritesManager.Instance.upgradesSprites.Clock_Icon;
        typeUpgrade = UpgradeType.CLOCK;
        upgradeName = LanguageManager.Get("Upgrade Clock Name");
        upgradeDescription = LanguageManager.Get("Upgrade Clock Description");
        upgradeLevel = level;
    }
}
