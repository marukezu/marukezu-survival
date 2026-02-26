public class Caixao_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCaixaoBossKilled;
    public Caixao_Boss() : base()
    {
        monsterType = MonsterType.CAIXAO_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Caixao_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Caixao_Boss_Desc);

        // Drops

    }
}
