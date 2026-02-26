public class DeadTree : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDeadTreeKilled;
    public DeadTree() : base()
    {
        monsterType = MonsterType.DEADTREE;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.DeadTree_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.DeadTree_Desc);

        // Drops

    }
}
