using System;
using UnityEngine;

public abstract class Event
{
    public enum EventCategory
    {
        Negative,
        Positive
    }

    public EventCategory Category { get; protected set; }
    public float Weight { get; protected set; } = 1f;

    public float Duration { get; protected set; } = 30f;
    public float TimeSinceStart { get; private set; }

    public bool HasStarted { get; private set; }
    public bool IsCompleted { get; private set; }

    protected Event(EventCategory category, float weight = 1f)
    {
        Category = category;
        Weight = Mathf.Max(0.0001f, weight);
    }

    protected abstract void OnStart();

    protected virtual void OnTick(float deltaTime) { }

    protected virtual void OnFinish() { }

    protected virtual bool ShouldFinish()
    {
        return TimeSinceStart >= Duration;
    }

    public void StartEvent()
    {
        if (HasStarted) return;

        HasStarted = true;
        TimeSinceStart = 0f;
        IsCompleted = false;

        OnStart();
    }

    public void UpdateEvent(float deltaTime)
    {
        if (!HasStarted || IsCompleted) return;

        TimeSinceStart += deltaTime;
        OnTick(deltaTime);

        if (ShouldFinish())
            FinishEvent();
    }

    public void FinishEvent()
    {
        if (IsCompleted) return;

        IsCompleted = true;
        OnFinish();
    }
}