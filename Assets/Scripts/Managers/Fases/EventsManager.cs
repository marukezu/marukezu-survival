using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance;

    [Header("Eventos possíveis")]
    [SerializeField] private List<Event> eventsParaSorteio;

    private float proximoTempoEvento;
    private Event eventoAtual;
    private System.Type ultimoEventoTipo; // ← Guarda o tipo do último evento

    private float contadorTimerFase => LevelController.Instance.contadorTimerFase;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        proximoTempoEvento = Random.Range(150, 180); // Primeiro evento ~2:30–3:00 min
    }

    private void Update()
    {
        GerenciarEventos();
    }

    private void GerenciarEventos()
    {
        if (eventoAtual != null)
        {
            eventoAtual.UpdateEvent(Time.deltaTime);

            if (eventoAtual.eventCompleted)
            {
                // Guarda o tipo do evento atual antes de limpar
                ultimoEventoTipo = eventoAtual.GetType();
                eventoAtual = null;

                // Sorteia novo intervalo entre eventos (2–3 minutos)
                float intervaloAleatorio = Random.Range(120f, 180f);
                proximoTempoEvento = contadorTimerFase + intervaloAleatorio;
            }

            return;
        }

        // Nenhum evento ativo
        if (contadorTimerFase >= proximoTempoEvento)
        {
            SortearENovoEvento();
        }
    }

    private void SortearENovoEvento()
    {
        eventsParaSorteio = new List<Event>()
        {
            // new Event_Siege(),
            new Event_Boss(),
            new Event_DoubleSpawnRate(),
            // new Event_Purissima(),
        };

        Event novoEvento;
        int tentativas = 0;
        do
        {
            int sorteio = Random.Range(0, eventsParaSorteio.Count);
            novoEvento = eventsParaSorteio[sorteio];
            tentativas++;
        }
        while (novoEvento.GetType() == ultimoEventoTipo && tentativas < 10);

        eventoAtual = novoEvento;
        eventoAtual.DoEvent();
    }
}
