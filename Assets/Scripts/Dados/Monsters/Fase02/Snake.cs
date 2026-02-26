public class Snake : Monster
{
    public override int Killeds => PlayerConfig.bestiarySnakeKilled;
    public Snake() : base()
    {
        monsterType = MonsterType.SNAKE;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Snake_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Snake_Desc);

        // Drops

    }
}
