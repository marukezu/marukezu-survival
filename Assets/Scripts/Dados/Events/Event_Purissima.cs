using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Purissima : Event
{
    public Event_Purissima() : base(EventType.PURISSIMA)
    {
        Duration = 30f; // dura 30 segundos
    }

    public override void DoEvent()
    {
        Debug.Log("Iniciando evento SIEGE!");
    }

    protected override void FinishEvent()
    {
        base.FinishEvent();
        Debug.Log("Evento SIEGE terminou!");
        // restaurar spawn normal, música, etc.
    }
}
