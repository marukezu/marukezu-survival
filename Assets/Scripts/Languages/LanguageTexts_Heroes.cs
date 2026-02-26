public static class LanguageTexts_Heroes
{
    public enum HeroWords
    {
        Broghar_Name, Broghar_Desc,
        Kael_Name, Kael_Desc,
        Zephyr_Name, Zephyr_Desc,
    }

    public static readonly LangEntry<HeroWords>[] Entries =
    {
        // ======================
        // BROGHAR
        new(HeroWords.Broghar_Name,
            "Broghar",
            "Broghar"),

        new(HeroWords.Broghar_Desc,
            "Um anão guerreiro resistente que domina o combate físico. Empunhando escudo e machado, Broghar avança sem medo contra hordas inimigas, causando dano massivo e suportando grandes quantidades de impacto.",
            "A resilient dwarf warrior who masters physical combat. Wielding shield and axe, Broghar fearlessly charges into enemy hordes, dealing massive damage while enduring heavy punishment."),

        // ======================
        // KAEL
        new(HeroWords.Kael_Name,
            "Kael",
            "Kael"),

        new(HeroWords.Kael_Desc,
            "Um ladino ágil e letal que combina ataques físicos e à distância. Kael utiliza lâminas rápidas e projéteis precisos para eliminar inimigos antes que possam reagir.",
            "An agile and deadly rogue who blends physical and ranged attacks. Kael uses swift blades and precise projectiles to eliminate enemies before they can react."),

        // ======================
        // ZEPHYR
        new(HeroWords.Zephyr_Name,
            "Zephyr",
            "Zephyr"),

        new(HeroWords.Zephyr_Desc,
            "Um mago elemental que domina os três poderes primordiais: Fogo, Gelo e Eletricidade. Zephyr alterna entre explosões flamejantes, tempestades congelantes e descargas elétricas devastadoras.",
            "An elemental mage who commands the three primordial forces: Fire, Ice, and Lightning. Zephyr shifts between blazing explosions, freezing storms, and devastating lightning strikes."),
    };
}
