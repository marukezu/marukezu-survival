public class Camelo : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCameloKilled;
    public Camelo() : base()
    {
        monsterType = MonsterType.CAMELO;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Camelo Description");

        // Drops
        
    }
}
