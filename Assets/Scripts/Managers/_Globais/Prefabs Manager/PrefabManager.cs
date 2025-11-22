using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance;

    public PrefabManager_Itens itensManager;
    public PrefabManager_Creatures creatureManager;
    public PrefabManager_Spells spellsManager;
    public PrefabManager_Effects effectsManager;
    public PrefabManager_Potions potionsManager;

    [Header("====== HUD Objects ======")]
    public GameObject damageText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Creatures
    public GameObject InstantiateCreaturePrefab(PrefabManager_Creatures.CreatureType creature, Transform local)
    {
        GameObject prefab = creatureManager.GetCreaturePrefab(creature);
        if (prefab != null)
        {
            return Instantiate(prefab, local.position, Quaternion.identity);
        }

        return null;
    }
    public GameObject GetMonsterPrefab(PrefabManager_Creatures.CreatureType monster)
    {
        GameObject prefab = creatureManager.GetCreaturePrefab(monster);
        if (prefab != null)
        {
            return prefab;
        }

        return null;
    }

    // Spells
    public GameObject InstantiateSpellPrefab(PrefabManager_Spells.SpellType spell, Transform local)
    {
        GameObject prefab = spellsManager.GetSpellPrefab(spell);
        if (prefab != null)
        {
            return Instantiate(prefab, local.position, Quaternion.identity);
        }

        return null;
    }

    // Effects
    public GameObject InstantiateEffectPrefab(PrefabManager_Effects.EffectType effect, Transform local)
    {
        GameObject prefab = effectsManager.GetEffectPrefab(effect);
        if (prefab != null)
        {
            return Instantiate(prefab, local.position, Quaternion.identity);
        }

        return null;
    }
    public GameObject GetEffectPrefab(PrefabManager_Effects.EffectType effect)
    {
        GameObject prefab = effectsManager.GetEffectPrefab(effect);
        if (prefab != null)
        {
            return prefab;
        }

        return null;
    }

    // Itens
    public GameObject InstantiateItemPrefab(PrefabManager_Itens.ItemType item, Transform local)
    {
        GameObject prefab = itensManager.GetItemPrefab(item);
        if (prefab != null)
        {
            return Instantiate(prefab, local.position, Quaternion.identity);
        }

        return null;
    }
    public GameObject GetItemPrefab(PrefabManager_Itens.ItemType item)
    {
        GameObject prefab = itensManager.GetItemPrefab(item);
        if (prefab != null)
        {
            return prefab;
        }

        return null;
    }
}
