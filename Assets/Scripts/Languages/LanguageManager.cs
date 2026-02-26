using System;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageManager
{
    public enum GameLanguage { PTBR, ENUS }

    public static GameLanguage CurrentLanguage => GameConfig._gameIdioma;

    private static readonly Dictionary<Enum, Dictionary<GameLanguage, string>> texts = new();

    public static void Register(Enum key, string pt, string en)
    {
        if (texts.ContainsKey(key))
        {
            Debug.LogWarning($"Chave duplicada detectada: {key.GetType().Name}.{key}");
            return;
        }

        texts[key] = new Dictionary<GameLanguage, string>
        {
            { GameLanguage.PTBR, pt },
            { GameLanguage.ENUS, en }
        };
    }

    public static void RegisterRange<TKey>(IEnumerable<LangEntry<TKey>> entries) where TKey : Enum
    {
        foreach (var e in entries)
            Register(e.Key, e.PT, e.EN);
    }

    public static string Get(Enum key)
    {
        if (!texts.TryGetValue(key, out var langs))
            return $"*Missing key: {key.GetType().Name}.{key}*";

        return langs.TryGetValue(CurrentLanguage, out var result)
            ? result
            : $"*No translation for {CurrentLanguage}: {key.GetType().Name}.{key}*";
    }
}
