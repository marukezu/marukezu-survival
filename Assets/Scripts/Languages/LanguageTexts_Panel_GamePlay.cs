using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Panel_GamePlay
{
    private static void Register_SceneGamePlay_Panels_Texts()
    {
        // Level Up
        LanguageManager.Register("Spell Level", "Nível das Magias", "Spell Level");
        LanguageManager.Register("Choose A Spell", "Escolha um poder", "Choose A Spell");

        // Character Info
        LanguageManager.Register("Character Info", "Informação do Personagem", "Character Information");
        LanguageManager.Register("Max HP", "Vida Máxima", "Max Health");
        LanguageManager.Register("Mov Speed", "Vel. de Movimento", "Mov. Speed");
        LanguageManager.Register("Collect Distance", "Distância de Coleta", "Collect Distance");
        LanguageManager.Register("Cooldown Reduction", "Redução de Recarga", "Cooldown Reduction");
        LanguageManager.Register("Damage Boost", "Aumento de Dano", "Damage Boost");

        // Pause
        LanguageManager.Register("Game Paused", "Jogo Pausado", "Game Paused");
        LanguageManager.Register("Give Up", "Desistir", "Give Up");
        LanguageManager.Register("Are You Sure", "Tem Certeza?", "Are you sure?");

        // Game Over
        LanguageManager.Register("Game Over", "Fim de Jogo", "Game Over");
        LanguageManager.Register("Time Survived", "Tempo Sobrevivido:", "Time Survived:");
        LanguageManager.Register("Enemys Defeated", "Inimigos Derrotados:", "Enemys Defeated:");

        // Level Completed
        LanguageManager.Register("Level Completed", "Nível Completo", "Level Completed");
        LanguageManager.Register("Fase02 Unlocked", "Sertão Ventoso Desbloqueado!!", "Windy Backlands Unlocked!!");
    }

    public static void RegisterAll()
    {
        Register_SceneGamePlay_Panels_Texts();
    }
}
