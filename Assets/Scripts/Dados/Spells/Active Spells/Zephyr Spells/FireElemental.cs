using System.Collections.Generic;
using UnityEngine;

public class FireElemental : Spell
{
    public FireElemental() : base()
    {
        TypeSpell = SpellType.ACTIVE_FIREELEMENTAL;
        SpellElement = Elemento.FIRE;
        TypeTarget = TargetType.SINGLE;
        TypeCombat = CombatType.SUMMON;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_FireElemental;
        Name = LanguageManager.Get(LanguageTexts_Spells.SpellWords.FireElemental_Name);
        BaseDmg = 0f;
        BaseCooldown = 0f;
        PoderImpulsao = 0f;
        LevelMax = 1;
        MaxSummon = 1;
        Descricao = LanguageManager.Get(LanguageTexts_Spells.SpellWords.FireElemental_Desc);
    }

    public override void Cast(Creature caster)
    {
        // Verifica se já tem o máximo de summons permitido.
        if (HeroImage_Summons.fireElemental_Quantity >= MaxSummon)
            return;

        // Armazena o Caster.
        Caster = caster;

        // Summon Fire Elemental
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.FireElemental, Caster.transform);

        // Contabiliza o summon ao HeroImage
        HeroImage_Summons.fireElemental_Quantity++;

        RealCooldown = GetSpellCooldown();
    }
}
