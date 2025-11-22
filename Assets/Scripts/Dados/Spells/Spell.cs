using System;
using System.Linq;
using UnityEngine;

public class Spell : ThingData
{

    // =========================
    // REGISTRO GLOBAL DE SPELLS
    // =========================
    private static int _nextID = 0;
    public static Spell GetByID(int id) => SpellsList.AllSpells.FirstOrDefault(s => s.ID == id);

    // Rastreamento de Cast
    public event Action OnSpellCast;

    public enum SpellType
    {
        // Kael Active Spells
        ACTIVE_SHURIKEN,
        ACTIVE_ARROW,
        ACTIVE_PIERCEDAGGER,
        ACTIVE_RAINOFARROW,
        ACTIVE_THEEIGHTKUNAIS,
        ACTIVE_MULTIPLESHOT,
        ACTIVE_POISONKUNAI,
        ACTIVE_AGILITY,
        ACTIVE_EXPLOSIVEARROW,
        ACTIVE_SCATTERARROW,

        // Zephyr Active Spells
        ACTIVE_FIREBALL,
        ACTIVE_EXPLOSION,
        ACTIVE_ICICLE,
        ACTIVE_BLIZZARD,
        ACTIVE_ICETOTEM,
        ACTIVE_THUNDER,
        ACTIVE_THUNDERPULSE,
        ACTIVE_THUNDERBALL,
        ACTIVE_THUNDERA,
        ACTIVE_THUNDERBARRIER,
        ACTIVE_FIREELEMENTAL,
        ACTIVE_TORNADOFURY,
        ACTIVE_METEOR,
        ACTIVE_IGNISARROW,

        // Brogar Active Spells
        ACTIVE_AXETHROW,
        ACTIVE_TERREMOTO,
        ACTIVE_SHIELDTHROW,
        ACTIVE_CYCLONE,
        ACTIVE_CIRCULARCUTS,

        // Fire Elemental Spells
        FIREELEMENTAL_ACTIVE_FAGULHADEFOGO,
        FIREELEMENTAL_ACTIVE_EXPLOSION,
        FIRELEMENTAL_ACTIVE_FIREBALL,
        FIREELEMENTAL_ACTIVE_METEOR,

        // Passivas
        PASSIVE_GAUNTLET,
        PASSIVE_BOOTS,
        PASSIVE_CLOCK,
        PASSIVE_THEHAND,
        PASSIVE_HEART,

        // ESPECIAIS
        SPECIAL_MONEY,
        SPECIAL_REROLL,
    }

    public enum Elemento
    {
        PASSIVE,
        PHYSICAL,
        DISTANCE,
        FIRE,
        ICE,
        THUNDER,
        POISON
    }

    public enum TargetType
    {
        SINGLE,
        MULTIPLE
    }

    public enum CombatType
    {
        DAMAGE,
        HEALING,
        PROTECTION,
        SUMMON,
    }

    // Dados Básicos
    public Creature Caster { get; set; }
    public override DataType Type => DataType.SPELL;
    public int ID { get; set; }
    public SpellType TypeSpell { get; set; }
    public Elemento SpellElement {  get; set; } // Fire, ice, thunder...
    public TargetType TypeTarget { get; set; }  // "AoE", "Passive", "Target" etc..
    public CombatType TypeCombat {  get; set; } // Dmg, Healing, Protection, Summon...
    public Sprite SpriteIcon { get; set; }

    // Dados para Bestiário / HUD
    public string Name { get; set; }
    public string Descricao { get; set; }

    // Valores
    public float BaseDmg { get; set; }  // Dano Base
    public float DamagePercentPerLevel { get; set; } // Dano que aumenta da base por nível
    public float BaseCooldown { get; set; } = 0;
    public float RealCooldown { get; protected set; }
    public float PoderImpulsao { get; set; }
    public int JumpQuantity { get; set; } // Quantidade de alvos que a skill "Pula"
    public int MaxRecasts { get; set; } // Limite de vezes que a magia vai entrar em recast
    public int SpellLevel { get; set; }
    public int LevelMax { get; set; }

