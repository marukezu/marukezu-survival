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
    public Spell.Elemento Element;
    public float Damage;
    public float Duration;
    public bool IsStackable;
    public bool IsExpired => Duration <= 0f;

    private float tickTimer = 0f;
    private float tickRate = 0f;

    // duração original, para cálculos estáveis
    private float originalDuration;

    public Condition(ConditionType type, float damage, float duration, bool isStackable = false)
    {
        Type = type;
        Damage = damage;
        Duration = duration;
        IsStackable = isStackable;

        // Guarda a duração original no momento da criação
        originalDuration = duration;

        // Seta o elemento da Condition
        SetElement();

        // Seta o TickRate
        SetTickRate();
    }

    public void RunCooldown()
    {
        Duration -= Time.deltaTime;
        tickTimer += Time.deltaTime;
    }

    public bool ShouldTick()
    {
        if (tickTimer >= tickRate)
        {
            tickTimer = 0f;
            return true;
        }
        return false;
    }

    // 🔹 Novo método: calcula o dano por tick de forma estável
    public float GetDamagePerTick()
    {
        return Damage / (originalDuration / tickRate);
    }

    // Seta o TickRate
    private void SetTickRate()
    {
        switch (Type)
        {
            case ConditionType.Poison:
                tickRate = POISON_BASE_TICKRATE; break;

            case ConditionType.Burning:
                tickRate = BURNING_BASE_TICKRATE; break;

            case ConditionType.Eletrify:
                tickRate = ELETRIFY_BASE_TICKRATE; break;

            case ConditionType.Freeze:
                tickRate = FREEZE_BASE_TICKRATE; break;

            case ConditionType.Haste:
                tickRate = HASTE_BASE_TICKRATE; break;
        }
    }

    // Seta o elemento da condição
    private void SetElement()
    {
        switch (Type)
        {
            case ConditionType.Poison:
                Element = Spell.Elemento.POISON; break;

            case ConditionType.Burning:
                Element = Spell.Elemento.FIRE; break;

            case ConditionType.Eletrify:
                Element = Spell.Elemento.THUNDER; break;

            case ConditionType.Freeze:
                Element = Spell.Elemento.ICE; break;
        }
    }
}