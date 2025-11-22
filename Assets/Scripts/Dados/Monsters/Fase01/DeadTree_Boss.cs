public class DeadTree_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryDeadTreeBossKilled;
    public DeadTree_Boss() : base()
    {
        monsterType = MonsterType.DEADTREE_BOSS;
        Name = "DeadTreeBoss";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("DeadTree Description");

        // Drops
        
    }
}
