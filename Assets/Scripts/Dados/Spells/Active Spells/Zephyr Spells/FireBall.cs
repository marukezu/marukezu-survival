using UnityEngine;

public class FireBall : Spell
{
    public FireBall() : base()
    {
        TypeSpell = SpellType.ACTIVE_FIREBALL;
        SpellElement = Elemento.FIRE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Fireball;
        Name = LanguageManager.Get("Fireball Name");
        Descricao = LanguageManager.Get("Fireball Description");
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Fireball, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
