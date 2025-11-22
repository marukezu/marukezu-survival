public class Zombie : Monster
{
    public override int Killeds => PlayerConfig.bestiaryZombieKilled;
    public Zombie() : base()
    {
        monsterType = MonsterType.ZOMBIE;
        Name = "Zombie";
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get("Zombie Description");        
    }
}
