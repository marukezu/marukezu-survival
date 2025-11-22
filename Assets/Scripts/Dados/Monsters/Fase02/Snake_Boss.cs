public class Snake_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiarySnakeBossKilled;
    public Snake_Boss() : base()
    {
        monsterType = MonsterType.SNAKE_BOSS;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Snake Description");

        // Drops
        
    }
}
