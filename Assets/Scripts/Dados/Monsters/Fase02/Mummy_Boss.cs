public class Mummy_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryMummyBossKilled;
    public Mummy_Boss() : base()
    { 
        monsterType = MonsterType.MUMMY_BOSS;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Mummy Description");

        // Drops
        
    }
}
