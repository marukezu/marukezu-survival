using UnityEngine;

public class Arrow : Spell
{
    public Arrow() : base()
    {
        TypeSpell = SpellType.ACTIVE_ARROW;
        SpellElement = Elemento.DISTANCE;
        TypeTarget = TargetType.SINGLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Arrow;
        Name = LanguageManager.Get("Arrow Name");
        Descricao = LanguageManager.Get("Arrow Description");
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Arrow, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
