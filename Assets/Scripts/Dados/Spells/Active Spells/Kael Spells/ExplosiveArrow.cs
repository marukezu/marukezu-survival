using UnityEngine;

public class ExplosiveArrow : Spell
{
    public ExplosiveArrow() : base()
    {
        TypeSpell = SpellType.ACTIVE_EXPLOSIVEARROW;
        SpellElement = Elemento.DISTANCE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_ExplosiveArrow;
        Name = LanguageManager.Get("Explosive Arrow Name");
        Descricao = LanguageManager.Get("Explosive Arrow Description");
        BaseDmg = 75;
        DamagePercentPerLevel = 2;
        BaseCooldown = 4f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 6;
        statusBurn = true;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.ExplosiveArrow, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
