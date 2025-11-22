using UnityEngine;

public class IgnisArrow : Spell
{
    public IgnisArrow() : base()
    { 
        TypeSpell = SpellType.ACTIVE_IGNISARROW;
        SpellElement = Elemento.FIRE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_IgnisArrow;
        Name = LanguageManager.Get("Ignis Arrow Name");
        Descricao = LanguageManager.Get("Ignis Arrow Description");
        BaseDmg = 45f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 3f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 7;
        statusBurn = true;
    }

    public override void Cast(Creature caster)
    {
        base.Cast(caster);

        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.15f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    public void CastSpell()
    {        
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.IgnisArrow, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
