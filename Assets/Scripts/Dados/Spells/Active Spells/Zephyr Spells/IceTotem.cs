using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Spell;

public class IceTotem : Spell
{
    public IceTotem() : base()
    {
        TypeSpell = SpellType.ACTIVE_ICETOTEM;
        SpellElement = Elemento.ICE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_IceTotem;
        Name = LanguageManager.Get("Ice Totem Name");
        Descricao = LanguageManager.Get("Ice Totem Description");
        BaseDmg = 55f;
        DamagePercentPerLevel = 2;
        BaseCooldown = 4f;
        PoderImpulsao = 0.25f;
        LevelMax = 999;
        MaxRecasts = 5;
        statusFreeze = true;
    }

    public override void Cast(Creature caster)
    {
        base.Cast(caster);

        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.3f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    public void CastSpell()
    {
        GameObject spellPrefab = PrefabManager.Instance.InstantiateSpellPrefab(PrefabManager_Spells.SpellType.IceTotem, Caster.transform);
        spellPrefab.GetComponent<Stationary>().spell = this;
    }
}
