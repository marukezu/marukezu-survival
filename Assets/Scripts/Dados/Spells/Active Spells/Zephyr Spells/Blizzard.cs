using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Spell;

public class Blizzard : Spell
{
    public Blizzard() : base()
    {
        TypeSpell = SpellType.ACTIVE_BLIZZARD;
        SpellElement = Elemento.ICE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Blizzard;
        Name = LanguageManager.Get("Blizzard Name");
        Descricao = LanguageManager.Get("Blizzard Description");
        BaseDmg = 35f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 2.25f;
        PoderImpulsao = 0.25f;
        LevelMax = 999;
        MaxRecasts = 8;
        statusFreeze = true;
    }

    public override void Cast(Creature caster)
    {
        base.Cast(caster);

        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.25f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    public void CastSpell()
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Blizzard, Caster.transform);
        spellPrefab.GetComponentInChildren<Stationary>().spell = this;
    }
}
