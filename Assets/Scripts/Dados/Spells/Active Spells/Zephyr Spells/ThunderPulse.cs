using UnityEngine;

public class ThunderPulse : Spell
{
    public ThunderPulse() : base()
    {
        TypeSpell = SpellType.ACTIVE_THUNDERPULSE;
        SpellElement = Elemento.THUNDER;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_ThunderPulse;
        Name = LanguageManager.Get("Thunder Pulse Name");
        Descricao = LanguageManager.Get("Thunder Pulse Description");
        BaseDmg = 65f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 5.25f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 6;
        consumeEletrify = true;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.ThunderPulse, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;
    }
}
