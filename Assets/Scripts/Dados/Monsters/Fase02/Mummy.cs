public class Mummy : Monster
{
    public override int Killeds => PlayerConfig.bestiaryMummyKilled;
    public Mummy() : base()
    {
        monsterType = MonsterType.MUMMY;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Mummy Description");

        // Drops
        
    }
}
