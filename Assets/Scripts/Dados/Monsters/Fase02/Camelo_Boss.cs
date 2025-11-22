public class Camelo_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCameloBossKilled;
    public Camelo_Boss() : base()
    {
        monsterType = MonsterType.CAMELO_BOSS;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Camelo Description");

        // Drops
        
    }
}
