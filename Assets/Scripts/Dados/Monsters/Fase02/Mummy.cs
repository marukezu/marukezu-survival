public class Mummy : Monster
{
    public override int Killeds => PlayerConfig.bestiaryMummyKilled;
    public Mummy() : base()
    {
        monsterType = MonsterType.MUMMY;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Mummy_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Mummy_Desc);

        // Drops

    }
}
