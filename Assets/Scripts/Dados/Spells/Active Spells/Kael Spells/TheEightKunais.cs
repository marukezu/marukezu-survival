using UnityEngine;

public class TheEightKunais : Spell
{
    public TheEightKunais() : base()
    {
        TypeSpell = SpellType.ACTIVE_THEEIGHTKUNAIS;
        SpellElement = Elemento.PHYSICAL;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_TheEightKunais;
        Name = LanguageManager.Get("The Eight Kunais Name");
        Descricao = LanguageManager.Get("The Eight Kunais Description");
        BaseDmg = 90;
        DamagePercentPerLevel = 5;
        BaseCooldown = 3f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 8;
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
        Vector3 casterPos = Caster.transform.position;

        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f; // 0, 45, 90, 135, ... 315°

            GameObject kunaiGO = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.TheEightKunais, Caster.transform);
            Projectile_TheEightKunais kunai = kunaiGO.GetComponent<Projectile_TheEightKunais>();
            kunai.InitializeProjectile(this, casterPos, angle);
        }
    }

}
