using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agility : Spell
{
    public Agility() : base()
    {
        TypeSpell = SpellType.ACTIVE_AGILITY;
        SpellElement = Elemento.PHYSICAL;
        TypeTarget = TargetType.SINGLE;
        TypeCombat = CombatType.PROTECTION;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Agility;
        Name = LanguageManager.Get(LanguageTexts_Spells.SpellWords.Agility_Name);
        Descricao = LanguageManager.Get(LanguageTexts_Spells.SpellWords.Agility_Desc);
        BaseDmg = 2f;
        BaseCooldown = 7f;
        PoderImpulsao = 0f;
        LevelMax = 1;
    }

    public override void Cast(Creature caster)
    {
        // Armazena o Caster.
        Caster = caster;

        // Adiciona a condition de proteção
        Condition condHasted = new Condition(Condition.ConditionType.Haste, 0, BaseDmg);
        GameManager.Instance.playerHero.heroConditions.AddCondition(condHasted);

        RealCooldown = GetSpellCooldown();
    }
}
