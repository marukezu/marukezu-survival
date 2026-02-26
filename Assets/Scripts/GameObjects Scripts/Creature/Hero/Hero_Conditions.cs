using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Conditions
{
    private Hero_GameObject hero;
    public List<Condition> conditions = new List<Condition>();

    // Controle de efeitos visuais/estados
    public bool isBurning => conditions.Exists(c => c.Type == Condition.ConditionType.Burning);
    public bool isPoisoned => conditions.Exists(c => c.Type == Condition.ConditionType.Poison);
    public bool isFrozen => conditions.Exists(c => c.Type == Condition.ConditionType.Freeze);
    public bool isEletrify => conditions.Exists(c => c.Type == Condition.ConditionType.Eletrify);
    public bool isHasted => conditions.Exists(c => c.Type == Condition.ConditionType.Haste);
    public bool isProtected => conditions.Exists(c => c.Type == Condition.ConditionType.Protection);

    public Hero_Conditions(Hero_GameObject hero)
    {
        this.hero = hero;
    }

    public void ApplyConditions()
    {
        // Percorre cópia da lista, pois podemos remover durante o loop
        for (int i = conditions.Count - 1; i >= 0; i--)
        {
            Condition condition = conditions[i];
            condition.RunCooldown();

            switch (condition.Type)
            {
                case Condition.ConditionType.Haste:
                    ApplyHaste(condition);
                    break;

                case Condition.ConditionType.Burning:
                    ApplyBurning();
                    break;

                case Condition.ConditionType.Freeze:
                    ApplyFreeze();
                    break;

                case Condition.ConditionType.Eletrify:
                    ApplyEletrify();
                    break;
                case Condition.ConditionType.Protection:
                    ApplyProtection();
                    break;
            }
        }
    }

    // ==========================================================
    private void ApplyHaste(Condition condition)
    {
        if (condition.ShouldTick())
        {
            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Haste, hero.transform);
        }
    }
    private void ApplyFreeze()
    {

    }
    private void ApplyBurning()
    {

    }
    private void ApplyEletrify()
    {

    }
    private void ApplyProtection()
    {

    }

    // ==========================================================
    public void AddCondition(Condition newCondition)
    {
        // Verifica se já existe condição do mesmo tipo
        Condition existing = conditions.Find(c => c.Type == newCondition.Type);

        // Se for stackável, adiciona uma nova instância (acumula)
        if (newCondition.IsStackable)
        {
            conditions.Add(newCondition);
        }
        else
        {
            // Se já existir, apenas renova (ou substitui valores)
            if (existing != null)
            {
                existing.Duration = newCondition.Duration;
                existing.Damage = newCondition.Damage;
            }
            else
            {
                conditions.Add(newCondition);
            }
        }
    }
}
