public class Bat : Monster
{
    public override int Killeds => PlayerConfig.bestiaryBatKilled;
    public Bat() : base()
    {
        monsterType = MonsterType.BAT;
        Name = "Bat";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Bat Description");

        // Drops
        
    }
}
