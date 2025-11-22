using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Boots : Upgrade
{
    public Upgrade_Boots(int level) : base(level)
    {
        upgradeIcon = SpritesManager.Instance.upgradesSprites.Boots_Icon;
        typeUpgrade = UpgradeType.BOOTS;
        upgradeName = LanguageManager.Get("Upgrade Boots Name");
        upgradeDescription = LanguageManager.Get("Upgrade Boots Description");
        upgradeLevel = level;
    }
}
