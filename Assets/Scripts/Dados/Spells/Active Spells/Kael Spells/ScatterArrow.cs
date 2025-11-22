using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterArrow : Spell
{
    public ScatterArrow() : base()
    {
        TypeSpell = SpellType.ACTIVE_SCATTERARROW;
        SpellElement = Elemento.DISTANCE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_ScatterArrow;
        Name = LanguageManager.Get("Scatter Arrow Name");
        Descricao = LanguageManager.Get("Scatter Arrow Description");
        BaseDmg = 75;
        DamagePercentPerLevel = 2;
        BaseCooldown = 4f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 6;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.ScatterArrow, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
