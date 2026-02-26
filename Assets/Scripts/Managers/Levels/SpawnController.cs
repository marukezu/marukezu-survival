using System.Collections.Generic;
using UnityEngine;
using static SpawnController;

public class SpawnController : MonoBehaviour
{
    public enum Creatures
    {
        None,

        Skeleton,
        SkeletonBoss,

        Bat,
        BatBoss,

        Wolf,
        WolfBoss,

        Spider,

        Zombie,
        ZombieBoss,
        ZombieBossSummon,

        DeadTree,
        DeadTreeBoss,
    }

    public static SpawnController Instance;

    private Dictionary<Creatures, GameObject> creatures;

    public Transform[] spawnsNorth, spawnsEast, spawnsSouth, spawnsWest;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        creatures = new Dictionary<Creatures, GameObject>
        {
            { Creatures.Skeleton,     PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Skeleton) },
            { Creatures.SkeletonBoss, PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Skeleton_Boss) },

            { Creatures.Bat,          PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Bat) },
            { Creatures.BatBoss,      PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Bat_Boss) },

            { Creatures.Wolf,         PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Wolf) },
            { Creatures.WolfBoss,     PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Wolf_Boss) },

            { Creatures.Spider,       PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Spider) },

            { Creatures.Zombie,       PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Zombie) },
            { Creatures.ZombieBoss,   PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.Zombie_Boss) },
            { Creatures.ZombieBossSummon,   PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.ZombieBossSummon) },

            { Creatures.DeadTree,     PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.DeadTree) },
            { Creatures.DeadTreeBoss, PrefabManager.Instance.GetMonsterPrefab(PrefabManager_Creatures.CreatureType.DeadTree_Boss) },
        };
    }

    public Enemy_GameObject SpawnEnemyInPosition(Creatures creature, int nivel, Vector2 position)
    {
        creatures.TryGetValue(creature, out GameObject creaturePrefab);

        GameObject spawnedEnemy = Instantiate(creaturePrefab, position, Quaternion.identity);
        Enemy_GameObject enemyScript = spawnedEnemy.GetComponent<Enemy_GameObject>();
        enemyScript.SetupEnemy(nivel);

        return enemyScript;
    }

    public Enemy_GameObject SpawnEnemy(Creatures creature, int nivel)
    {
        creatures.TryGetValue(creature, out GameObject creaturePrefab);

        Vector3 spawnPosition = Vector3.zero;
        int sorteioSpawnOrientation = Random.Range(0, 4);
        int sorteioSpawnNorthSouthPos = Random.Range(0, 27);
        int sorteioSpawnEastWestPos = Random.Range(0, 15);

        switch (sorteioSpawnOrientation)
        {
            case 0: spawnPosition = spawnsNorth[sorteioSpawnNorthSouthPos].position; break;
            case 1: spawnPosition = spawnsSouth[sorteioSpawnNorthSouthPos].position; break;
            case 2: spawnPosition = spawnsEast[sorteioSpawnEastWestPos].position; break;
            case 3: spawnPosition = spawnsWest[sorteioSpawnEastWestPos].position; break;
        }
        spawnPosition.z = 0f;

        // Instancia o inimigo primeiro
        GameObject spawnedEnemy = Instantiate(creaturePrefab, spawnPosition, Quaternion.identity);

        // Depois pega o script, inicia o inimigo.
        Enemy_GameObject enemyScript = spawnedEnemy.GetComponent<Enemy_GameObject>();
        enemyScript.SetupEnemy(nivel);

        return enemyScript;
    }

    public List<Enemy_GameObject> SpawnSiege(Creatures creature, int nivel)
    {
        creatures.TryGetValue(creature, out GameObject creaturePrefab);

        List<Enemy_GameObject> siegeMonsterList = new List<Enemy_GameObject>();

        // Iterar sobre os 84 (27 + 27 + 15 + 15) pontos de spawn
        for (int i = 0; i < 84; i += 2)
        {
            Transform[] spawnArray = null;

            if (i < 27)
                spawnArray = spawnsNorth;
            else if (i < 54)
                spawnArray = spawnsSouth;
            else if (i < 69)
                spawnArray = spawnsEast;
            else
                spawnArray = spawnsWest;

            Vector3 spawnPosition = spawnArray[i % spawnArray.Length].position;
            spawnPosition.z = 0f;

            GameObject spawnedEnemy = Instantiate(creaturePrefab, spawnPosition, Quaternion.identity);

            Enemy_GameObject enemyScript = spawnedEnemy.GetComponent<Enemy_GameObject>();
            enemyScript.SetupEnemy(nivel);
            if (enemyScript != null && enemyScript.monster != null)
            {
                enemyScript.isSiege = true;
            }

            siegeMonsterList.Add(enemyScript);
        }

        return siegeMonsterList;
    }

}
