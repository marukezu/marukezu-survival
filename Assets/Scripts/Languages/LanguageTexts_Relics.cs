using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Relics
{
    private class RelicData
    {
        public string Id { get; private set; }          // Identificador único
        public string NamePT { get; private set; }      // Nome em português
        public string NameEN { get; private set; }      // Nome em inglês
        public string DescriptionPT { get; private set; }// Descrição em português
        public string DescriptionEN { get; private set; }// Descrição em inglês

        public RelicData(string id, string namePT, string nameEN, string descPT, string descEN)
        {
            Id = id;
            NamePT = namePT;
            NameEN = nameEN;
            DescriptionPT = descPT;
            DescriptionEN = descEN;
        }
    }

    // ========================================================
    // RELICS
    // ========================================================

    private static List<RelicData> relics = new List<RelicData>()
    {
        new RelicData("Skeleton", "Relíquia Esqueleto", "Skeleton Relic",
            "Alcance a imortalidade momentânea! Garante imunidade a todos os tipos de dano por alguns segundos.",
            "Achieve momentary immortality! Grants immunity to all damage types for a few seconds."),
        new RelicData("Bat", "Relíquia do Morcego", "Bat Relic",
            "Renascimento noturno! Regenera uma pequena parte dos pontos de vida por alguns segundos.",
            "Night rebirth! Regenerates a small portion of health points for a few seconds."),
        new RelicData("Wolf", "Relíquia do Lobo", "Wolf Relic",
            "Desperte a ferocidade do lobo! (coloque a descrição completa quando quiser)",
            "Awaken the ferocity of the wolf!"),
        new RelicData("Zombie", "Relíquia Zumbi", "Zombie Relic",
            "Levante os mortos! (coloque a descrição completa quando quiser)",
            "Raise the dead!"),
        new RelicData("DeadTree", "Relíquia da Árvore Morta", "DeadTree Relic",
            "Sinta a força da árvore ancestral! (coloque a descrição completa quando quiser)",
            "Feel the power of the ancient tree!")
    };

    public static void RegisterAll()
    {
        foreach (RelicData relic in relics)
        {
            LanguageManager.Register(relic.Id + " Name", relic.NamePT, relic.NameEN);
            LanguageManager.Register(relic.Id + " Description", relic.DescriptionPT, relic.DescriptionEN);
        }
    }
}
