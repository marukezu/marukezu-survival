public class Bat : Monster
{
    public override int Killeds => PlayerConfig.bestiaryBatKilled;
    public Bat() : base()
    {
        monsterType = MonsterType.BAT;
        Name = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Bat_Name);
        Health = HEALTH_BASE;
        Speed = SPEED_BASE;
        Description = LanguageManager.Get(LanguageTexts_Enemy.EnemyWords.Bat_Desc);

        // Drops
        
    }
}
