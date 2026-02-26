public static class LanguageTexts_Panel_MainMenu
{
    public enum MainMenuWords
    {
        // Painel (MainMenu) Hero Info
        InformacaoHeroi,
        Selection, 

        // Painel Jogar
        SelectCharacter,
        SelectFirstSpell,

        // Seleção de Fase
        LevelSelect,
        Fase01_Name,
        Fase02_Name,
        StartGame,

        // Menu Upgrade
        UpgradeStore,

        // Loja
        RelicDescription,

        // Descrições de monstros Fase 01
        SkeletonDescription,
        BatDescription,
        WolfDescription,
        ZombieDescription,
        DeadTreeDescription,
        SpiderDescription,
    }

    public static readonly LangEntry<MainMenuWords>[] Entries =
    {
        // Painel (MainMenu) Hero Info
        new(MainMenuWords.InformacaoHeroi, "Informação do Heroi", "Hero Info"),
        new(MainMenuWords.Selection, "Selecão", "Selection"),

        // Painel Jogar
        new(MainMenuWords.SelectCharacter, "Selecione o Personagem", "Select Your Character"),
        new(MainMenuWords.SelectFirstSpell, "Selecione Feitiço Inicial", "Select First Spell"),

        // Seleção de Fase
        new(MainMenuWords.LevelSelect, "Escolha a Fase", "Level Select"),
        new(MainMenuWords.Fase01_Name, "Floresta da Lamentação", "Wailing Forest"),
        new(MainMenuWords.Fase02_Name, "Sertão Ventoso", "Windy Backlands"),
        new(MainMenuWords.StartGame, "Começar Jogo", "Start Game"),

        // Menu Upgrade
        new(MainMenuWords.UpgradeStore, "Loja de Melhorias", "Upgrade Store"),

        // Loja
        new(MainMenuWords.RelicDescription,
            "Relíquias são ativadas periodicamente, elas fornecem poderes adicionais ao heroi. Visite o bestiário para mais informações",
            "Relics are activated periodically; they grant additional powers to the hero. Visit the bestiary for more information"),

        // Descrições de monstros Fase 01
        new(MainMenuWords.SkeletonDescription,
            "Nas sombras da floresta chuvosa, o Esqueleto da Chuva emerge, ossos úmidos brilhando sob as gotas incessantes. Seus olhos vazios refletem a melancolia eterna, um eco do passado na sinfonia da chuva.",
            "In the shadows of the rainy forest, the Rain Skeleton emerges, damp bones glistening beneath the ceaseless drops. His empty eyes reflect eternal melancholy, an echo of the past in the symphony of rain."),

        new(MainMenuWords.BatDescription,
            "Entre as árvores da floresta chuvosa, o Morcego das Chuvas desliza silenciosamente. Suas asas encharcadas refletem a penumbra da noite, olhos luminosos cortam a escuridão. Uma criatura ágil, mestre da furtividade nas sombras da chuva.",
            "Among the trees of the rain forest, the Rain Bat glides silently. Its drenched wings reflect the gloom of the night, luminous eyes cut through the darkness. An agile creature, master of stealth in the rain shadows."),

        new(MainMenuWords.WolfDescription,
            "Na tempestade noturna, o Lobo Sombrio emerge da escuridão da floresta. Pelagem encharcada, olhos de rubi brilham intensamente. Uma figura imponente, ele uiva na sinfonia da chuva, marcando seu território na noite úmida.",
            "In the night storm, the Dark Wolf emerges from the darkness of the forest. Fur soaked, ruby eyes shine brightly. An imposing figure, he howls in the symphony of rain, marking his territory in the damp night."),

        new(MainMenuWords.ZombieDescription,
            "Sob as gotas incessantes, o Morto-Vivo das Chuvas Eternas vagueia. Pele pálida, roupas esfarrapadas pingam água, olhos sem vida refletem a tristeza eterna. Uma presença espectral na sinfonia molhada da floresta.",
            "Beneath the ceaseless drops, the Undead of Eternal Rains wanders. Pale skin, tattered clothes drip water, lifeless eyes reflect eternal sadness. A spectral presence in the wet symphony of the forest."),

        new(MainMenuWords.DeadTreeDescription,
            "Sob a chuva incessante, a Árvore Sinistra, ergue-se ameaçadora. Galhos retorcidos formam garras, folhas afiadas como lâminas. Uma sentinela sinistra, pronta para proteger a floresta contra invasores.",
            "Under the incessant rain, the Sinister Tree stands threateningly. Twisted branches form claws, leaves sharp like blades. A sinister sentry, ready to protect the forest against invaders."),

        new(MainMenuWords.SpiderDescription, "Para implementar", "Para implementar"),
    };
}
