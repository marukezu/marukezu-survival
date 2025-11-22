using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Conditions
{
    private Hero_GameObject hero;
    public List<Condition> conditions = new List<Condition>();

    // Controle de efeitos visuais/estados
    public bool isHasted = false;
    public bool isFrozen = false;
    public bool isEletrify = false;
    public bool isBurning = false;
    public bool isProtected = false;

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

            if (condition.IsExpired)
            {
                OnConditionEnd(condition);
                conditions.RemoveAt(i);
            }
        }
    }

    // ==========================================================
    private void ApplyHaste(Condition condition)
    {
        isHasted = true;

        if (condition.ShouldTick(Condition.HASTE_BASE_TICKRATE))
        {
            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Haste, hero.transform);
        }
    }
    private void ApplyFreeze()
    {
        isFrozen = true;
    }
    private void ApplyBurning()
    {
        isBurning = true;
    }
    private void ApplyEletrify()
    {
        isEletrify = true;
    }
    private void ApplyProtection()
    {
        isProtected = true;
    }

    // ==========================================================
    private void OnConditionEnd(Condition condition)
    {
        switch (condition.Type)
        {
            case Condition.ConditionType.Haste:
                isHasted = false;
                break;
            case Condition.ConditionType.Freeze:
                isFrozen = false;
                break;
            case Condition.ConditionType.Burning:
                isBurning = false;
                break;
            case Condition.ConditionType.Eletrify:
                isEletrify = false;
                break;
            case Condition.ConditionType.Protection:
                isProtected = false;
                break;
        }
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
