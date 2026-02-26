public class Mummy_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryMummyBossKilled;
    public Mummy_Boss() : base()
    { 
        monsterType = MonsterType.MUMMY_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Mummy_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Mummy_Boss_Desc);

        // Drops

    }
}
