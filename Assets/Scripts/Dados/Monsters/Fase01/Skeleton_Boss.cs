public class Skeleton_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiarySkeletonBossKilled;
    public Skeleton_Boss() : base()
    {
        monsterType = MonsterType.SKELETON_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Skeleton_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Skeleton_Boss_Desc);

        // Drops

    }
}
