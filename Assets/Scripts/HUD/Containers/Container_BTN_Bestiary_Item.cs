using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container_BTN_Bestiary_Item : Panel
{
    // Painel Bestiário -> Que contem os subpaineis onde esse container será instanciado.
    private Panel_MainMenu_Bestiary Panel_Bestiary;

    // Objeto que vem por parametro da opção de bestiário selecionada
    private ThingData thingData;

    // Dicionários
    private Dictionary<Monster.MonsterType, Func<bool>> monsters;
    private Dictionary<Spell.SpellType, Func<bool>> spells;
    private Dictionary<Relic.RelicType, Func<bool>> relics;

    // Dados desse container/botão
    public Text TXT_ThisItem_Name;
    public Button this_Button;

    private void Awake()
    {
        this_Button.onClick.AddListener(() => This_Button_Action());
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        thingData = param1 as ThingData;
        Panel_Bestiary = param2 as Panel_MainMenu_Bestiary;

        // Inicia os dicionários
        InitializeMonstersDictionary();
        InitializeSpellsDictionary();
        InitializeRelicsDictionary();

        // Faz a checagem de qual "dado" está vindo por parâmetro, que foi armazenado na variável local 'thingData'.
        switch (thingData)
        {
            case Monster monster:
                TXT_ThisItem_Name.text = GetMonsterDisplayName(monster);
                break;
            case Relic relic:
                TXT_ThisItem_Name.text = GetRelicDisplayName(relic);
                break;
            case Spell spell:
                TXT_ThisItem_Name.text = GetSpellDisplayName(spell);
                break;
        }

    }

    private void InitializeMonstersDictionary()
    {
        // Inicializa o dicionário de Monsters
        monsters = new Dictionary<Monster.MonsterType, Func<bool>>()
        {
            { Monster.MonsterType.SKELETON, () => PlayerConfig.bestiarySkeletonUnlocked },
            { Monster.MonsterType.BAT, () => PlayerConfig.bestiaryBatUnlocked },
            { Monster.MonsterType.WOLF, () => PlayerConfig.bestiaryWolfUnlocked },
            { Monster.MonsterType.ZOMBIE, () => PlayerConfig.bestiaryZombieUnlocked },
            { Monster.MonsterType.DEADTREE, () => PlayerConfig.bestiaryDeadTreeUnlocked },
            { Monster.MonsterType.SPIDER, () => PlayerConfig.bestiarySpiderUnlocked },

            { Monster.MonsterType.SKELETON_BOSS, () => PlayerConfig.bestiarySkeletonBossUnlocked },
            { Monster.MonsterType.BAT_BOSS, () => PlayerConfig.bestiaryBatBossUnlocked },
            { Monster.MonsterType.WOLF_BOSS, () => PlayerConfig.bestiaryWolfBossUnlocked },
            { Monster.MonsterType.ZOMBIE_BOSS, () => PlayerConfig.bestiaryZombieBossUnlocked },
            { Monster.MonsterType.DEADTREE_BOSS, () => PlayerConfig.bestiaryDeadTreeBossUnlocked },

            { Monster.MonsterType.SNAKE, () => PlayerConfig.bestiarySnakeUnlocked },
            { Monster.MonsterType.MUMMY, () => PlayerConfig.bestiaryMummyUnlocked },
            { Monster.MonsterType.CAMELO, () => PlayerConfig.bestiaryCameloUnlocked },
            { Monster.MonsterType.CAIXAO, () => PlayerConfig.bestiaryCaixaoUnlocked },
            { Monster.MonsterType.DJINN, () => PlayerConfig.bestiaryDjinnUnlocked },

            { Monster.MonsterType.SNAKE_BOSS, () => PlayerConfig.bestiarySnakeBossUnlocked },
            { Monster.MonsterType.MUMMY_BOSS, () => PlayerConfig.bestiaryMummyBossUnlocked },
            { Monster.MonsterType.CAMELO_BOSS, () => PlayerConfig.bestiaryCameloBossUnlocked },
            { Monster.MonsterType.CAIXAO_BOSS, () => PlayerConfig.bestiaryCaixaoBossUnlocked },
            { Monster.MonsterType.DJINN_BOSS, () => PlayerConfig.bestiaryDjinnBossUnlocked },
        };
    }

    private void InitializeSpellsDictionary()
    {
        // Inicializa o dicionário de Spells
        spells = new Dictionary<Spell.SpellType, Func<bool>>()
        {
            // Kael Spells
            { Spell.SpellType.ACTIVE_SHURIKEN, () => PlayerConfig.bestiaryShurikenUnlocked },
            { Spell.SpellType.ACTIVE_ARROW, () => PlayerConfig.bestiaryArrowUnlocked },
            { Spell.SpellType.ACTIVE_PIERCEDAGGER, () => PlayerConfig.bestiaryPierceDaggerUnlocked },
            { Spell.SpellType.ACTIVE_RAINOFARROW, () => PlayerConfig.bestiaryRainOfArrowUnlocked },
            { Spell.SpellType.ACTIVE_THEEIGHTKUNAIS, () => PlayerConfig.bestiaryTheEightKunaisUnlocked },
            { Spell.SpellType.ACTIVE_MULTIPLESHOT, () => PlayerConfig.bestiaryMultipleShotUnlocked },
            { Spell.SpellType.ACTIVE_POISONKUNAI, () => PlayerConfig.bestiaryPoisonKunaiUnlocked },

            // Zephyr Spells
            { Spell.SpellType.ACTIVE_FIREBALL, () => PlayerConfig.bestiaryFireballUnlocked },
            { Spell.SpellType.ACTIVE_EXPLOSION, () => PlayerConfig.bestiaryExplosionUnlocked },
            { Spell.SpellType.ACTIVE_ICICLE, () => PlayerConfig.bestiaryIcicleUnlocked },
            { Spell.SpellType.ACTIVE_THUNDER, () => PlayerConfig.bestiaryThunderUnlocked },
            { Spell.SpellType.ACTIVE_THUNDERPULSE, () => PlayerConfig.bestiaryThunderPulseUnlocked },
            { Spell.SpellType.ACTIVE_THUNDERBALL, () => PlayerConfig.bestiaryThunderBallUnlocked },
            { Spell.SpellType.ACTIVE_THUNDERA, () => PlayerConfig.bestiaryThunderaUnlocked },
            { Spell.SpellType.ACTIVE_THUNDERBARRIER, () => PlayerConfig.bestiaryThunderBarrierUnlocked },
            { Spell.SpellType.ACTIVE_FIREELEMENTAL, () => PlayerConfig.bestiaryFireElementalUnlocked },
            { Spell.SpellType.ACTIVE_TORNADOFURY, () => PlayerConfig.bestiaryTornadoFuryUnlocked },
            { Spell.SpellType.ACTIVE_METEOR, () => PlayerConfig.bestiaryMeteorUnlocked },
            { Spell.SpellType.ACTIVE_IGNISARROW, () => PlayerConfig.bestiaryIgnisArrowUnlocked },

            // Broghar Spells
            { Spell.SpellType.ACTIVE_AXETHROW, () => PlayerConfig.bestiaryAxeThrowUnlocked },
            { Spell.SpellType.ACTIVE_TERREMOTO, () => PlayerConfig.bestiaryTerremotoUnlocked },
            { Spell.SpellType.ACTIVE_SHIELDTHROW, () => PlayerConfig.bestiaryShieldThrowUnlocked },
            { Spell.SpellType.ACTIVE_CYCLONE, () => PlayerConfig.bestiaryCycloneUnlocked },
            { Spell.SpellType.ACTIVE_CIRCULARCUTS, () => PlayerConfig.bestiaryCorteCircularUnlocked },

            // Passivas
            { Spell.SpellType.PASSIVE_GAUNTLET, () => PlayerConfig.bestiaryGauntletUnlocked },
            { Spell.SpellType.PASSIVE_BOOTS, () => PlayerConfig.bestiaryBootsUnlocked },
            { Spell.SpellType.PASSIVE_CLOCK, () => PlayerConfig.bestiaryClockUnlocked },
            { Spell.SpellType.PASSIVE_THEHAND, () => PlayerConfig.bestiaryHandUnlocked },
            { Spell.SpellType.PASSIVE_HEART, () => PlayerConfig.bestiaryHeartUnlocked },

            // Specials
            { Spell.SpellType.SPECIAL_REROLL, () => PlayerConfig.bestiaryRerolUnlocked },
        };
    }

    private void InitializeRelicsDictionary()
    {
        // Inicializa o dicionário de Relics
        relics = new Dictionary<Relic.RelicType, Func<bool>>()
        {
            { Relic.RelicType.SKELETON, () => PlayerConfig.bestiarySkeletonRelicUnlocked },
            { Relic.RelicType.BAT, () => PlayerConfig.bestiaryBatRelicUnlocked },
        };
    }

    private string GetMonsterDisplayName(Monster monster)
    {
        string displayName = monster.Name;
        bool unlocked = monsters.TryGetValue(monster.monsterType, out var unlockFunc) && unlockFunc();

        return unlocked ? $"{monster.ID} - {displayName}" : $"{monster.ID} - ????";
    }

    private string GetRelicDisplayName(Relic relic)
    {
        string displayName = relic.Name;
        bool unlocked = relics.TryGetValue(relic.relicType, out var unlockFunc) && unlockFunc();
        return unlocked ? $"{relic.ID} - {displayName}" : $"{relic.ID} - ????";
    }

    private string GetSpellDisplayName(Spell spell)
    {
        string displayName = spell.Name;
        bool unlocked = spells.TryGetValue(spell.TypeSpell, out var unlockFunc) && unlockFunc();
        return unlocked ? $"{spell.ID} - {displayName}" : $"{spell.ID} - ????";
    }

    private void This_Button_Action()
    {
        switch (thingData.Type)
        {
            case ThingData.DataType.MONSTER:
                // Pega as classes correta fazendo o cast.
                Monster monster = thingData as Monster;

                bool monsterUnlocked = monsters.TryGetValue(monster.monsterType, out var mUnlocked) && mUnlocked();
                if (!monsterUnlocked)
                {
                    BestiaryMonsterLocked(Panel_Bestiary.Panel_Monsters);
                    return;
                }

                // Seta os valores do painel.
                Panel_Bestiary.Panel_Monsters.TXT_KilledValue.text = monster.Killeds.ToString();
                Panel_Bestiary.Panel_Monsters.TXT_BestiaryMonsterHPValue.text = monster.Health.ToString("F0");
                Panel_Bestiary.Panel_Monsters.TXT_BestiaryMonsterSpeedValue.text = monster.Speed.ToString("F0");
                Panel_Bestiary.Panel_Monsters.TXT_BestiaryMonsterDescription.text = monster.Description;
                break;

            case ThingData.DataType.RELIC:
                // Pega as classes correta fazendo o cast.
                Relic relic = thingData as Relic;

                bool relicUnlocked = relics.TryGetValue(relic.relicType, out var rUnlocked) && rUnlocked();
                if (!relicUnlocked)
                {
                    BestiaryRelicLocked(Panel_Bestiary.Panel_Relics);
                    return;
                }

                // Seta os valores do painel.
                Panel_Bestiary.Panel_Relics.TXT_ClockCooldownRelicValue.text = relic.GetRelicDuracaoEfeito().ToString("F0") + "s";
                Panel_Bestiary.Panel_Relics.TXT_BestiaryRelicDescription.text = relic.Description;
                break;

            case ThingData.DataType.SPELL:
                // Pega as classes correta fazendo o cast.
                Spell spell = thingData as Spell;

                bool spellUnlocked = spells.TryGetValue(spell.TypeSpell, out var sUnlocked) && sUnlocked();
                if (!spellUnlocked)
                {
                    BestiarySpellLocked(Panel_Bestiary.Panel_Spells);
                    return;
                }

                // Seta os valores do painel.
                Panel_Bestiary.Panel_Spells.IMG_Spell.sprite = spell.SpriteIcon;
                Panel_Bestiary.Panel_Spells.TXT_Spell_Damage.text = spell.BaseDmg.ToString("F0");
                Panel_Bestiary.Panel_Spells.TXT_Spell_Description.text = spell.Descricao;
                Panel_Bestiary.Panel_Spells.TXT_Spell_Cooldown.text = spell.BaseCooldown.ToString();
                break;
        }
    }

    private void BestiaryMonsterLocked(Panel_MainMenu_Bestiary_Monsters panelMonsters)
    {
        panelMonsters.TXT_KilledValue.text = "??";
        panelMonsters.TXT_BestiaryMonsterHPValue.text = "??";
        panelMonsters.TXT_BestiaryMonsterSpeedValue.text = "??";
        panelMonsters.TXT_BestiaryMonsterDescription.text = "???";
    }

    private void BestiaryRelicLocked(Panel_MainMenu_Bestiary_Relics panelRelics)
    {
        panelRelics.TXT_ClockCooldownRelicValue.text = "????";
        panelRelics.TXT_BestiaryRelicDescription.text = "????";
    }

    private void BestiarySpellLocked(Panel_MainMenu_Bestiary_Spells panelSpells)
    {
        panelSpells.IMG_Spell.sprite = null;
        panelSpells.TXT_Spell_Type.text = "????";
        panelSpells.TXT_Spell_Damage.text = "????";
        panelSpells.TXT_Spell_Description.text = "????";
        panelSpells.TXT_Spell_Cooldown.text = "????";
    }
}
