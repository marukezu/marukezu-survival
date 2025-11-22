using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBarrier : Spell
{
    public ThunderBarrier() : base()
    {
        TypeSpell = SpellType.ACTIVE_THUNDERBARRIER;
        SpellElement = Elemento.THUNDER;
        TypeTarget = TargetType.SINGLE;
        TypeCombat = CombatType.PROTECTION;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_ThunderBarrier;
        Name = LanguageManager.Get("Thunder Barrier Name");
        BaseDmg = 2f;
        BaseCooldown = 7f;
        PoderImpulsao = 0f;
        LevelMax = 1;
        Descricao = LanguageManager.Get("Thunder Barrier Description");
    }

    public override void Cast(Creature caster)
    {
        // Armazena o Caster.
        Caster = caster;

        int timesToCast = SpellLevel > 0 ? SpellLevel : 1;
        float interval = 0.25f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    private void CastSpell()
    {
        // Instancia o efeito da spell
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.ThunderBarrier, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;

        // Adiciona a condition de proteção
        Condition condProtection = new Condition(Condition.ConditionType.Protection, 0, BaseDmg);
        GameManager.Instance.playerHero.heroConditions.AddCondition(condProtection);
    }
}
