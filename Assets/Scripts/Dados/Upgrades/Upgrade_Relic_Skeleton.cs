using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Upgrade;

public class Upgrade_Relic_Skeleton : Upgrade
{
    public Upgrade_Relic_Skeleton(int level) : base(level)
    {
        upgradeIcon = SpritesManager.Instance.upgradesSprites.Relic_Skeleton_Icon;
        typeUpgrade = UpgradeType.SKELETONRELIC;
        upgradeName = LanguageManager.Get("Upgrade Relic Skeleton Name");
        upgradeDescription = LanguageManager.Get("Upgrade Relic Skeleton Description");
        upgradeLevel = level;
    }
}
