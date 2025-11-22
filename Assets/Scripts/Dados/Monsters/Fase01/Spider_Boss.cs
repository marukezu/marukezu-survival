public class Spider_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiarySpiderBossKilled;
    public Spider_Boss() : base()
    {
        monsterType = MonsterType.SPIDER_BOSS;
        Name = "SpiderBoss";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Spider Description");

        // Drops
        
    }
}
