using UnityEngine;

public class Explosao : Spell
{
    public Explosao() : base()
    {
        TypeSpell = SpellType.ACTIVE_EXPLOSION;
        SpellElement = Elemento.FIRE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Explosion;
        Name = LanguageManager.Get("Explosao Name");
        Descricao = LanguageManager.Get("Explosao Description");
        BaseDmg = 80f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 2f;
        PoderImpulsao = 0.25f;
        LevelMax = 999;
        MaxRecasts = 2;
    }

    public override void Cast(Creature caster)
    {
        base.Cast(caster);

        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.3f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    public void CastSpell()
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Explosion, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;
    }
}
