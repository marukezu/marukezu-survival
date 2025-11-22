public class Wolf_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryWolfBossKilled;
    public Wolf_Boss() : base()
    {
        monsterType = MonsterType.WOLF_BOSS;
        Name = "WolfBoss";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Wolf Description");

        // Drops
        
    }
}
