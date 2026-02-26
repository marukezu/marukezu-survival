public static class LanguageTexts_Potions
{
    public enum PotionWords
    {
        PotionExplosion_Name,
        PotionExplosion_Desc,

        PotionRestoration_Name,
        PotionRestoration_Desc,
    }

    public static readonly LangEntry<PotionWords>[] Entries =
    {
        new(PotionWords.PotionExplosion_Name,
            "Poção Explosiva",
            "Potion Explosion"),

        new(PotionWords.PotionExplosion_Desc,
            "Explode uma grande área ao seu redor, eliminando inimigos próximos.",
            "Explodes a large area around you, eliminating nearby enemies."),

        new(PotionWords.PotionRestoration_Name,
            "Poção Restauradora",
            "Potion Restoration"),

        new(PotionWords.PotionRestoration_Desc,
            "Restaura uma parte dos pontos de vida durante alguns segundos.",
            "Restores a portion of your health for a few seconds."),
    };
}
