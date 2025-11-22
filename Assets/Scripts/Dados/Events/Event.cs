using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Essa classe representa um evento aleatório que pode acontecer na geração das "Fases",
// Ciclos que acontecem a todo minuto. Veja mais info em (LevelController)
public abstract class Event
{
    public enum EventType
    {
        SIEGE,
        MINIBOSS_FIGHT,
        BOSS_FIGHT,
        DOUBLE_SPAWNRATE,
        PURISSIMA, // VENDEDORA QUE APARECE
    }

    public EventType TypeEvent;

    public float Duration { get; protected set; }
    public float TimeSinceStart { get; private set; }

    public bool eventCompleted = false;

    public Event(EventType type)
    {
        this.TypeEvent = type;
    }

    // Esse método é responsável por fazer acontecer o evento.
    public abstract void DoEvent();
    public virtual void UpdateEvent(float deltaTime)
    {
        TimeSinceStart += deltaTime;

        if (TimeSinceStart >= Duration)
            FinishEvent();
    }
    protected virtual void FinishEvent()
    {
        eventCompleted = true;
    }
}
