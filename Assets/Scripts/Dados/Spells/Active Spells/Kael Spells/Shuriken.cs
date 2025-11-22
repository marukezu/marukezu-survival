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
        Name = LanguageManager.Get("Shuriken Name");
        Descricao = LanguageManager.Get("Shuriken Description");
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

    public override void ResetSpell()
    {
        base.ResetSpell();
        /*
        // Reinicia o dicionario na classe Projectile_Shuriken
        if (Projectile_Shuriken.shurikenOrbiters.ContainsKey(Caster))
        {
            foreach (var sh in Projectile_Shuriken.shurikenOrbiters[Caster])
                GameObject.Destroy(sh.gameObject); // destrói fisicamente os projéteis

            Projectile_Shuriken.shurikenOrbiters[Caster].Clear(); // limpa a lista do caster
        }
        */
    }
}
