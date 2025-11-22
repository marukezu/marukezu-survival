using UnityEngine;

public class PoisonKunai : Spell
{
    public PoisonKunai() : base()
    {
        TypeSpell = SpellType.ACTIVE_POISONKUNAI;
        SpellElement = Elemento.PHYSICAL;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_PoisonKunai;
        Name = LanguageManager.Get("Poison Kunai Name");
        Descricao = LanguageManager.Get("Poison Kunai Description");
        BaseDmg = 65;
        DamagePercentPerLevel = 5;
        BaseCooldown = 2.5f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 8;
        statusPoison = true;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.PoisonKunai, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
