using UnityEngine;

public class TornadoFury : Spell
{
    public TornadoFury() : base()
    {
        TypeSpell = SpellType.ACTIVE_TORNADOFURY;
        SpellElement = Elemento.ICE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_TornadoFury;
        Name = LanguageManager.Get("Tornado Fury Name");
        Descricao = LanguageManager.Get("Tornado Fury Description");
        BaseDmg = 70f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 4f;
        PoderImpulsao = 0.2f;
        LevelMax = 999;
        MaxRecasts = 8;
        statusFreeze = true;
    }

    public override void Cast(Creature caster)
    {
        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.25f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    private void CastSpell()
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.TornadoFury, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
