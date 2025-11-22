using UnityEngine;

public class Thunder : Spell
{ 
    public Thunder() : base()
    {
        TypeSpell = SpellType.ACTIVE_THUNDER;
        SpellElement = Elemento.THUNDER;
        TypeTarget = TargetType.SINGLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Thunder;
        Name = LanguageManager.Get("Thunder Name");
        Descricao = LanguageManager.Get("Thunder Description");
        BaseDmg = 35f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 3f;
        PoderImpulsao = 0.08f;
        JumpQuantity = 3;
        LevelMax = 999;
        MaxRecasts = 8;
        statusEletrify = true;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Thunder, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
