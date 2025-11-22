using UnityEngine;

public class Icicle : Spell
{
    public Icicle() : base()
    {
        TypeSpell = SpellType.ACTIVE_ICICLE;
        SpellElement = Elemento.ICE;
        TypeTarget = TargetType.SINGLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Icicle;
        Name = LanguageManager.Get("Icicle Name");
        Descricao = LanguageManager.Get("Icicle Description");
        BaseDmg = 90;
        DamagePercentPerLevel = 2;
        BaseCooldown = 3f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 8;
        statusFreeze = true;
    }

    public override void Cast(Creature caster)
    {
        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.15f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    private void CastSpell()
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Icicle, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
