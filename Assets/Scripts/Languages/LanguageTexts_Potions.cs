using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Potions
{
    private class PotionData
    {
        public string Id { get; private set; }          // Identificador único
        public string NamePT { get; private set; }      // Nome em português
        public string NameEN { get; private set; }      // Nome em inglês
        public string DescriptionPT { get; private set; }// Descrição em português
        public string DescriptionEN { get; private set; }// Descrição em inglês

        public PotionData(string id, string namePT, string nameEN, string descPT, string descEN)
        {
            Id = id;
            NamePT = namePT;
            NameEN = nameEN;
            DescriptionPT = descPT;
            DescriptionEN = descEN;
        }
    }
    private static List<PotionData> potions = new List<PotionData>()
    {
        new PotionData("Potion Explosion", "Poção Explosiva", "Potion Explosion",
            "Explode uma grande área ao seu redor, eliminando inimigos próximos.",
            "Explodes a large area around you, eliminating nearby enemies."),

        new PotionData("Potion Restoration", "Poção Restauradora", "Potion Restoration",
            "Restaura uma parte dos pontos de vida durante alguns segundos.",
            "Restores a portion of your health for a few seconds."),
    };
    public static void RegisterAll()
    {
        foreach (PotionData potion in potions)
        {
            LanguageManager.Register(potion.Id, potion.NamePT, potion.NameEN);
            LanguageManager.Register(potion.Id, potion.DescriptionPT, potion.DescriptionEN);
        }
    }
}
