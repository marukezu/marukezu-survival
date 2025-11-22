using UnityEngine;

public class PierceDagger : Spell
{
    public PierceDagger() : base()
    {
        TypeSpell = SpellType.ACTIVE_PIERCEDAGGER;
        SpellElement = Elemento.PHYSICAL;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_PierceDagger;
        Name = LanguageManager.Get("Pierce Dagger Name");
        Descricao = LanguageManager.Get("Pierce Dagger Description");
        BaseDmg = 90;
        DamagePercentPerLevel = 5;
        BaseCooldown = 4f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 8;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.PierceDagger, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
