public class Wolf : Monster
{
    public override int Killeds => PlayerConfig.bestiaryWolfKilled;
    public Wolf() : base()
    {
        monsterType = MonsterType.WOLF;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Wolf_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Wolf_Desc);

        // Drops

    }
}
