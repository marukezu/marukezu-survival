public class Spider : Monster
{
    public override int Killeds => PlayerConfig.bestiarySpiderKilled;
    public Spider() : base()
    {
        monsterType = MonsterType.SPIDER;
        Name = "Spider";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Spider Description");

        // Drops
        
    }
}
