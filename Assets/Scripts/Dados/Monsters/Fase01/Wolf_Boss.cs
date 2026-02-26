public class Wolf_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryWolfBossKilled;
    public Wolf_Boss() : base()
    {
        monsterType = MonsterType.WOLF_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Wolf_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Wolf_Boss_Desc);

        // Drops

    }
}
