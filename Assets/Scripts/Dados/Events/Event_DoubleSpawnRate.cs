using UnityEngine;

public class Event_DoubleSpawnRate : Event
{
    public Event_DoubleSpawnRate() : base(EventCategory.Negative, weight: 2f)
    {
        Duration = Random.Range(45f, 60f);
    }

    protected override void OnTick(float deltaTime)
    {
        base.OnTick(deltaTime);

        Duration -= deltaTime;
    }

    protected override void OnStart()
    {
        var eventInfo = new EventInfo(true, LanguageManager.Get(LanguageTexts_Events.EventWords.EventDoubleSpawnRateAnnouncement));
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.EVENT_INFO, eventInfo);

        LevelController.Instance.isDoubleSpawnRate = true;
    }

    protected override void OnFinish()
    {
        var eventInfo = new EventInfo(true, LanguageManager.Get(LanguageTexts_Events.EventWords.EventDoubleSpawnRateFinished));
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.EVENT_INFO, eventInfo);

        LevelController.Instance.isDoubleSpawnRate = false;
    }
}