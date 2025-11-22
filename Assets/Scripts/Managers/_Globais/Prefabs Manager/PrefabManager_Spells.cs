using System.Collections.Generic;
using UnityEngine;

public class PrefabManager_Spells : MonoBehaviour
{
    public enum SpellType
    {
        // Zephyr
        Icicle,
        Thunder,
        Fireball,
        TornadoFury,
        Blizzard,
        IceTotem,
        IceExplosion,
        IgnisArrow,
        Meteor,
        ThunderPulse,
        Explosion,
        FireElemental,
        ThunderBall,
        ThunderBolt,
        Thundera,
        ThunderBarrier,

        // Fire elemental
        Summon_FireSpark,

        // Kael
        Shuriken,
        PierceDagger,
        TheEightKunais,
        PoisonKunai,
        Arrow,
        MultipleShot,
        RainOfArrow_Cast,
        RainOfArrow_Falling,
        ExplosiveArrow,
        ScatterArrow,
    }

    [Header("====== Zephyr Spells ======")]
    public GameObject IciclePrefab;
    public GameObject ThunderPrefab;
    public GameObject FireballPrefab;
    public GameObject TornadoFuryPrefab;
    public GameObject BlizzardPrefab;
    public GameObject IceTotemPrefab;
    public GameObject IceExplosionPrefab;
    public GameObject IgnisArrowPrefab;
    public GameObject MeteorPrefab;
    public GameObject ThunderPulsePrefab;
    public GameObject ExplosionPrefab;
    public GameObject FireElementalPrefab;
    public GameObject ThunderBallPrefab;
    public GameObject ThunderBoltPrefab;
    public GameObject ThunderaPrefab;
    public GameObject ThunderBarrierPrefab;

    [Header("====== Fire Elemental Spells ======")]
    public GameObject Summon_FireSparkPrefab;

    [Header("====== Kael Spells ======")]
    public GameObject ShurikenPrefab;
    public GameObject PierceDaggerPrefab;
    public GameObject TheEightKunaisPrefab;
    public GameObject PoisonKunaiPrefab;
    public GameObject ArrowPrefab;
    public GameObject MultipleShotPrefab;
    public GameObject RainOfArrow_CastPrefab;
    public GameObject RainOfArrow_FallingPrefab;
    public GameObject ExplosiveArrowPrefab;
    public GameObject ScatterArrowPrefab;

    private Dictionary<SpellType, GameObject> spellPrefabs;

    void Awake()
    {
        // Inicializa o dicionário
        spellPrefabs = new Dictionary<SpellType, GameObject>
        {
            // Zephyr
            { SpellType.Icicle, IciclePrefab },
            { SpellType.Thunder, ThunderPrefab },
            { SpellType.Fireball, FireballPrefab },
            { SpellType.TornadoFury, TornadoFuryPrefab },
            { SpellType.Blizzard, BlizzardPrefab },
            { SpellType.IceTotem, IceTotemPrefab },
            { SpellType.IceExplosion, IceExplosionPrefab },
            { SpellType.IgnisArrow, IgnisArrowPrefab },
            { SpellType.Meteor, MeteorPrefab },
            { SpellType.ThunderPulse, ThunderPulsePrefab },
            { SpellType.Explosion, ExplosionPrefab },
            { SpellType.FireElemental, FireElementalPrefab },
            { SpellType.ThunderBall, ThunderBallPrefab },
            { SpellType.ThunderBolt, ThunderBoltPrefab },
            { SpellType.Thundera, ThunderaPrefab },
            { SpellType.ThunderBarrier, ThunderBarrierPrefab },

            // Fire Elemental
            { SpellType.Summon_FireSpark, Summon_FireSparkPrefab },

            // Kael
            { SpellType.Shuriken, ShurikenPrefab },
            { SpellType.PierceDagger, PierceDaggerPrefab },
            { SpellType.TheEightKunais, TheEightKunaisPrefab },
            { SpellType.PoisonKunai, PoisonKunaiPrefab },
            { SpellType.Arrow, ArrowPrefab },
            { SpellType.MultipleShot, MultipleShotPrefab },
            { SpellType.RainOfArrow_Cast, RainOfArrow_CastPrefab },
            { SpellType.RainOfArrow_Falling, RainOfArrow_FallingPrefab },
            { SpellType.ExplosiveArrow, ExplosiveArrowPrefab },
            { SpellType.ScatterArrow, ScatterArrowPrefab },
        };
    }

    public GameObject GetSpellPrefab(SpellType type)
    {
        if (spellPrefabs.TryGetValue(type, out GameObject prefab))
        {
            return prefab;
        }

        return null;
    }
}
