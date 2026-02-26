using System;
using static LanguageTexts_Panel_MainMenu;

public static class LanguageTexts_BasicWords
{
    public enum BasicWords
    {
        // Basic Verbs
        Yes, No, Next, Back, Play, Exit,

        // Leveling
        Level, LevelUp,

        // Spells
        Spell, SpellLevel,
        Spell_Element_Physical,
        Spell_Element_Distance,
        Spell_Element_Fire,
        Spell_Element_Ice,
        Spell_Element_Thunder,
        Spell_Element_Poison,

        // Talents
        Talents,
        TalentPoints,

        // Hero Info
        CharacterInfo,
        MaxHP,
        MovSpeed,
        Speed,
        CooldownReduction,
        DamageBoost,
        Killed,
        Health,
        CriticalChance,
        ImpalementChance,
        CriticalMultiplier,


        // Menu Options
        GameOptions,
        MusicVolume,
        SoundEffectVolume,
        SoundChuvaVolume,
        SoundTrovaoVolume,

        // Words
        Credits,
        Bestiary,
        Upgrades,
        Shop,
        Relics,
        Elemental,
        StatusBase,
        Chances,
        Multipliers,
        ConfirmarEscolha,
        CancelarEscolha,
    }

    public static readonly LangEntry<BasicWords>[] Entries =
    {
        // Basic Verbs
        new(BasicWords.Yes, "Sim", "Yes"),
        new(BasicWords.No, "Não", "No"),
        new(BasicWords.Next, "Próximo", "Next"),
        new(BasicWords.Back, "Voltar", "Back"),
        new(BasicWords.Play, "Jogar", "Play"),
        new(BasicWords.Exit, "Sair", "Exit"),

        // Leveling
        new(BasicWords.Level, "Nível", "Level"),
        new(BasicWords.LevelUp, "Nível Subiu", "Level Up"),

        // Spells
        new(BasicWords.Spell, "Feitiço", "Spell"),
        new(BasicWords.SpellLevel, "Nível Feitiço", "Spell Level"),
        new(BasicWords.Spell_Element_Physical, "Físico", "Physical"),
        new(BasicWords.Spell_Element_Distance, "Distância", "Distance"),
        new(BasicWords.Spell_Element_Fire, "Fogo", "Fire"),
        new(BasicWords.Spell_Element_Ice, "Gelo", "Ice"),
        new(BasicWords.Spell_Element_Thunder, "Elétrico", "Thunder"),
        new(BasicWords.Spell_Element_Poison, "Veneno", "Poison"),

        // Talents
        new(BasicWords.Talents, "Talentos", "Talents"),
        new(BasicWords.TalentPoints, "Pontos de Talentos", "Talent Points"),

        // Hero Info
        new(BasicWords.CharacterInfo, "Informação do Personagem", "Character Information"),
        new(BasicWords.MaxHP, "Vida Máxima", "Max Health"),
        new(BasicWords.MovSpeed, "Vel. de Movimento", "Mov. Speed"),
        new(BasicWords.Speed, "Velocidade", "Speed"),
        new(BasicWords.CooldownReduction, "Redução de Recarga", "Cooldown Reduction"),
        new(BasicWords.DamageBoost, "Aumento de Dano", "Damage Boost"),
        new(BasicWords.Killed, "Mortos:", "Killed:"),
        new(BasicWords.Health, "Pontos Vida:", "Health:"),
        new(BasicWords.CriticalChance, "Chance Crítica", "Critical Chance"),
        new(BasicWords.ImpalementChance, "Chance Impalamento", "Impalement Chance"),
        new(BasicWords.CriticalMultiplier, "Multiplicador Crítico", "Critical Multiplier"),

        // Menu Options
        new(BasicWords.GameOptions, "Opções de Jogo", "Game Options"),
        new(BasicWords.MusicVolume, "Volume da Música:", "Music Volume:"),
        new(BasicWords.SoundEffectVolume, "Volume de Efeitos:", "Effects Volume:"),
        new(BasicWords.SoundChuvaVolume, "Volume Efeitos de Clima:", "Weather Effects Volume:"),
        new(BasicWords.SoundTrovaoVolume, "Volume dos Trovões:", "Thunder Volume:"),

        // Words
        new(BasicWords.Credits, "Créditos", "Credits"),
        new(BasicWords.Bestiary, "Bestiário", "Bestiary"),
        new(BasicWords.Upgrades, "Melhorias", "Upgrades"),
        new(BasicWords.Shop, "Loja", "Store"),
        new(BasicWords.Relics, "Relíquias", "Relics"),
        new(BasicWords.Elemental, "Elemental", "Elemental"),
        new(BasicWords.StatusBase, "Status Base", "Base Status"),
        new(BasicWords.Chances, "Chances", "Chances"),
        new(BasicWords.Multipliers, "Multiplicadores", "Multipliers"),
        new(BasicWords.ConfirmarEscolha, "Confirmar Escolha", "Confirme Choise"),
        new(BasicWords.CancelarEscolha, "Cancelar Escolhas", "Cancel Choises"),
    };
}
