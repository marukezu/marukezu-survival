public class Bat_Boss : Monster
{
    public override int Killeds => PlayerConfig.bestiaryBatBossKilled;
    public Bat_Boss() : base()
    {
        monsterType = MonsterType.BAT_BOSS;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Bat_Boss_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Bat_Boss_Desc);

        // Drops
        
    }
}