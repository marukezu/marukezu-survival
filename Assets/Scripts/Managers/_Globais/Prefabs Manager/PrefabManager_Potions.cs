using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager_Potions : MonoBehaviour
{
    [Header("Effect Prefabs")]
    public GameObject Potion_Explosion;
    public GameObject Potion_Restoration;

    private Dictionary<Potion.PotionType, GameObject> prefabs;

    void Awake()
    {
        prefabs = new Dictionary<Potion.PotionType, GameObject>
        {
            { Potion.PotionType.Explosive, Potion_Explosion },
            { Potion.PotionType.Restoration, Potion_Restoration },

        };
    }

    public GameObject GetPrefab(Potion.PotionType type)
    {
        if (prefabs.TryGetValue(type, out GameObject prefab))
        {
            return prefab;
        }

        return null;
    }

    public GameObject InstantiatePrefab(Potion.PotionType type, Transform local)
    {
        if (prefabs.TryGetValue(type, out GameObject prefab))
        {
            return Instantiate(prefab, local.position, Quaternion.identity);
        }

        return null;
    }
}
