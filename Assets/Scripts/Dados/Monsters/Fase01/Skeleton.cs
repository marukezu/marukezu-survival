public class Skeleton : Monster
{
    public override int Killeds => PlayerConfig.bestiarySkeletonKilled;

    public Skeleton() : base()
    {
        monsterType = MonsterType.SKELETON;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Skeleton_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Skeleton_Desc);

        // Drops

    }
}
