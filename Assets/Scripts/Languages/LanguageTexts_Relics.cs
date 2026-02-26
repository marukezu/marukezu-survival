public static class LanguageTexts_Relics
{
    public enum RelicWords
    {
        Skeleton_Name,
        Skeleton_Desc,

        Bat_Name,
        Bat_Desc,

        Wolf_Name,
        Wolf_Desc,

        Zombie_Name,
        Zombie_Desc,

        DeadTree_Name,
        DeadTree_Desc,
    }

    public static readonly LangEntry<RelicWords>[] Entries =
    {
        new(RelicWords.Skeleton_Name,
            "Relíquia Esqueleto",
            "Skeleton Relic"),

        new(RelicWords.Skeleton_Desc,
            "Alcance a imortalidade momentânea! Garante imunidade a todos os tipos de dano por alguns segundos.",
            "Achieve momentary immortality! Grants immunity to all damage types for a few seconds."),

        new(RelicWords.Bat_Name,
            "Relíquia do Morcego",
            "Bat Relic"),

        new(RelicWords.Bat_Desc,
            "Renascimento noturno! Regenera uma pequena parte dos pontos de vida por alguns segundos.",
            "Night rebirth! Regenerates a small portion of health points for a few seconds."),

        new(RelicWords.Wolf_Name,
            "Relíquia do Lobo",
            "Wolf Relic"),

        new(RelicWords.Wolf_Desc,
            "Desperte a ferocidade do lobo! (coloque a descrição completa quando quiser)",
            "Awaken the ferocity of the wolf!"),

        new(RelicWords.Zombie_Name,
            "Relíquia Zumbi",
            "Zombie Relic"),

        new(RelicWords.Zombie_Desc,
            "Levante os mortos! (coloque a descrição completa quando quiser)",
            "Raise the dead!"),

        new(RelicWords.DeadTree_Name,
            "Relíquia da Árvore Morta",
            "DeadTree Relic"),

        new(RelicWords.DeadTree_Desc,
            "Sinta a força da árvore ancestral! (coloque a descrição completa quando quiser)",
            "Feel the power of the ancient tree!"),
    };
}
