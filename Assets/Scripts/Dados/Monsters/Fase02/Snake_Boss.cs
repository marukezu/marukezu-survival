public class Snake_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiarySnakeBossKilled;
    public Snake_Boss() : base()
    {
        monsterType = MonsterType.SNAKE_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Snake_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Snake_Boss_Desc);

        // Drops

    }
}
