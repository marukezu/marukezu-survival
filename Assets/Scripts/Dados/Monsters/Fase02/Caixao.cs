public class Caixao : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCaixaoKilled;
    public Caixao() : base()
    {
        monsterType = MonsterType.CAIXAO;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Caixao Description");

        // Drops
        
    }
}
