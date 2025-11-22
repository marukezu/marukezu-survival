using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeList : MonoBehaviour
{
    public static List<Upgrade> AllUpgrades { get; set; } = new List<Upgrade>();

    public static Upgrade_Relic_Skeleton Upgrade_Relic_Skeleton = new Upgrade_Relic_Skeleton(PlayerConfig.skeletonRelicUpgradeLevel);
    public static Upgrade_Relic_Bat Upgrade_Relic_Bat = new Upgrade_Relic_Bat(PlayerConfig.batRelicUpgradeLevel);
}
