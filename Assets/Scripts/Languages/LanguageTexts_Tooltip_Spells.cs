using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LanguageTexts_Events;
using static LanguageTexts_Heroes;

public class LanguageTexts_Tooltip_Spells : MonoBehaviour
{
    public enum TooltipWords
    {
        // Container Texts
        SpellInfo,
        SpellConditions,

        // SubPanel - Spell Name/Element
        ElementPhysical,
        ElementDistance,
        ElementFire,
        ElementIce,
        ElementThunder,
        ElementPoison,

        // SubPanel - Spell Info
        CombatType_Damage,
        CombatType_Protection,
        CombatType_Summon,
        Cooldown_Normal,
        Cooldown_Unique,
        MaxProjectiles_Damage,
        MaxProjectiles_Protection,
        MaxProjectiles_Summon,

        // SubPanel - Spell Conditions
        ConditionNoneDesc,
        ConditionBurnDesc,
        ConditionFreezeDesc,
        ConditionEletrifyDesc,
        ConditionConsumeEletrifyDesc,
        ConditionPoison,
    }

    public static readonly LangEntry<TooltipWords>[] Entries =
    {
        // Container Texts
        new(TooltipWords.SpellInfo,
            "Informação do Feitiço", 
            "Spell Info"),
        new(TooltipWords.SpellConditions,
            "Condições do Feitiço",
            "Spell Conditions"),

        // SubPanel - Spell Name/Element
        new(TooltipWords.ElementPhysical,
            "Elemento Físico",
            "Physical Element"),

        new(TooltipWords.ElementDistance,
            "Elemento Distância",
            "Distance Element"),

        new(TooltipWords.ElementFire,
            "Elemento Fogo",
            "Fire Element"),

        new(TooltipWords.ElementIce,
            "Elemento Gelo",
            "Ice Element"),

        new(TooltipWords.ElementThunder,
            "Elemento Elétrico",
            "Thunder Element"),

        new(TooltipWords.ElementPoison,
            "Elemento Veneno",
            "Poison Element"),

        // SubPanel - Spell Info
        new(TooltipWords.CombatType_Damage,
            "Dano base do feitiço",
            "Spell base damage"),
        new(TooltipWords.CombatType_Protection,
            "Tempo de duração da proteção",
            "Protection duration time"),
        new(TooltipWords.CombatType_Summon,
            "Tempo de duração do summon",
            "Summon duration time"),
        new(TooltipWords.Cooldown_Normal,
            "Intervalo de lançamento",
            "Cast Interval"),
        new(TooltipWords.Cooldown_Unique,
            "<color=#FFD54F>Conjuração única</color>",
            "<color=#FFD54F>Unique conjuration</color>"),
        new(TooltipWords.MaxProjectiles_Damage,
            "+1 projétil por nível\n<color=#FFD54F>Máx:</color> ",
            "+1 projectile per level\n<color=#FFD54F>Max:</color> "),
        new(TooltipWords.MaxProjectiles_Protection,
            "Não possui projétil",
            "No projectile"),
        new(TooltipWords.MaxProjectiles_Summon,
            "+1 invocação por nível\n<color=#FFD54F>Máx:</color> ",
            "+1 summon per level\n<color=#FFD54F>Max:</color> "),

        // SubPanel - Spell Conditions
        new(TooltipWords.ConditionNoneDesc,
            "Nenhuma condição aplicada",
            "No conditions applied"),
        new(TooltipWords.ConditionBurnDesc,
            "Causa queimadura ao contato",
            "Causes burning on contact"),
        new(TooltipWords.ConditionFreezeDesc,
            "Reduz vel. movimento ao contato",
            "Reduces speed of mov. on contact"),
        new(TooltipWords.ConditionEletrifyDesc,
            "Eletrifica ao contato, alguns feitiços consomem essa condição para causar grande dano",
            "Electrifies on contact; some spells consume this condition to cause significant damage"),
        new(TooltipWords.ConditionConsumeEletrifyDesc,
            "Consome 'Eletrificado', causando grande dano",
            "Consumes 'Eletrify' causing great damage"),
        new(TooltipWords.ConditionPoison,
            "Causa envenenamento ao contato",
            "Causes poison on contact"),
    };
}
