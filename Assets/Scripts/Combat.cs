using System;

public sealed class CombatResult
{
    public Spell.Elemento element;
    public float finalDamage;

    // Flags
    public bool isCritical;

    public CombatResult(Spell.Elemento element, float finalDamage, bool isCritical)
    {
        this.element = element;
        this.finalDamage = finalDamage;
        this.isCritical = isCritical;
    }
}

public static class Combat
{
    // Para calculos de chances.
    private static readonly Random _rng = new Random();

    public static void DoCombat(Spell spell, Enemy_GameObject target)
    {
        float finalDamage = spell.GetSpellDamage();
        bool isCritical = Calculate_Critical();

        // Se for crítico, multiplica o dano.
        if (isCritical)
            finalDamage *= (HeroImage.GetHeroCriticalMultiplier() / 100);

        // Consome Eletrify
        if (target.conditions.isEletrify && spell.consumeEletrify)
        {
            finalDamage *= 2.5f;
            target.conditions.RemoveCondition(Condition.ConditionType.Eletrify);
            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.ConsumeEletrify, target.transform);
        }

        // Aplica condições da Spell
        Apply_SpellConditions(spell, target);

        // Preenche o CombatResult
        CombatResult result = new CombatResult(
            element: spell.SpellElement,
            finalDamage: finalDamage,
            isCritical: isCritical
            );

        // Informa o dano.
        target.ReceberDano(result);
    }

    // ============================================================================
    // ============================= CONDITION COMBAT =============================
    // ============================================================================
    public static void DoConditionCombat(Condition condition, Enemy_GameObject target)
    {
        CombatResult result = new CombatResult(
            element: condition.Element,
            finalDamage: condition.GetDamagePerTick(),
            isCritical: false
            );

        target.ReceberDano(result);
    }

    private static void Apply_SpellConditions(Spell spell, Enemy_GameObject target)
    {
        // Aplicação de status poison
        if (spell.statusPoison)
        {
            target.conditions.AddCondition(
                new Condition(
                    type: Condition.ConditionType.Poison,
                    damage: spell.GetSpellDamage() / 2,
                    duration: 2.5f,
                    isStackable: true
                )
            );
        }

        // Aplicação de status burning
        if (spell.statusBurn)
        {
            target.conditions.AddCondition(
                new Condition(
                    type: Condition.ConditionType.Burning,
                    damage: spell.GetSpellDamage() / 2,
                    duration: 1.5f,
                    isStackable: true)
                );
        }

        // Aplicação de status freeze
        if (spell.statusFreeze)
        {
            target.conditions.AddCondition(
                new Condition(
                    type: Condition.ConditionType.Freeze,
                    damage: 0,
                    duration: 1.5f,
                    isStackable: false)
                );
        }

        // Aplicação de status eletrify
        if (spell.statusEletrify)
        {
            target.conditions.AddCondition(
                new Condition(
                    type: Condition.ConditionType.Eletrify,
                    damage: 0,
                    duration: 2.5f,
                    isStackable: false)
                );
        }
    }

    // ============================================================================
    // ============================== POTION COMBAT ===============================
    // ============================================================================
    public static void DoPotionCombat(Potion potion, Enemy_GameObject target)
    {
        CombatResult result = new CombatResult(
            element: Spell.Elemento.FIRE,
            finalDamage: potion.effectPotency,
            isCritical: false
            );

        // Recebe o dano.
        target.ReceberDano(result);
    }

    // ============================================================================
    // =========================== CALCULOS ADICIONAIS ============================
    // ============================================================================
    private static bool Calculate_Critical()
    {
        float chanceCritica = HeroImage.GetHeroCriticalChance(); // ex: 25 = 25%

        double sorteio = _rng.NextDouble() * 100.0;
        // NextDouble() gera 0.0 até 0.999...
        // multiplicamos por 100 para virar 0–99.999...

        return sorteio < chanceCritica;
    }
}
