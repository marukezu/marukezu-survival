using UnityEngine;

public class FireElemental_FireSpark : Spell
{
    public FireElemental_FireSpark() : base()
    {
        TypeSpell = SpellType.FIREELEMENTAL_ACTIVE_FAGULHADEFOGO;
        SpellElement = Elemento.FIRE;
        BaseCooldown = 0;
        PoderImpulsao = 0.1f;

    }

    public override void Cast(Creature caster)
    {
        // Atualiza os dados com a spell do Player
        BaseDmg = SpellsList.IgnisArrow.BaseDmg * 0.5f;
        DamagePercentPerLevel = SpellsList.IgnisArrow.DamagePercentPerLevel;
        SpellLevel = SpellsList.IgnisArrow.SpellLevel;
        LevelMax = SpellsList.IgnisArrow.LevelMax;
        MaxRecasts = SpellsList.IgnisArrow.MaxRecasts;
        statusBurn = SpellsList.IgnisArrow.statusBurn;

        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.15f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    public void CastSpell()
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Summon_FireSpark, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
