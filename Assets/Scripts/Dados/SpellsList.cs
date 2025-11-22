using System.Collections.Generic;
using UnityEngine;

public static class SpellsList
{
    // =============
    // Lista de Spells
    public static List<Spell> AllSpells { get; set; } = new List<Spell>();

    // =============
    // ZEPHYR

    // ZEPHYR - Fire Type
    public static FireBall Fireball = new FireBall();
    public static Explosao Explosao = new Explosao();
    public static FireElemental FireElemental = new FireElemental();
    public static IgnisArrow IgnisArrow = new IgnisArrow();
    public static Meteor Meteor = new Meteor();

    // ZEPHYR - Ice Type
    public static Icicle Icicle = new Icicle();
    public static TornadoFury TornadoFury = new TornadoFury();
    public static Blizzard Blizzard = new Blizzard();
    public static IceTotem IceTotem = new IceTotem();

    // ZEPHYR - Thunder Type
    public static Thunder Thunder = new Thunder();
    public static ThunderPulse ThunderPulse = new ThunderPulse();
    public static ThunderBall ThunderBall = new ThunderBall();
    public static Thundera Thundera = new Thundera();
    public static ThunderBarrier ThunderBarrier = new ThunderBarrier();

    // =============
    // KAEL

    // KAEL - Physical Closed Range
    public static Shuriken Shuriken = new Shuriken();
    public static PierceDagger PierceDagger = new PierceDagger();
    public static TheEightKunais TheEightKunais = new TheEightKunais();
    public static PoisonKunai PoisonKunai = new PoisonKunai();
    public static Agility Agility = new Agility();

    // KAEL - Physical Distance Range
    public static MultipleShot MultipleShot = new MultipleShot();
    public static Arrow Arrow = new Arrow();
    public static RainOfArrow RainOfArrow = new RainOfArrow();
    public static ExplosiveArrow ExplosiveArrow = new ExplosiveArrow();
    public static ScatterArrow ScatterArrow = new ScatterArrow();

    // =============
    // BROGHAR
    public static AxeThrow AxeThrow = new AxeThrow();
    public static Terremoto Terremoto = new Terremoto();
    public static ShieldThrow ShieldThrow = new ShieldThrow();
    public static Cyclone Cyclone = new Cyclone();
    public static CircularCuts CircularCuts = new CircularCuts();

    // =============
    // Fire Elemental
    public static FireElemental_FireSpark FireElemental_FagulhaDeFogo = new FireElemental_FireSpark();
    public static FireElemental_FireBall FireElemental_FireBall = new FireElemental_FireBall();
    public static FireElemental_Explosion FireElemental_Explosion = new FireElemental_Explosion();
    public static FireElemental_Meteor FireElemental_Meteor = new FireElemental_Meteor();

    public static List<Spell> ZephyrSpells = new List<Spell>()
    {
        // Fire
        Fireball, Explosao, FireElemental, IgnisArrow, Meteor,

        // Thunder
        Thunder, ThunderBall, Thundera, ThunderPulse, ThunderBarrier,

        // Ice
        Icicle, TornadoFury, IceTotem, Blizzard,
    };

    public static List<Spell> KaelSpells = new List<Spell>()
    {
        // Physical Closed Range
        Shuriken, PierceDagger, TheEightKunais, PoisonKunai, Agility,        

        // Physical Distance Range
        Arrow, MultipleShot, RainOfArrow, ExplosiveArrow,
    };

    public static List<Spell> BrogharSpells = new List<Spell>()
    {

    };

    public static void UnlockSpellBestiary(Spell.SpellType spell)
    {
        switch (spell)
        {
            // Magias ativas
            case Spell.SpellType.ACTIVE_SHURIKEN: PlayerConfig.bestiaryShurikenUnlocked = true; break;
            case Spell.SpellType.ACTIVE_ARROW: PlayerConfig.bestiaryArrowUnlocked = true; break;
            case Spell.SpellType.ACTIVE_FIREBALL: PlayerConfig.bestiaryFireballUnlocked = true; break;
            case Spell.SpellType.ACTIVE_EXPLOSION: PlayerConfig.bestiaryExplosionUnlocked = true; break;
            case Spell.SpellType.ACTIVE_ICICLE: PlayerConfig.bestiaryIcicleUnlocked = true; break;
            case Spell.SpellType.ACTIVE_THUNDER: PlayerConfig.bestiaryThunderUnlocked = true; break;
            case Spell.SpellType.ACTIVE_THUNDERBALL: PlayerConfig.bestiaryThunderBallUnlocked = true; break;
            case Spell.SpellType.ACTIVE_THUNDERA: PlayerConfig.bestiaryThunderaUnlocked = true; break;
            case Spell.SpellType.ACTIVE_THUNDERBARRIER: PlayerConfig.bestiaryThunderBarrierUnlocked = true; break;
            case Spell.SpellType.ACTIVE_AXETHROW: PlayerConfig.bestiaryAxeThrowUnlocked = true; break;
            case Spell.SpellType.ACTIVE_PIERCEDAGGER: PlayerConfig.bestiaryPierceDaggerUnlocked = true; break;
            case Spell.SpellType.ACTIVE_CIRCULARCUTS: PlayerConfig.bestiaryCorteCircularUnlocked = true; break;
            case Spell.SpellType.ACTIVE_THUNDERPULSE: PlayerConfig.bestiaryThunderPulseUnlocked = true; break;
            case Spell.SpellType.ACTIVE_FIREELEMENTAL: PlayerConfig.bestiaryFireElementalUnlocked = true; break;
            case Spell.SpellType.ACTIVE_TORNADOFURY: PlayerConfig.bestiaryTornadoFuryUnlocked = true; break;
            case Spell.SpellType.ACTIVE_METEOR: PlayerConfig.bestiaryMeteorUnlocked = true; break;
            case Spell.SpellType.ACTIVE_IGNISARROW: PlayerConfig.bestiaryIgnisArrowUnlocked = true; break;
            case Spell.SpellType.ACTIVE_RAINOFARROW: PlayerConfig.bestiaryRainOfArrowUnlocked = true; break;
            case Spell.SpellType.ACTIVE_THEEIGHTKUNAIS: PlayerConfig.bestiaryTheEightKunaisUnlocked = true; break;
            case Spell.SpellType.ACTIVE_MULTIPLESHOT: PlayerConfig.bestiaryMultipleShotUnlocked = true; break;
            case Spell.SpellType.ACTIVE_POISONKUNAI: PlayerConfig.bestiaryPoisonKunaiUnlocked = true; break;
            case Spell.SpellType.ACTIVE_TERREMOTO: PlayerConfig.bestiaryTerremotoUnlocked = true; break;
            case Spell.SpellType.ACTIVE_SHIELDTHROW: PlayerConfig.bestiaryShieldThrowUnlocked = true; break;

            // Magias passivas
            case Spell.SpellType.PASSIVE_GAUNTLET: PlayerConfig.bestiaryGauntletUnlocked = true; break;
            case Spell.SpellType.PASSIVE_CLOCK: PlayerConfig.bestiaryClockUnlocked = true; break;
            case Spell.SpellType.PASSIVE_BOOTS: PlayerConfig.bestiaryBootsUnlocked = true; break;
            case Spell.SpellType.PASSIVE_THEHAND: PlayerConfig.bestiaryHandUnlocked = true; break;
            case Spell.SpellType.PASSIVE_HEART: PlayerConfig.bestiaryHeartUnlocked = true; break;

            default: break;
        }
    }
}
