public class DeadTree : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDeadTreeKilled;
    public DeadTree() : base()
    {
        monsterType = MonsterType.DEADTREE;
        Name = "DeadTree";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("DeadTree Description");

        // Drops
        
    }
}
