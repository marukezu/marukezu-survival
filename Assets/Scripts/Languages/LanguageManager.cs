using System;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageManager
{
    public enum GameLanguage
    {
        PTBR,
        ENUS,
    }

    public static GameLanguage CurrentLanguage => GameConfig._gameIdioma;

    // Armazena todos os textos
    private static readonly Dictionary<string, Dictionary<GameLanguage, string>> texts = new();

    // 🔹 Registra novos textos no sistema
    public static void Register(string key, string pt, string en)
    {
        if (!texts.ContainsKey(key))
        {
            texts[key] = new Dictionary<GameLanguage, string>
        {
            { GameLanguage.PTBR, pt },
            { GameLanguage.ENUS, en }
        };
        }
        else
        {
            Debug.LogWarning($"Chave duplicada detectada: {key}");
        }
    }


    // 🔹 Retorna o texto traduzido
    public static string Get(string key)
    {
        if (!texts.TryGetValue(key, out var langs))
            return $"*Missing key: {key}*";

        if (langs.TryGetValue(CurrentLanguage, out var result))
            return result;

        return $"*No translation for {CurrentLanguage}*";
    }
}
