using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SpawnController;

public class Event_DoubleSpawnRate : Event
{
    private List<Enemy_GameObject> siegeEnemys = new List<Enemy_GameObject>();

    public Event_DoubleSpawnRate() : base(EventType.DOUBLE_SPAWNRATE)
    {
        Duration = Random.Range(45, 60); // Dura de 45 a 60 segundos.
    }

    public override void DoEvent()
    {
        // Mostra painel de anúncio
        EventInfo eventInfo = new EventInfo(true, LanguageManager.Get("Event DoubleSpawnRate Announcement"));
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.EVENT_INFO, eventInfo);

        // Informa o LevelController que dobrou o spawn rate
        LevelController.Instance.isDoubleSpawnRate = true;
        
    }

    protected override void FinishEvent()
    {
        base.FinishEvent();

        EventInfo eventInfo = new EventInfo(true, LanguageManager.Get("Event DoubleSpawnRate Finished"));
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.EVENT_INFO, eventInfo);

        // Informa o LevelController que acabou o double spawn rate
        LevelController.Instance.isDoubleSpawnRate = false;
    }
}
