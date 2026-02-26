using System.Linq;
using UnityEngine;
using static SpawnController;

public class Event_Boss : Event
{
    private Enemy_GameObject bossSpawned;

    public Event_Boss() : base(EventCategory.Negative, weight: 1.0f)
    {
        // Se quiser fallback por tempo (opcional)
        Duration = 180f; // 3 minutos de limite máximo (caso algo bugue)
    }

    protected override void OnStart()
    {
        // Anúncio
        EventInfo eventInfo = new EventInfo(
            true,
            LanguageManager.Get(LanguageTexts_Events.EventWords.EventBossAnnouncement)
        );

        PanelManager.Instance.InstanciarERetornarPainel(
            Panel.PanelType.EVENT_INFO,
            eventInfo
        );

        // Seleciona boss aleatório
        Creatures[] valores = (Creatures[])System.Enum.GetValues(typeof(Creatures));

        Creatures[] bosses = valores
            .Where(c => c != Creatures.None && c.ToString().Contains("Boss"))
            .ToArray();

        if (bosses.Length == 0)
        {
            Debug.LogWarning("Nenhum boss encontrado.");
            FinishEvent();
            return;
        }

        int sorteio = Random.Range(0, bosses.Length);
        Creatures criaturaSorteada = bosses[sorteio];

        // Spawn boss e salva referência
        bossSpawned = SpawnController.Instance.SpawnEnemy(
            criaturaSorteada,
            LevelController.Instance.GetMonstersLevel() * 10
        );
    }

    protected override bool ShouldFinish()
    {
        // Finaliza se boss morreu
        if (bossSpawned == null || bossSpawned.isDead)
            return true;

        // Ou se passou do tempo máximo (fallback)
        return base.ShouldFinish();
    }

    protected override void OnFinish()
    {
        // Se quiser dar recompensa aqui
        // Exemplo:
        // PlayerImage.moneyFeito += 100;
        // ou spawnar baú especial

        EventInfo eventInfo = new EventInfo(
            true,
            ""
        );

        PanelManager.Instance.InstanciarERetornarPainel(
            Panel.PanelType.EVENT_INFO,
            eventInfo
        );
    }
}