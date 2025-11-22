using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Monster;

public class Zombie_Boss_Summon : Monster
{
    public override int Killeds => PlayerConfig.bestiaryZombieKilled;
    public Zombie_Boss_Summon() : base()
    {
        monsterType = MonsterType.ZOMBIE_BOSS_SUMMON;
        Name = "Zombie";
        Health = HEALTH_BASE;
        Speed = 2.5f;
        Description = LanguageManager.Get("Zombie Description");
    }
}
