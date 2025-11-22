using System.Collections.Generic;
using UnityEngine;

public class PrefabManager_Effects : MonoBehaviour
{
    public enum EffectType
    {
        Ice,
        Fire,
        Burn,
        Heal,
        Physical,
        Thunder,
        Poison,
        Eletrify,
        ConsumeEletrify,
        Freeze,
        ConsumeFreeze,
        Haste,
    }

    [Header("Condition Effect Prefabs")]
    public GameObject Effect_Condition_Burn;
    public GameObject Effect_Condition_Eletrify;
    public GameObject Effect_Condition_ConsumeEletrify;
    public GameObject Effect_Condition_Freeze;
    public GameObject Effect_Condition_ConsumeFreeze;
    public GameObject Effect_Condition_Haste;

    [Header("Damage Effect Prefabs")]
    public GameObject Effect_Condition_Heal;
    public GameObject Effect_DamageElement_Ice;
    public GameObject Effect_DamageElement_Fire;
    public GameObject Effect_DamageElement_Physical;
    public GameObject Effect_DamageElement_Thunder;
    public GameObject Effect_DamageElement_Poison;


    private Dictionary<EffectType, GameObject> effectPrefabs;

    void Awake()
    {
        effectPrefabs = new Dictionary<EffectType, GameObject>
        {
            { EffectType.Ice, Effect_DamageElement_Ice },
            { EffectType.Fire, Effect_DamageElement_Fire },
            { EffectType.Burn, Effect_Condition_Burn },
            { EffectType.Heal, Effect_Condition_Heal },
            { EffectType.Physical, Effect_DamageElement_Physical },
            { EffectType.Thunder, Effect_DamageElement_Thunder },
            { EffectType.Poison, Effect_DamageElement_Poison },
            { EffectType.Eletrify, Effect_Condition_Eletrify },
            { EffectType.ConsumeEletrify, Effect_Condition_ConsumeEletrify },
            { EffectType.Freeze, Effect_Condition_Freeze },
            { EffectType.ConsumeFreeze, Effect_Condition_ConsumeFreeze },
            { EffectType.Haste, Effect_Condition_Haste }

        };
    }

    public GameObject GetEffectPrefab(EffectType type)
    {
        if (effectPrefabs.TryGetValue(type, out GameObject prefab))
        {
            return prefab;
        }

        return null;
    }
}