    // Spell Conditions
    public bool statusPoison { get; set; }
    public bool statusFreeze { get; set; }
    public bool consumeFreeze { get; set; }
    public bool statusBurn { get; set; }
    public bool statusEletrify { get; set; }
    public bool consumeEletrify { get; set; }

    // Booleans Controle
    public bool isLevelMax => SpellLevel >= LevelMax;
    public bool isReady => RealCooldown <= 0;


    // Construtor para a classe SpellList
    protected Spell()
    {
        ID = _nextID++;
        SpellsList.AllSpells.Add(this);
    }

    public virtual void Cast(Creature caster) 
    {
        // Escuta global da spell
        OnSpellCast?.Invoke();
    }

    public virtual void ResetSpell() 
    {
        foreach (Spell spell in SpellsList.AllSpells)
        {
            if (spell == HeroImage.active1)
            {
                spell.SpellLevel = 1;
            }
            else
            {
                spell.SpellLevel = 0;
            }
        }
    }

    public void DoCooldown()
    {
        RealCooldown -= Time.deltaTime;
    }

    public int GetSpellLevel()
    {
        return SpellLevel;
    }

    public void AddSpellLevel()
    {
        SpellLevel++;
    }

    public float GetSpellCooldown()
    {
        float cooldownReduction = HeroImage.GetHeroCooldownReduction(); // valor de 0 a 100
        float finalCooldown = BaseCooldown * (1 - cooldownReduction / 100f);
        return finalCooldown;
    }


    public float GetSpellDamage()
    {
        Hero_GameObject hero = GameManager.Instance.playerHero;

        float heroDamageBonus = HeroImage.GetHeroDamageBoost();
        float heroTalentBonus = 0f;

        // Bônus de talento conforme o elemento
        switch (SpellElement)
        {
            case Elemento.PHYSICAL:
                heroTalentBonus = hero.heroTalents.BrutamontesLevel * Hero_Talents.BRUTAMONTES_BASE_BUFF;
                break;

            case Elemento.DISTANCE:
                heroTalentBonus = hero.heroTalents.AtiradorEliteLevel * Hero_Talents.ATIRADOR_ELITE_BASE_BUFF;
                break;

            case Elemento.FIRE:
                heroTalentBonus = hero.heroTalents.PiromaniacoLevel * Hero_Talents.PIROMANIACO_BASE_BUFF;
                break;

            case Elemento.ICE:
                heroTalentBonus = hero.heroTalents.ToqueCongelanteLevel * Hero_Talents.TOQUE_CONGELANTE_BASE_BUFF;
                break;

            case Elemento.THUNDER:
                heroTalentBonus = hero.heroTalents.TeslaLevel * Hero_Talents.TESLA_BASE_BUFF;
                Debug.Log("Bonus de multiplicador de dano: " + heroTalentBonus);
                break;

            case Elemento.POISON:
                heroTalentBonus = (hero.heroTalents.PestilentoLevel * Hero_Talents.PESTILENTO_BASE_BUFF) / 100f;
                break;
        }

        float totalBonus = heroDamageBonus + heroTalentBonus;

        // Retorna o dano final
        return BaseDmg * (1f + totalBonus / 100f) * (1f + GetDamagePerLevel() / 100);
    }

    public virtual float GetDamagePerLevel() 
    {
        if (SpellLevel <= MaxRecasts)
            return 0;

        return (SpellLevel - MaxRecasts) * DamagePercentPerLevel;
    }

    public float GetSpellImpulsion()
    {
        return PoderImpulsao;
    }

    protected int CalculateTimesToCast()
    {
        int timesToCast = 0;

        if (SpellLevel > 0 && SpellLevel <= MaxRecasts)
        {
            timesToCast = SpellLevel;
            return timesToCast;
        }

        timesToCast = MaxRecasts;
        return timesToCast;
    }
}
