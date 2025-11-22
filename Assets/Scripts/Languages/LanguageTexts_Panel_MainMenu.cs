using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Panel_MainMenu
{
    private static void Register_SceneMainMenu_Panels_Texts()
    {
        // Menu Principal
        LanguageManager.Register("Upgrades", "Melhorias", "Upgrades");
        LanguageManager.Register("Bestiary", "Bestiário", "Bestiary");

        // Seleção de Personagem
        LanguageManager.Register("Select Character", "Selecione o Personagem", "Select Your Character");
        LanguageManager.Register("MaxHP", "Vida Máxima:", "Max Health:");
        LanguageManager.Register("Vel Mov", "Vel. Movimento:", "Mov. Speed:");
        LanguageManager.Register("Collect Radius", "Distância Coleta:", "Collect Distance:");
        LanguageManager.Register("Cooldown Reduction", "Redução Recarga:", "Cooldown Reduction:");
        LanguageManager.Register("Damage Boost", "Aumento Dano:", "Damage Boost:");

        // Seleção de Spell
        LanguageManager.Register("Spell1", "Flecha", "Arrow");
        LanguageManager.Register("Spell2", "Lança de Gelo", "Icicle");
        LanguageManager.Register("Spell3", "Trovão", "Thunder");
        LanguageManager.Register("Select First Weapon", "Selecionar Arma Inicial", "Select First Weapon");

        // Seleção de Fase
        LanguageManager.Register("Level Select", "Escolha a Fase", "Level Select");
        LanguageManager.Register("Fase01", "Floresta da Lamentação", "Wailing Forest");
        LanguageManager.Register("Fase02", "Sertão Ventoso", "Windy Backlands");
        LanguageManager.Register("Start Game", "Começar Jogo", "Start Game");

        // Menu Upgrade
        LanguageManager.Register("Upgrade Store", "Loja de Melhorias", "Upgrade Store");

        // Loja
        LanguageManager.Register("Shop", "Loja", "Store");
        LanguageManager.Register("Relics", "Relíquias", "Relics");
        LanguageManager.Register("Relic Description",
            "Relíquias são ativadas periodicamente, elas fornecem poderes adicionais ao heroi. Visite o bestiário para mais informações",
            "Relics are activated periodically; they grant additional powers to the hero. Visit the bestiary for more information");

        // Bestiário
        LanguageManager.Register("Killed", "Mortos:", "Killed:");
        LanguageManager.Register("Health", "Pontos Vida:", "Health:");
        LanguageManager.Register("Speed", "Velocidade:", "Speed:");

        // Descrições de monstros Fase 01
        LanguageManager.Register("Skeleton Description",
            "Nas sombras da floresta chuvosa, o Esqueleto da Chuva emerge, ossos úmidos brilhando sob as gotas incessantes. Seus olhos vazios refletem a melancolia eterna, um eco do passado na sinfonia da chuva.",
            "In the shadows of the rainy forest, the Rain Skeleton emerges, damp bones glistening beneath the ceaseless drops. His empty eyes reflect eternal melancholy, an echo of the past in the symphony of rain.");
        LanguageManager.Register("Bat Description",
            "Entre as árvores da floresta chuvosa, o Morcego das Chuvas desliza silenciosamente. Suas asas encharcadas refletem a penumbra da noite, olhos luminosos cortam a escuridão. Uma criatura ágil, mestre da furtividade nas sombras da chuva.",
            "Among the trees of the rain forest, the Rain Bat glides silently. Its drenched wings reflect the gloom of the night, luminous eyes cut through the darkness. An agile creature, master of stealth in the rain shadows.");
        LanguageManager.Register("Wolf Description",
            "Na tempestade noturna, o Lobo Sombrio emerge da escuridão da floresta. Pelagem encharcada, olhos de rubi brilham intensamente. Uma figura imponente, ele uiva na sinfonia da chuva, marcando seu território na noite úmida.",
            "In the night storm, the Dark Wolf emerges from the darkness of the forest. Fur soaked, ruby eyes shine brightly. An imposing figure, he howls in the symphony of rain, marking his territory in the damp night.");
        LanguageManager.Register("Zombie Description",
            "Sob as gotas incessantes, o Morto-Vivo das Chuvas Eternas vagueia. Pele pálida, roupas esfarrapadas pingam água, olhos sem vida refletem a tristeza eterna. Uma presença espectral na sinfonia molhada da floresta.",
            "Beneath the ceaseless drops, the Undead of Eternal Rains wanders. Pale skin, tattered clothes drip water, lifeless eyes reflect eternal sadness. A spectral presence in the wet symphony of the forest.");
        LanguageManager.Register("DeadTree Description",
            "Sob a chuva incessante, a Árvore Sinistra, ergue-se ameaçadora. Galhos retorcidos formam garras, folhas afiadas como lâminas. Uma sentinela sinistra, pronta para proteger a floresta contra invasores.",
            "Under the incessant rain, the Sinister Tree stands threateningly. Twisted branches form claws, leaves sharp like blades. A sinister sentry, ready to protect the forest against invaders.");
        LanguageManager.Register("Spider Description", "Para implementar", "Para implementar");

        // Menu Options
        LanguageManager.Register("Game Options", "Opções de Jogo", "Game Options");
        LanguageManager.Register("Music Volume", "Volume da Música:", "Music Volume:");
        LanguageManager.Register("Sound Effect Volume", "Volume de Efeitos:", "Effects Volume:");
        LanguageManager.Register("Sound Chuva Volume", "Volume Efeitos de Clima:", "Weather Effects Volume:");
        LanguageManager.Register("Sound Trovão Volume", "Volume dos Trovões:", "Thunder Volume:");

        // Créditos
        LanguageManager.Register("Credits", "Créditos", "Credits");
    }

    public static void RegisterAll()
    {
        Register_SceneMainMenu_Panels_Texts();
    }
}
