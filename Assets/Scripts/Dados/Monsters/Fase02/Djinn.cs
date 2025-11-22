public class Djinn : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDjinnKilled;
    public Djinn() : base()
    {
        monsterType = MonsterType.DJINN;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Djinn Description");

        // Drops
        
    }
}
