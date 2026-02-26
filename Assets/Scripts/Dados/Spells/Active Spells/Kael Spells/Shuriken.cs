using UnityEngine;

public class Shuriken : Spell
{

    public Shuriken() : base()
    {
        TypeSpell = SpellType.ACTIVE_SHURIKEN;
        SpellElement = Elemento.PHYSICAL;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Shuriken;
        Name = LanguageManager.Get(LanguageTexts_Spells.SpellWords.Shuriken_Name);
        Descricao = LanguageManager.Get(LanguageTexts_Spells.SpellWords.Shuriken_Desc);
        BaseDmg = 45;
        DamagePercentPerLevel = 5;
        BaseCooldown = 3f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 8;
    }

    public override void Cast(Creature caster)
    {
        // Se alcançar o máximo de recasts, retorna
        if (SpellLevel >= MaxRecasts)
            return;

        // Armazena o Caster.
        Caster = caster;

        int shurikensAtuais = 0;
        if (Projectile_Shuriken.shurikenOrbiters.ContainsKey(Caster))
            shurikensAtuais = Projectile_Shuriken.shurikenOrbiters[Caster].Count;

        if (shurikensAtuais < SpellLevel)
        {
            GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Shuriken, Caster.transform);
            spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
        }

    }
}
