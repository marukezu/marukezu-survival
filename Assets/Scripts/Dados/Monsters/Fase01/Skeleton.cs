public class Skeleton : Monster
{
    public override int Killeds => PlayerConfig.bestiarySkeletonKilled;

    public Skeleton() : base()
    {
        monsterType = MonsterType.SKELETON;
        Name = "Skeleton";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Skeleton Description");

        // Drops
        
    }
}
