public class Spider : Monster
{
    public override int Killeds => PlayerConfig.bestiarySpiderKilled;
    public Spider() : base()
    {
        monsterType = MonsterType.SPIDER;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Spider_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Spider_Desc);

        // Drops

    }
}
