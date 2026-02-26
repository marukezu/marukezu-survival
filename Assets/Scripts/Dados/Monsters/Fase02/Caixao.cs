public class Caixao : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCaixaoKilled;
    public Caixao() : base()
    {
        monsterType = MonsterType.CAIXAO;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Caixao_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Caixao_Desc);

        // Drops

    }
}
