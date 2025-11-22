using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SpawnController;

public class Event_Siege : Event
{
    private List<Enemy_GameObject> siegeEnemys = new List<Enemy_GameObject>();

    public Event_Siege() : base(EventType.SIEGE)
    {
        Duration = 15f; // dura 15 segundos
    }

    public override void DoEvent()
    {
        // Mostra painel de anúncio
        EventInfo eventInfo = new EventInfo(true, LanguageManager.Get("Event Siege Announcement"));
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.EVENT_INFO, eventInfo);

        // Pega todos os valores do enum
        Creatures[] valores = (Creatures[])System.Enum.GetValues(typeof(Creatures));

        // Filtra apenas os que NÃO são boss e não são None
        Creatures[] monstrosNormais = valores
            .Where(c => c != Creatures.None && !c.ToString().Contains("Boss"))
            .ToArray();

        // Sorteia um
        int sorteio = Random.Range(0, monstrosNormais.Length);
        Creatures criaturaSorteada = monstrosNormais[sorteio];

        // Spawn
        siegeEnemys = SpawnController.Instance.SpawnSiege(criaturaSorteada, LevelController.Instance.GetMonstersLevel() * 10);
    }

    protected override void FinishEvent()
    {
        base.FinishEvent();

        // pede ao event manager para iniciar a coroutina de destruição.
        EventsManager.Instance.StartCoroutine(DestroyEnemys());
    }

    private IEnumerator DestroyEnemys()
    {
        foreach (Enemy_GameObject enemy in siegeEnemys)
        {
            if (enemy != null)
                enemy.Death();

            yield return new WaitForSeconds(0.025f);
        }

        EventInfo eventInfo = new EventInfo(true, LanguageManager.Get("Event Siege Finished"));
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.EVENT_INFO, eventInfo);
    }
}
