public class Camelo : Monster
{
    public override int Killeds => PlayerConfig.bestiaryCameloKilled;
    public Camelo() : base()
    {
        monsterType = MonsterType.CAMELO;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Camelo_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Camelo_Desc);

        // Drops

    }
}
