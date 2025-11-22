using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_BasicWords
{
    private static void Register_BasicWords()
    {
        LanguageManager.Register("Yes", "Sim", "Yes");
        LanguageManager.Register("No", "Não", "No");
        LanguageManager.Register("Next", "Próximo", "Next");
        LanguageManager.Register("Back", "Voltar", "Back");
        LanguageManager.Register("Play", "Jogar", "Play");
        LanguageManager.Register("Exit", "Sair", "Exit");
        LanguageManager.Register("Level", "Nível", "Level");
        LanguageManager.Register("Talents", "Talentos", "Talents");
        LanguageManager.Register("Talent Points", "Pontos de Talentos", "Talents Points");
    }

    public static void RegisterAll()
    {
        Register_BasicWords();
    }
}
