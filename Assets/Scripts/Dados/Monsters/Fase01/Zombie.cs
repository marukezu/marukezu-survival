public class Zombie : Monster
{
    public override int Killeds => PlayerConfig.bestiaryZombieKilled;
    public Zombie() : base()
    {
        monsterType = MonsterType.ZOMBIE;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Zombie_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Zombie_Desc);
    }
}
