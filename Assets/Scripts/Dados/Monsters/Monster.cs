using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Monster : ThingData
{
    // =========================
    // REGISTRO GLOBAL DE MONSTERS
    // =========================
    private static int _nextID = 0;
    public static List<Monster> AllMonsters = new List<Monster>();
    public static Monster GetByID(int id) => AllMonsters.FirstOrDefault(s => s.ID == id);

    public enum MonsterType
    {
        // Floresta do Desespero
        SKELETON, BAT, SPIDER, WOLF, ZOMBIE, DEADTREE,
        SKELETON_BOSS, BAT_BOSS, SPIDER_BOSS, WOLF_BOSS, ZOMBIE_BOSS, ZOMBIE_BOSS_SUMMON, DEADTREE_BOSS,

        // Deserto Ventoso
        SNAKE, MUMMY, CAMELO, CAIXAO, DJINN,
        SNAKE_BOSS, MUMMY_BOSS, CAMELO_BOSS, CAIXAO_BOSS, DJINN_BOSS,
    }

    public const float HEALTH_BASE = 100;
    public const float SPEED_BASE = 1.0f;

    // ThingData Definition
    public override DataType Type => DataType.MONSTER;

    // Monster Variables
    public int ID;
    public MonsterType monsterType;
    public virtual int Killeds => 0;
    public int Nivel = 1;
    public string Name;
    public float Health;
    public float Speed { get; set; }
    public string Description;

    // Construtor para a classe MonsterList
    public Monster() 
    {
        ID = _nextID++;
        AllMonsters.Add(this);
    }

    // Construtor usado para a classe Creature clonar um Monster existente em (class - List MonsterList.AllMonsters)
    public Monster(Monster other, int nivel)
    {
        ID = other.ID;
        monsterType = other.monsterType;
        Name = other.Name;
        Nivel = nivel;
        Speed = other.Speed;
        Description = other.Description;

        ApplyLevelScaling();
    }

    public void ApplyLevelScaling()
    {
        // Aumenta o Health em 30% por nível acima do 1
        Health = HEALTH_BASE * (1f + 0.3f * (Nivel - 1));

        Debug.Log("MONSTER HEALTH: " + Health);
    }

    public void UnlockBestiaryAfterDeath()
    {
        switch (monsterType)
        {
            case MonsterType.SKELETON: PlayerConfig.bestiarySkeletonKilled++; PlayerConfig.bestiarySkeletonUnlocked = true; break;
            case MonsterType.BAT: PlayerConfig.bestiaryBatKilled++; PlayerConfig.bestiaryBatUnlocked = true; break;
            case MonsterType.SPIDER: PlayerConfig.bestiarySpiderKilled++; PlayerConfig.bestiarySpiderUnlocked = true; break;
            case MonsterType.WOLF: PlayerConfig.bestiaryWolfKilled++; PlayerConfig.bestiaryWolfUnlocked = true; break;
            case MonsterType.ZOMBIE: PlayerConfig.bestiaryZombieKilled++; PlayerConfig.bestiaryZombieUnlocked = true; break;
            case MonsterType.DEADTREE: PlayerConfig.bestiaryDeadTreeKilled++; PlayerConfig.bestiaryDeadTreeUnlocked = true; break;

            case MonsterType.SKELETON_BOSS: PlayerConfig.bestiarySkeletonBossKilled++; PlayerConfig.bestiarySkeletonBossUnlocked = true; break;
            case MonsterType.BAT_BOSS: PlayerConfig.bestiaryBatBossKilled++; PlayerConfig.bestiaryBatBossUnlocked = true; break;
            case MonsterType.WOLF_BOSS: PlayerConfig.bestiaryWolfBossKilled++; PlayerConfig.bestiaryWolfBossUnlocked = true; break;
            case MonsterType.ZOMBIE_BOSS: PlayerConfig.bestiaryZombieBossKilled++; PlayerConfig.bestiaryZombieBossUnlocked = true; break;
            case MonsterType.DEADTREE_BOSS: PlayerConfig.bestiaryDeadTreeBossKilled++; PlayerConfig.bestiaryDeadTreeBossUnlocked = true; break;

            case MonsterType.SNAKE: PlayerConfig.bestiarySnakeKilled++; PlayerConfig.bestiarySnakeUnlocked = true; break;
            case MonsterType.MUMMY: PlayerConfig.bestiaryMummyKilled++; PlayerConfig.bestiaryMummyUnlocked = true; break;
            case MonsterType.CAMELO: PlayerConfig.bestiaryCameloKilled++; PlayerConfig.bestiaryCameloUnlocked = true; break;
            case MonsterType.CAIXAO: PlayerConfig.bestiaryCaixaoKilled++; PlayerConfig.bestiaryCaixaoUnlocked = true; break;
            case MonsterType.DJINN: PlayerConfig.bestiaryDjinnKilled++; PlayerConfig.bestiaryDjinnUnlocked = true; break;

            case MonsterType.SNAKE_BOSS: PlayerConfig.bestiarySnakeBossKilled++; PlayerConfig.bestiarySnakeBossUnlocked = true; break;
            case MonsterType.MUMMY_BOSS: PlayerConfig.bestiaryMummyBossKilled++; PlayerConfig.bestiaryMummyBossUnlocked = true; break;
            case MonsterType.CAMELO_BOSS: PlayerConfig.bestiaryCameloBossKilled++; PlayerConfig.bestiaryCameloBossUnlocked = true; break;
            case MonsterType.CAIXAO_BOSS: PlayerConfig.bestiaryCaixaoBossKilled++; PlayerConfig.bestiaryCaixaoBossUnlocked = true; break;
            case MonsterType.DJINN_BOSS: PlayerConfig.bestiaryDjinnBossKilled++; PlayerConfig.bestiaryDjinnBossUnlocked = true; break;
        }

        SaveManager.SaveGame();
    }
}
