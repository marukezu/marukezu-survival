public class Skeleton_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiarySkeletonBossKilled;
    public Skeleton_Boss() : base()
    {
        monsterType = MonsterType.SKELETON_BOSS;
        Name = "SkeletonBoss";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Skeleton Description");

        // Drops
        
    }
}
