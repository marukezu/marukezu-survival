public static class LanguageTexts_Talents
{
    public enum TalentWords
    {
        // Status Base
        DanoBase_Name, DanoBase_Desc,
        VelMov_Name, VelMov_Desc,
        VidaMax_Name, VidaMax_Desc,
        TempoRecarga_Name, TempoRecarga_Desc,

        // Elementais
        Elemento_Fisico_Name, Elemento_Fisico_Desc,
        Elemento_Fogo_Name, Elemento_Fogo_Desc,
        Elemento_Eletrico_Name, Elemento_Eletrico_Desc,
        Elemento_Gelo_Name, Elemento_Gelo_Desc,
        Elemento_Distancia_Name, Elemento_Distancia_Desc,
        Elemento_Veneno_Name, Elemento_Veneno_Desc,

        // Chances
        ChanceCritica_Name, ChanceCritica_Desc,
        ChanceEmpalamento_Name, ChanceEmpalamento_Desc,

        // Multiplicadores
        MultCritica_Name, MultCritica_Desc,
    }

    public static readonly LangEntry<TalentWords>[] Entries =
    {
        // Status Base
        new(TalentWords.DanoBase_Name, "Dano Base", "Base Damage"),
        new(TalentWords.DanoBase_Desc,
            $"Aumenta o dano base em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Dano)}% por nível.",
            $"Increases base damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Dano)}% per level."),

        new(TalentWords.VidaMax_Name, "Vida Máxima", "Max Health"),
        new(TalentWords.VidaMax_Desc,
            $"Aumenta a vida em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.VidaMaxima)}% por nível.",
            $"Increases health by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.VidaMaxima)}% per level."),

        new(TalentWords.TempoRecarga_Name, "Recarga", "Cooldown"),
        new(TalentWords.TempoRecarga_Desc,
            $"Reduz o tempo de recarga em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.TempoRecarga)}% por nível.",
            $"Reduces cooldown time by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.TempoRecarga)}% per level."),

        // Elementais
        new(TalentWords.Elemento_Fisico_Name, "Físico", "Physical"),
        new(TalentWords.Elemento_Fisico_Desc,
            $"Aumenta o dano físico em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Fisico)}% por nível.",
            $"Increases physical damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Fisico)}% per level."),

        new(TalentWords.Elemento_Fogo_Name, "Fogo", "Fire"),
        new(TalentWords.Elemento_Fogo_Desc,
            $"Aumenta o dano de fogo em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Fogo)}% por nível.",
            $"Increases fire damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Fogo)}% per level."),

        new(TalentWords.Elemento_Eletrico_Name, "Elétrico", "Thunder"),
        new(TalentWords.Elemento_Eletrico_Desc,
            $"Aumenta o dano elétrico em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Eletrico)}% por nível.",
            $"Increases electric damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Eletrico)}% per level."),

        new(TalentWords.Elemento_Gelo_Name, "Gelo", "Ice"),
        new(TalentWords.Elemento_Gelo_Desc,
            $"Aumenta o dano de gelo em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Gelo)}% por nível.",
            $"Increases ice damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Gelo)}% per level."),

        new(TalentWords.Elemento_Distancia_Name, "Distância", "Distance"),
        new(TalentWords.Elemento_Distancia_Desc,
            $"Aumenta o dano de arcos/bestas em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Distancia)}% por nível.",
            $"Increases bow/crossbow damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Distancia)}% per level."),

        new(TalentWords.Elemento_Veneno_Name, "Veneno", "Poison"),
        new(TalentWords.Elemento_Veneno_Desc,
            $"Aumenta o dano venenoso em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Veneno)}% por nível.",
            $"Increases poison damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Veneno)}% per level."),

        // Chances
        new(TalentWords.ChanceCritica_Name, "C.Crítico", "Critical C."),
        new(TalentWords.ChanceCritica_Desc,
            $"Aumenta a chance de um acerto crítico em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.ChanceCritica)}% por nível.",
            $"Increases critical hit chance by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.ChanceCritica)}% per level."),

        new(TalentWords.ChanceEmpalamento_Name, "C.Empalamento", "Impalement C."),
        new(TalentWords.ChanceEmpalamento_Desc,
            $"Aumenta a chance de empalamento com ataques físicos em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.ChanceEmpalamento)}% por nível.",
            $"Increases the chance of impalement with physical attacks by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.ChanceEmpalamento)}% per level."),

        // Multiplicadores
        new(TalentWords.MultCritica_Name, "M.Crítico", "Critical M."),
        new(TalentWords.MultCritica_Desc,
            $"Aumenta o multiplicador de dano crítico em {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.MultCritico)}% por nível.",
            $"Increases the multiplier of critical damage by {Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.MultCritico)}% per level."),
    };
}