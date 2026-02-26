public static class LanguageTexts_Events
{
    public enum EventWords
    {
        // Siege
        EventSiegeAnnouncement,
        EventSiegeFinished,

        // Boss
        EventBossAnnouncement,

        // Double Spawn Rate
        EventDoubleSpawnRateAnnouncement,
        EventDoubleSpawnRateFinished,
    }

    public static readonly LangEntry<EventWords>[] Entries =
    {
        // Siege
        new(EventWords.EventSiegeAnnouncement,
            "Um cerco se formou a sua volta, tome cuidado!",
            "A siege has formed around you, be careful!"),

        new(EventWords.EventSiegeFinished,
            "O cerco terminou.",
            "The siege has finished."),

        // Boss
        new(EventWords.EventBossAnnouncement,
            "Um inimigo poderoso entrou para o combate, tome cuidado!",
            "A powerful enemy has entered the fight, be careful!"),

        // Double Spawn Rate
        new(EventWords.EventDoubleSpawnRateAnnouncement,
            "A taxa de spawn dos monstros aumentou! Prepare-se!",
            "The monster spawn rate has increased! Get ready!"),

        new(EventWords.EventDoubleSpawnRateFinished,
            "A taxa de spawn dos monstros retornou ao normal",
            "The monster spawn rate has returned to normal."),
    };
}
