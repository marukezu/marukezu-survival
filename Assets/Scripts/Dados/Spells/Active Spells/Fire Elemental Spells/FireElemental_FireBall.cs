using UnityEngine;

public class FireElemental_FireBall : Spell
{
    public FireElemental_FireBall() : base()
    {
        TypeSpell = SpellType.FIRELEMENTAL_ACTIVE_FIREBALL;
        SpellElement = Elemento.FIRE;
        BaseCooldown = 0;
        PoderImpulsao = 0.1f;
    }

    public override void Cast(Creature caster)
    {
        // Atualiza os dados com a spell do Player
        BaseDmg = SpellsList.Fireball.BaseDmg * 0.5f;
        DamagePercentPerLevel = SpellsList.Fireball.DamagePercentPerLevel;
        SpellLevel = SpellsList.Fireball.SpellLevel;
        LevelMax = SpellsList.Fireball.LevelMax;
        MaxRecasts = SpellsList.Fireball.MaxRecasts;
        statusBurn = SpellsList.Fireball.statusBurn;

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
