public class Caixao_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCaixaoBossKilled;
    public Caixao_Boss() : base()
    {
        monsterType = MonsterType.CAIXAO_BOSS;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Caixao Description");

        // Drops
        
    }
}
