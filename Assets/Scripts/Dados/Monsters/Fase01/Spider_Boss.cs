public class Spider_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiarySpiderBossKilled;
    public Spider_Boss() : base()
    {
        monsterType = MonsterType.SPIDER_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Spider_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Spider_Boss_Desc);

        // Drops

    }
}
