public class Bat_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryBatBossKilled;
    public Bat_Boss() : base()
    {
        monsterType = MonsterType.BAT_BOSS;
        Name = "BatBoss";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Bat Description");

        // Drops
        
    }
}