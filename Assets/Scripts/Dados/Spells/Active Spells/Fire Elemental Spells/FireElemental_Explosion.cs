using UnityEngine;

public class FireElemental_Explosion : Spell
{
    public FireElemental_Explosion() : base()
    {
        TypeSpell = SpellType.FIREELEMENTAL_ACTIVE_EXPLOSION;
        SpellElement = Elemento.FIRE;
        BaseCooldown = 0;
        PoderImpulsao = 0.1f;
    }

    public override void Cast(Creature caster)
    {
        // Atualiza os dados com a spell do Player
        BaseDmg = SpellsList.Explosao.BaseDmg * 0.5f;
        DamagePercentPerLevel = SpellsList.Explosao.DamagePercentPerLevel;
        SpellLevel = SpellsList.Explosao.SpellLevel;
        LevelMax = SpellsList.Explosao.LevelMax;
        MaxRecasts = SpellsList.Explosao.MaxRecasts;
        statusBurn = SpellsList.Explosao.statusBurn;

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
