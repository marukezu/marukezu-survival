public class Snake : Monster
{
    public override int Killeds => PlayerConfig.bestiarySnakeKilled;
    public Snake() : base()
    {
        monsterType = MonsterType.SNAKE;
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Snake Description");

        // Drops
        
    }
}
