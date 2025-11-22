using UnityEngine;

public class FireElemental_Meteor : Spell
{
    public FireElemental_Meteor() : base()
    {
        TypeSpell = SpellType.FIREELEMENTAL_ACTIVE_METEOR;
        SpellElement = Elemento.FIRE;
        BaseCooldown = 0;
        PoderImpulsao = 0.1f;

    }

    public override void Cast(Creature caster)
    {
        // Atualiza os dados com a spell do Player
        BaseDmg = SpellsList.Meteor.BaseDmg * 0.5f;
        DamagePercentPerLevel = SpellsList.Meteor.DamagePercentPerLevel;
        SpellLevel = SpellsList.Meteor.SpellLevel;
        LevelMax = SpellsList.Meteor.LevelMax;
        MaxRecasts = SpellsList.Meteor.MaxRecasts;
        statusBurn = SpellsList.Meteor.statusBurn;

        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.25f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    public void CastSpell()
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Meteor, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;
    }
}
