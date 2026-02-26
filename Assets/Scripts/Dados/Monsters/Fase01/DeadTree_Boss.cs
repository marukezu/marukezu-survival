public class DeadTree_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDeadTreeBossKilled;
    public DeadTree_Boss() : base()
    {
        monsterType = MonsterType.DEADTREE_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.DeadTree_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.DeadTree_Boss_Desc);

        // Drops

    }
}
