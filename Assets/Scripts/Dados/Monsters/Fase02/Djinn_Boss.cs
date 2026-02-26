public class Djinn_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDjinnBossKilled;
    public Djinn_Boss() : base()
    {
        monsterType = MonsterType.DJINN_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Djinn_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Djinn_Boss_Desc);

        // Drops

    }
}
