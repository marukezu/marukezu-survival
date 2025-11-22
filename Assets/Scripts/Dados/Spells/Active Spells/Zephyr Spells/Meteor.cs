using UnityEngine;

public class Meteor : Spell
{
    public Meteor() : base()
    {
        TypeSpell = SpellType.ACTIVE_METEOR;
        SpellElement = Elemento.FIRE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Meteor;
        Name = LanguageManager.Get("Meteor Name");
        Descricao = LanguageManager.Get("Meteor Description");
        BaseDmg = 95f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 6f;
        PoderImpulsao = 0.25f;
        LevelMax = 999;
        MaxRecasts = 5;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Meteor, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;
    }
}
