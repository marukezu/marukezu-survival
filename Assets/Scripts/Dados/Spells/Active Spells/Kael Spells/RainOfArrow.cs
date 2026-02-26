using UnityEngine;

public class RainOfArrow : Spell
{
    public RainOfArrow() : base()
    {
        TypeSpell = SpellType.ACTIVE_RAINOFARROW;
        SpellElement = Elemento.DISTANCE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_RainOfArrow;
        Name = LanguageManager.Get(LanguageTexts_Spells.SpellWords.RainOfArrows_Name);
        Descricao = LanguageManager.Get(LanguageTexts_Spells.SpellWords.RainOfArrows_Desc);
        BaseDmg = 90;
        DamagePercentPerLevel = 5;
        BaseCooldown = 4f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 8;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.RainOfArrow_Cast, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;
    }
}
