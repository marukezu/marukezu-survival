using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConditions
{
    private Enemy_GameObject enemy;
    public List<Condition> conditions = new List<Condition>();

    // Controle de efeitos visuais/estados
    public bool isFrozen = false;
    public bool isEletrify = false;
    public bool isBurning = false;
    public bool isPoisoned = false;

    public EnemyConditions(Enemy_GameObject enemy)
    {
        this.enemy = enemy;
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
                case Condition.ConditionType.Poison:
                    ApplyPoison(condition);
                    break;

                case Condition.ConditionType.Burning:
                    ApplyBurning(condition);
                    break;

                case Condition.ConditionType.Freeze:
                    ApplyFreeze(condition);
                    break;

                case Condition.ConditionType.Eletrify:
                    ApplyEletrify(condition);
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
    private void ApplyPoison(Condition condition)
    {
        isPoisoned = true;

        if (condition.ShouldTick(Condition.POISON_BASE_TICKRATE))
        {
            enemy.ReceberDano(condition.GetDamagePerTick(Condition.POISON_BASE_TICKRATE), Color.green);
        }
    }
    private void ApplyFreeze(Condition condition)
    {
        // Ativar congelamento apenas uma vez
        if (!isFrozen)
        {
            isFrozen = true;
            enemy._enemySpriteRenderer.material.color = Color.cyan;
            enemy.monster.Speed *= 0.8f;

            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Freeze, enemy.transform);
        }
    }

    private void ApplyBurning(Condition condition)
    {
        isBurning = true;

        if (condition.ShouldTick(Condition.BURNING_BASE_TICKRATE))
        {
            enemy.ReceberDano(condition.GetDamagePerTick(Condition.BURNING_BASE_TICKRATE), new Color(1f, 0.5f, 0f));
        }
    }

    private void ApplyEletrify(Condition condition)
    {
        isEletrify = true;

        if (condition.ShouldTick(Condition.ELETRIFY_BASE_TICKRATE))
        {
            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Eletrify, enemy.transform);
        }
    }

    // ==========================================================
    private void OnConditionEnd(Condition condition)
    {
        switch (condition.Type)
        {
            case Condition.ConditionType.Freeze:
                isFrozen = false;
                enemy._enemySpriteRenderer.material.color = enemy.animations._corOriginal;
                enemy.monster.Speed = enemy.originalSpeed;
                break;
            case Condition.ConditionType.Burning:
                isBurning = false;
                break;
            case Condition.ConditionType.Eletrify:
                isEletrify = false;
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

                // Efeito imediato (visual)
                if (newCondition.Type == Condition.ConditionType.Freeze)
                    ApplyFreeze(newCondition);
            }
        }
    }

    public void RemoveCondition(Condition.ConditionType conditionType)
    {
        for (int i = conditions.Count - 1; i >= 0; i--) // itera de trás pra frente
        {
            if (conditions[i].Type == conditionType)
            {
                OnConditionEnd(conditions[i]);
                conditions.RemoveAt(i);
            }
        }
    }
}
