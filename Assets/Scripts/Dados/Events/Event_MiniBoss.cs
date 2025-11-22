using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_MiniBoss : Event
{
    public Event_MiniBoss() : base(EventType.MINIBOSS_FIGHT)
    {
        Duration = 30f; // dura 30 segundos
    }

    public override void DoEvent()
    {
        Debug.Log("Iniciando evento SIEGE!");

        SpawnController.Instance.SpawnSiege(SpawnController.Creatures.Skeleton, LevelController.Instance.GetMonstersLevel());
    }

    protected override void FinishEvent()
    {
        base.FinishEvent();
        Debug.Log("Evento SIEGE terminou!");
        // restaurar spawn normal, música, etc.
    }
}
