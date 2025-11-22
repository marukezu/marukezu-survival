using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SpawnController;

public class Event_Boss : Event
{
    private Enemy_GameObject bossSpawned;

    public Event_Boss() : base(EventType.BOSS_FIGHT) { }
    public override void DoEvent()
    {
        EventInfo eventInfo = new EventInfo(true, LanguageManager.Get("Event Boss Announcement"));
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.EVENT_INFO, eventInfo);

        Creatures[] valores = (Creatures[])System.Enum.GetValues(typeof(Creatures));
        Creatures[] bosses = valores
            .Where(c => c != Creatures.None && c.ToString().Contains("Boss"))
            .ToArray();

        int sorteio = Random.Range(0, bosses.Length);
        Creatures criaturaSorteada = Creatures.ZombieBoss; //bosses[sorteio];

        // Spawn boss e salva referência
        bossSpawned = SpawnController.Instance.SpawnEnemy(
            criaturaSorteada,
            LevelController.Instance.GetMonstersLevel() * 10
        );
    }

    public override void UpdateEvent(float deltaTime)
    {
        base.UpdateEvent(deltaTime);

        if (bossSpawned == null || bossSpawned.isDead)
        {
            FinishEvent();
        }
    }

    protected override void FinishEvent()
    {
        base.FinishEvent();
    }
}
