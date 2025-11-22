using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thundera : Spell
{
    public Thundera() : base()
    {
        TypeSpell = SpellType.ACTIVE_THUNDERA;
        SpellElement = Elemento.THUNDER;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Thundera;
        Name = LanguageManager.Get("Thundera Name");
        Descricao = LanguageManager.Get("Thundera Description");
        BaseDmg = 25f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 1.75f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 12;
        consumeEletrify = true;
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
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.Thundera, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;
    }
}
