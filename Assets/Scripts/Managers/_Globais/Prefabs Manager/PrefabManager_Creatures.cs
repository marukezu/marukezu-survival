using System.Collections.Generic;
using UnityEngine;

public class PrefabManager_Creatures : MonoBehaviour
{
    public enum CreatureType
    {
        // Heroes
        Zephyr,
        Kael,
        Broghar,

        // Fase 01
        Skeleton,
        Skeleton_Boss,
        Bat,
        Bat_Boss,
        Spider,
        Wolf,
        Wolf_Boss,
        Zombie,
        Zombie_Boss,
        ZombieBossSummon,
        DeadTree,
        DeadTree_Boss,

        // Fase 02
        Snake,
        Snake_Boss,
        Mummy,
        Mummy_Boss,
        Camelo,
        Camelo_Boss,
        Caixao,
        Caixao_Boss,
        Djinn,
        Djinn_Boss
    }

    [Header("====== Heroes ======")]
    public GameObject Zephyr;
    public GameObject Kael;
    public GameObject Broghar;

    [Header("====== Monsters Fase01 ======")]
    public GameObject Skeleton;
    public GameObject Skeleton_Boss;
    public GameObject Bat;
    public GameObject Bat_Boss;
    public GameObject Spider;
    public GameObject Wolf;
    public GameObject Wolf_Boss;
    public GameObject Zombie;
    public GameObject Zombie_Boss;
    public GameObject Zombie_Boss_Summon;
    public GameObject DeadTree;
    public GameObject DeadTree_Boss;

    [Header("====== Monsters Fase02 ======")]
    public GameObject Snake;
    public GameObject Snake_Boss;
    public GameObject Mummy;
    public GameObject Mummy_Boss;
    public GameObject Camelo;
    public GameObject Camelo_Boss;
    public GameObject Caixao;
    public GameObject Caixao_Boss;
    public GameObject Djinn;
    public GameObject Djinn_Boss;

    private Dictionary<CreatureType, GameObject> monsterPrefabs;

    private void Awake()
    {
        monsterPrefabs = new Dictionary<CreatureType, GameObject>
        {
            // Heroes
            { CreatureType.Zephyr, Zephyr },
            { CreatureType.Kael, Kael },
            { CreatureType.Broghar, Broghar },

            // Fase 01
            { CreatureType.Skeleton, Skeleton },
            { CreatureType.Skeleton_Boss, Skeleton_Boss },
            { CreatureType.Bat, Bat },
            { CreatureType.Bat_Boss, Bat_Boss },
            { CreatureType.Spider, Spider },
            { CreatureType.Wolf, Wolf },
            { CreatureType.Wolf_Boss, Wolf_Boss },
            { CreatureType.Zombie, Zombie },
            { CreatureType.Zombie_Boss, Zombie_Boss },
            { CreatureType.ZombieBossSummon, Zombie_Boss_Summon },
            { CreatureType.DeadTree, DeadTree },
            { CreatureType.DeadTree_Boss, DeadTree_Boss },

            // Fase 02
            { CreatureType.Snake, Snake },
            { CreatureType.Snake_Boss, Snake_Boss },
            { CreatureType.Mummy, Mummy },
            { CreatureType.Mummy_Boss, Mummy_Boss },
            { CreatureType.Camelo, Camelo },
            { CreatureType.Camelo_Boss, Camelo_Boss },
            { CreatureType.Caixao, Caixao },
            { CreatureType.Caixao_Boss, Caixao_Boss },
            { CreatureType.Djinn, Djinn },
            { CreatureType.Djinn_Boss, Djinn_Boss },
        };
    }

    public GameObject GetCreaturePrefab(CreatureType type)
    {
        if (monsterPrefabs.TryGetValue(type, out GameObject prefab))
        {
            return prefab;
        }

        return null;
    }
}