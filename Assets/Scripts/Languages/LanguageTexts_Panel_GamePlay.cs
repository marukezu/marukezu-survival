using System;

public static class LanguageTexts_Panel_GamePlay
{
    public enum PanelGamePlayWords
    {
        // Level Up
        SpellLevel,
        ChooseASpell,

        // Character Info
        HeroInfo,
        StatusBase,
        ElementalModifier,
        MaxHP,
        MovSpeed,
        CollectDistance,
        CooldownReduction,
        DamageBoost,

        // Talents
        TalentSelection,

        // Pause
        GamePaused,
        GiveUp,
        AreYouSure,

        // Game Over
        GameOver,
        TimeSurvived,
        EnemiesDefeated,

        // Level Completed
        LevelCompleted,
        Fase02Unlocked,
    }

    public static readonly LangEntry<PanelGamePlayWords>[] Entries =
    {
        // Level Up
        new(PanelGamePlayWords.SpellLevel, "Nível das Magias", "Spell Level"),
        new(PanelGamePlayWords.ChooseASpell, "Escolha um poder", "Choose A Spell"),

        // Hero Info
        new(PanelGamePlayWords.HeroInfo, "Informação do Heroi", "Hero Information"),
        new(PanelGamePlayWords.StatusBase, "Status Base", "Base Stats"),
        new(PanelGamePlayWords.ElementalModifier, "Modificadores Elementais", "Elemental Modifiers"),
        new(PanelGamePlayWords.MaxHP, "Vida Máxima", "Max Health"),
        new(PanelGamePlayWords.MovSpeed, "Vel. de Movimento", "Mov. Speed"),
        new(PanelGamePlayWords.CollectDistance, "Distância de Coleta", "Collect Distance"),
        new(PanelGamePlayWords.CooldownReduction, "Redução de Recarga", "Cooldown Reduction"),
        new(PanelGamePlayWords.DamageBoost, "Aumento de Dano", "Damage Boost"),

        // Talents
         new(PanelGamePlayWords.TalentSelection, "Seleção de Talentos", "Talents Selection"),

        // Pause
        new(PanelGamePlayWords.GamePaused, "Jogo Pausado", "Game Paused"),
        new(PanelGamePlayWords.GiveUp, "Desistir", "Give Up"),
        new(PanelGamePlayWords.AreYouSure, "Tem Certeza?", "Are you sure?"),

        // Game Over
        new(PanelGamePlayWords.GameOver, "Fim de Jogo", "Game Over"),
        new(PanelGamePlayWords.TimeSurvived, "Tempo Sobrevivido:", "Time Survived:"),
        new(PanelGamePlayWords.EnemiesDefeated, "Inimigos Derrotados:", "Enemies Defeated:"),

        // Level Completed
        new(PanelGamePlayWords.LevelCompleted, "Nível Completo", "Level Completed"),
        new(PanelGamePlayWords.Fase02Unlocked, "Sertão Ventoso Desbloqueado!!", "Windy Backlands Unlocked!!"),
    };
}
