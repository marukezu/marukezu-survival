using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance;

    [Header("Intervalos (segundos)")]
    [SerializeField] private Vector2 negativeIntervalRange = new Vector2(150f, 180f); // 2:30–3:00
    [SerializeField] private Vector2 positiveIntervalRange = new Vector2(240f, 360f); // 4:00–6:00 (mais raro)

    [Header("Debug")]
    [SerializeField] private bool logEvents = true;

    // Eventos ativos
    private Event negativeActive;
    private Event positiveActive;

    // Próximos tempos
    private float nextNegativeTime;
    private float nextPositiveTime;

    // Anti-repetição por categoria
    private Type lastNegativeType;
    private Type lastPositiveType;

    // Fonte do tempo (você já usa isso)
    private float Timer => LevelController.Instance.contadorTimerFase;

    // Catálogo de eventos (tipos), com “factory” para instanciar e ler peso/categoria
    private readonly List<EventFactory> factories = new();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        RegisterEvents();

        // agenda inicial
        nextNegativeTime = Timer + UnityEngine.Random.Range(negativeIntervalRange.x, negativeIntervalRange.y);
        nextPositiveTime = Timer + UnityEngine.Random.Range(positiveIntervalRange.x, positiveIntervalRange.y);
    }

    private void Update()
    {
        TickActiveEvents();
        TryStartEvents();
    }

    private void TickActiveEvents()
    {
        float dt = Time.deltaTime;

        if (negativeActive != null)
        {
            negativeActive.UpdateEvent(dt);
            if (negativeActive.IsCompleted)
            {
                lastNegativeType = negativeActive.GetType();
                negativeActive = null;
                nextNegativeTime = Timer + UnityEngine.Random.Range(negativeIntervalRange.x, negativeIntervalRange.y);
            }
        }

        if (positiveActive != null)
        {
            positiveActive.UpdateEvent(dt);
            if (positiveActive.IsCompleted)
            {
                lastPositiveType = positiveActive.GetType();
                positiveActive = null;
                nextPositiveTime = Timer + UnityEngine.Random.Range(positiveIntervalRange.x, positiveIntervalRange.y);
            }
        }
    }

    private void TryStartEvents()
    {
        if (negativeActive == null && Timer >= nextNegativeTime)
        {
            negativeActive = PickWeighted(Event.EventCategory.Negative, lastNegativeType);
            if (negativeActive != null)
            {
                negativeActive.StartEvent();
            }

            nextNegativeTime = float.PositiveInfinity; // evita reentrância até concluir
        }

        if (positiveActive == null && Timer >= nextPositiveTime)
        {
            positiveActive = PickWeighted(Event.EventCategory.Positive, lastPositiveType);
            if (positiveActive != null)
            {
                positiveActive.StartEvent();
            }

            nextPositiveTime = float.PositiveInfinity;
        }
    }

    /// <summary>
    /// Sorteio ponderado com anti-repetição do último tipo (por categoria).
    /// </summary>
    private Event PickWeighted(Event.EventCategory category, Type lastType)
    {
        var list = factories.Where(f => f.Category == category).ToList();
        if (list.Count == 0) return null;

        // tenta evitar repetição direta
        const int maxAttempts = 12;
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            var picked = WeightedPick(list);
            if (picked == null) return null;

            if (lastType == null || picked.Type != lastType || list.Count == 1)
                return picked.Create();
        }

        // fallback: se só caiu repetido, aceita
        var fallback = WeightedPick(list);
        return fallback?.Create();
    }

    private static EventFactory WeightedPick(List<EventFactory> list)
    {
        float total = 0f;
        for (int i = 0; i < list.Count; i++)
            total += Mathf.Max(0.0001f, list[i].Weight);

        float r = UnityEngine.Random.Range(0f, total);
        float acc = 0f;

        for (int i = 0; i < list.Count; i++)
        {
            acc += Mathf.Max(0.0001f, list[i].Weight);
            if (r <= acc)
                return list[i];
        }

        return list[^1];
    }

    /// <summary>
    /// Registre aqui seus eventos (um lugar só).
    /// Você define peso e categoria no registro, sem precisar instanciar toda hora.
    /// </summary>
    private void RegisterEvents()
    {
        factories.Clear();

        // NEGATIVOS
        Add<Event_DoubleSpawnRate>(Event.EventCategory.Negative, weight: 2.0f);
        Add<Event_Boss>(Event.EventCategory.Negative, weight: 1.0f);
        // Add<Event_Siege>(Event.EventCategory.Negative, weight: 1.5f);

        // POSITIVOS (exemplos futuros)
        // Add<Event_DoubleDamage>(Event.EventCategory.Positive, weight: 1.0f);
        // Add<Event_Crit100>(Event.EventCategory.Positive, weight: 0.8f);
    }

    private void Add<T>(Event.EventCategory category, float weight) where T : Event
    {
        factories.Add(new EventFactory(typeof(T), category, weight, () => (Event)Activator.CreateInstance(typeof(T))));
    }

    // ================================
    // Helpers
    // ================================
    private sealed class EventFactory
    {
        public Type Type { get; }
        public Event.EventCategory Category { get; }
        public float Weight { get; }
        private readonly Func<Event> _create;

        public EventFactory(Type type, Event.EventCategory category, float weight, Func<Event> create)
        {
            Type = type;
            Category = category;
            Weight = Mathf.Max(0.0001f, weight);
            _create = create;
        }

        public Event Create() => _create();
    }
}