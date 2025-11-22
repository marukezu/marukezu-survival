using System.Collections.Generic;

public static class RelicList
{
    public static List<Relic> AllRelics;

    // Relics
    public static SkeletonRelic SkeletonRelic = new SkeletonRelic();
    public static BatRelic BatRelic = new BatRelic();

    static RelicList()
    {
        AllRelics = new List<Relic> { SkeletonRelic, BatRelic };
    }
}
