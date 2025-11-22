using System.Collections.Generic;
using UnityEngine;

public class PrefabManager_Itens : MonoBehaviour
{
    public enum ItemType
    {
        // Exp Orbs
        OrangeExpOrb,
        PurpleExpOrb,
        RedExpOrb,

        // Relics
        SkeletonRelic,
        BatRelic,

        // Bau
        BauRecompensa,
    }

    [Header("====== Exp Orbs ======")]
    public GameObject orangeExpOrb;
    public GameObject purpleExpOrb;
    public GameObject redExpOrb;

    [Header("====== Relics ======")]
    public GameObject skeletonRelic;
    public GameObject batRelic;

    [Header("====== Bau ======")]
    public GameObject bauRecompensa;

    private Dictionary<ItemType, GameObject> itemPrefabs;

    void Awake()
    {
        itemPrefabs = new Dictionary<ItemType, GameObject>
        {
            // Exp Orbs
            { ItemType.OrangeExpOrb, orangeExpOrb },
            { ItemType.PurpleExpOrb, purpleExpOrb },
            { ItemType.RedExpOrb, redExpOrb },

            // Relics
            { ItemType.SkeletonRelic, skeletonRelic },
            { ItemType.BatRelic, batRelic },

            // Bau Recompensa            
            { ItemType.BauRecompensa, bauRecompensa }
        };
    }

    public GameObject GetItemPrefab(ItemType type)
    {
        if (itemPrefabs.TryGetValue(type, out GameObject prefab))
        {
            return prefab;
        }

        return null;
    }
}
