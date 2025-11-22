public class Zombie_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryZombieBossKilled;
    public Zombie_Boss() : base()
    {
        monsterType = MonsterType.ZOMBIE_BOSS;
        Name = "ZombieBoss";
        Health = HEALTH_BASE;
        Speed = 1.5f;
        Description = LanguageManager.Get("Zombie Description");
    }
}
