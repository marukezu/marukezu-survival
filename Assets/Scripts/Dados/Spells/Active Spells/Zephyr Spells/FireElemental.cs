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
        Name = LanguageManager.Get("Fire Elemental Name");
        BaseDmg = 0f;
        BaseCooldown = 99999f;
        PoderImpulsao = 0f;
        LevelMax = 1;
        Descricao = LanguageManager.Get("Fire Elemental Description");
    }

    public override void Cast(Creature caster)
    {
        // Armazena o Caster.
        Caster = caster;

        // Summon Fire Elemental
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.FireElemental, Caster.transform);

        RealCooldown = GetSpellCooldown();
    }
}
