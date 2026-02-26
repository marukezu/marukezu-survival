public class Zombie_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryZombieBossKilled;
    public Zombie_Boss() : base()
    {
        monsterType = MonsterType.ZOMBIE_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Zombie_Boss_Name);
        Health = HEALTH_BASE;
        Speed = 1.5f;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Zombie_Boss_Desc);
    }
}
