public class Djinn : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDjinnKilled;
    public Djinn() : base()
    {
        monsterType = MonsterType.DJINN;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Djinn_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Djinn_Desc);

        // Drops

    }
}
