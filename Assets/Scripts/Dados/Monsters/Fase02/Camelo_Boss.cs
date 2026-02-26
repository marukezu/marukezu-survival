public class Camelo_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCameloBossKilled;
    public Camelo_Boss() : base()
    {
        monsterType = MonsterType.CAMELO_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Camelo_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Camelo_Boss_Desc);

        // Drops

    }
}
