public class Djinn_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDjinnBossKilled;
    public Djinn_Boss() : base()
    {
        monsterType = MonsterType.DJINN_BOSS;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Djinn Description");

        // Drops
        
    }
}
