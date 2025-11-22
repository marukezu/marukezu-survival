using UnityEngine;

public static class Combat
{
    public static void DoCombat(Spell spell, Enemy_GameObject target)
    {
        Color spellColor;
        GameObject damageEffect;

        switch (spell.SpellElement)
        {
            case Spell.Elemento.PHYSICAL:
                spellColor = Color.red;
                damageEffect = PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Physical, target.transform);
                break;

            case Spell.Elemento.FIRE:
                spellColor = new Color(1f, 0.5f, 0f); // Laranja
                damageEffect = PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Fire, target.transform);
                break;

            case Spell.Elemento.ICE:
                spellColor = Color.cyan;
                damageEffect = PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Ice, target.transform);
                break;

            case Spell.Elemento.THUNDER:
                spellColor = Color.blue;
                damageEffect = PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Thunder, target.transform);
                break;

            case Spell.Elemento.POISON:
                spellColor = Color.green;
                damageEffect = PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Poison, target.transform);
                break;

            default:
                spellColor = Color.red;
                damageEffect = PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Physical, target.transform);
                break;
        }

        float danoFinal = spell.GetSpellDamage();

        // Verifica Eletrify
        if (target.conditions.isEletrify && spell.consumeEletrify)
        {
            danoFinal *= 2.5f;
            target.conditions.RemoveCondition(Condition.ConditionType.Eletrify);
            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.ConsumeEletrify, target.transform);
        }

        // Aplicação de status poison
        if (spell.statusPoison)
        {
            danoFinal /= 2;
            target.conditions.AddCondition(new Condition(Condition.ConditionType.Poison, danoFinal, 2.5f, true));
        }

        // Aplicação de status burning
        if (spell.statusBurn)
        {
            danoFinal /= 2;
            target.conditions.AddCondition(new Condition(Condition.ConditionType.Burning, danoFinal, 1.5f, true));
        }

        // Aplicação de status freeze
        if (spell.statusFreeze)
            target.conditions.AddCondition(new Condition(Condition.ConditionType.Freeze, 0, 1.5f, false));

        // Aplicação de status eletrify
        if (spell.statusEletrify)
            target.conditions.AddCondition(new Condition(Condition.ConditionType.Eletrify, 0, 2.5f, false));

        // Recebe o dano.
        target.ReceberDano(danoFinal, spellColor);
    }   

    public static void DoPotionCombat(Potion potion, Enemy_GameObject target)
    {
        // Recebe o dano.
        target.ReceberDano(potion.effectPotency, new Color(1f, 0.5f, 0f));
    }
}
