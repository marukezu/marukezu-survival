using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public const float BOOTS_UPGRADE_BASE = 1.5f;
    public const float GAUNTLET_UPGRADE_BASE = 3f;
    public const float CLOCK_UPGRADE_BASE = 1.5f;
    public const float HEART_UPGRADE_BASE = 5f;
    public const float RELICSKELETON_UPGRADE_BASE = 2f;
    public const float RELICBAT_UPGRADE_BASE = 2f;

    public enum UpgradeType
    {
        BOOTS,
        GAUNTLET,
        CLOCK,
        HEART,
        SKELETONRELIC,
        BATRELIC,
    }

    public UpgradeType typeUpgrade { get; protected set; }
    public Sprite upgradeIcon { get; protected set; }

    public string upgradeName { get; protected set; }
    public string upgradeDescription { get; protected set; }

    public int upgradeLevel { get; protected set; }
    public int upgradeMaxLevel { get; protected set; } = 5;
    public int upgradeValue => SetUpgradeValue();

    public Upgrade(int level)
    {
        UpgradeList.AllUpgrades.Add(this);
    }

    public virtual void AddLevel()
    {
        upgradeLevel++;
    }

    protected virtual int SetUpgradeValue()
    {
        switch (upgradeLevel)
        {
            case 0:
                return 1;
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 4;
            case 4:
                return 5;
            case 5:
                return 0;

            default: return 0; 
        }
    }
}
