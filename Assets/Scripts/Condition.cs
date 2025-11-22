using UnityEngine;

public class Condition
{
    public const float POISON_BASE_TICKRATE = 0.5f;
    public const float FREEZE_BASE_TICKRATE = 0.5f;
    public const float BURNING_BASE_TICKRATE = 0.3f;
    public const float ELETRIFY_BASE_TICKRATE = 1f;
    public const float HASTE_BASE_TICKRATE = 1.5f;

    public enum ConditionType
    {
        Poison,
        Burning,
        Eletrify,
        Freeze,
        Protection,
        Haste,
    }

    public ConditionType Type;
    public float Damage;
    public float Duration;
    public bool IsStackable;

    private float tickTimer = 0f;

    // 🔹 Nova variável: duração original, para cálculos estáveis
    private float originalDuration;

    public Condition(ConditionType type, float damage, float duration, bool isStackable = false)
    {
        Type = type;
        Damage = damage;
        Duration = duration;
        IsStackable = isStackable;

        // Guarda a duração original no momento da criação
        originalDuration = duration;
    }

    public void RunCooldown()
    {
        Duration -= Time.deltaTime;
        tickTimer += Time.deltaTime;
    }

    public bool ShouldTick(float TickRate)
    {
        if (tickTimer >= TickRate)
        {
            tickTimer = 0f;
            return true;
        }
        return false;
    }

    public bool IsExpired => Duration <= 0f;

    // 🔹 Novo método: calcula o dano por tick de forma estável
    public float GetDamagePerTick(float TickRate)
    {
        return Damage / (originalDuration / TickRate);
    }
}