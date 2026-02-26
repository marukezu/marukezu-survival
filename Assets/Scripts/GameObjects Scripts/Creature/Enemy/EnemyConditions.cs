using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Essa classe representa as Conditions de um Enemy.
// Cada Enemy possui essa classe como uma variável.

public class EnemyConditions
{
    private Enemy_GameObject enemy;
    public List<Condition> conditions = new List<Condition>();

    // Controle de efeitos visuais/estados
    public bool isBurning => conditions.Exists(c => c.Type == Condition.ConditionType.Burning);
    public bool isPoisoned => conditions.Exists(c => c.Type == Condition.ConditionType.Poison);
    public bool isFrozen => conditions.Exists(c => c.Type == Condition.ConditionType.Freeze);
    public bool isEletrify => conditions.Exists(c => c.Type == Condition.ConditionType.Eletrify);


    public EnemyConditions(Enemy_GameObject enemy)
    {
        this.enemy = enemy;
    }

    // =======================================
    // Método chamado no UPDATE() do Enemy.
    public void ApplyConditions()
    {
        // Percorre cópia da lista, pois podemos remover durante o loop
        for (int i = conditions.Count - 1; i >= 0; i--)
        {
            Condition condition = conditions[i];
            condition.RunCooldown(); // Reduz a duração e o tickTimer da condition.

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
        }
    }

    // ==========================================================
    private void ApplyPoison(Condition condition)
    {
        if (condition.ShouldTick())
        {
            Combat.DoConditionCombat(condition, enemy);
        }
    }
    private void ApplyFreeze(Condition condition)
    {
        // Ativar congelamento apenas uma vez
        if (!isFrozen)
        {
            enemy._enemySpriteRenderer.material.color = Color.cyan;
            enemy.monster.Speed *= 0.8f;

            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Freeze, enemy.transform);
        }
    }

    private void ApplyBurning(Condition condition)
    {
        if (condition.ShouldTick())
        {
            Combat.DoConditionCombat(condition, enemy);
        }
    }

    private void ApplyEletrify(Condition condition)
    {
        if (condition.ShouldTick())
        {
            PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Eletrify, enemy.transform);
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
                conditions.RemoveAt(i);
            }
        }
    }
}
