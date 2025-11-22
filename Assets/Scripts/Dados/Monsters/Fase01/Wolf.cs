public class Wolf : Monster
{
    public override int Killeds => PlayerConfig.bestiaryWolfKilled;
    public Wolf() : base()
    {
        monsterType = MonsterType.WOLF;
        Name = "Wolf";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Wolf Description");

        // Drops
        
    }
}
