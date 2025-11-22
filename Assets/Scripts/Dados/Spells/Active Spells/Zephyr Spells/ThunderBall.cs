using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBall : Spell
{
    public ThunderBall() : base()
    {
        TypeSpell = SpellType.ACTIVE_THUNDERBALL;
        SpellElement = Elemento.THUNDER;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_ThunderBall;
        Name = LanguageManager.Get("Thunder Ball Name");
        Descricao = LanguageManager.Get("Thunder Ball Description");
        BaseDmg = 30f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 3f;
        PoderImpulsao = 0.08f;
        JumpQuantity = 0;
        LevelMax = 999;
        MaxRecasts = 8;
        statusEletrify = true;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.ThunderBall, Caster.transform);
        spellPrefab.GetComponent<Projectile>().InitializeProjectile(this);
    }
}
