using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Talents
{
    private class TalentData
    {
        public string Id { get; private set; }          // Identificador único
        public string NamePT { get; private set; }      // Nome em português
        public string NameEN { get; private set; }      // Nome em inglês
        public string DescriptionPT { get; private set; }// Descrição em português
        public string DescriptionEN { get; private set; }// Descrição em inglês

        public TalentData(string id, string namePT, string nameEN, string descPT, string descEN)
        {
            Id = id;
            NamePT = namePT;
            NameEN = nameEN;
            DescriptionPT = descPT;
            DescriptionEN = descEN;
        }
    }

    private static List<TalentData> talents = new List<TalentData>()
    {
        new TalentData(
            "Brutamontes",
            "Brutamontes",
            "Brutamontes",
            $"Aumenta o dano físico em {Hero_Talents.BRUTAMONTES_BASE_BUFF}% por nível.",
            $"Increases physical damage by {Hero_Talents.BRUTAMONTES_BASE_BUFF}% per level."
        ),
        new TalentData(
            "Piromaniaco",
            "Piromaniaco",
            "Pyromaniac",
            $"Aumenta o dano de fogo em {Hero_Talents.PIROMANIACO_BASE_BUFF}% por nível.",
            $"Increases fire damage by {Hero_Talents.PIROMANIACO_BASE_BUFF}% per level."
        ),
        new TalentData(
            "Tesla",
            "Tesla",
            "Tesla",
            $"Aumenta o dano elétrico em {Hero_Talents.TESLA_BASE_BUFF}% por nível.",
            $"Increases electric damage by {Hero_Talents.TESLA_BASE_BUFF}% per level."
        ),
        new TalentData(
            "Toque Congelante",
            "Toque Congelante",
            "Freezing Touch",
            $"Aumenta o dano de gelo em {Hero_Talents.TOQUE_CONGELANTE_BASE_BUFF}% por nível.",
            $"Increases ice damage by {Hero_Talents.TOQUE_CONGELANTE_BASE_BUFF}% per level."
        ),
        new TalentData(
            "Atirador Elite",
            "Atirador Elite",
            "Elite Shooter",
            $"Aumenta o dano de arcos/bestas em {Hero_Talents.ATIRADOR_ELITE_BASE_BUFF}% por nível.",
            $"Increases bow/crossbow damage by {Hero_Talents.ATIRADOR_ELITE_BASE_BUFF}% per level."
        ),
        new TalentData(
            "Pestilento",
            "Pestilento",
            "Pestilent",
            $"Aumenta o dano venenoso em {Hero_Talents.PESTILENTO_BASE_BUFF}% por nível.",
            $"Increases poison damage by {Hero_Talents.PESTILENTO_BASE_BUFF}% per level."
        ),

        new TalentData(
            "Passo Ligeiro",
            "Passo Ligeiro",
            "Light Step",
            $"Aumenta a velocidade de movimento em {Hero_Talents.PASSO_LIGEIRO_BASE_BUFF}% por nível.",
            $"Increases movement speed by {Hero_Talents.PASSO_LIGEIRO_BASE_BUFF}% per level."
        ),
        new TalentData(
            "Pele Ferro",
            "Pele Ferro",
            "Iron Skin",
            $"Aumenta a vida {Hero_Talents.PELE_FERRO_BASE_BUFF}% por nível.",
            $"Increases health by {Hero_Talents.PELE_FERRO_BASE_BUFF}% per level."
        ),
        new TalentData(
            "Apressado",
            "Apressado",
            "Swift",
            $"Reduz o tempo de recarga em {Hero_Talents.APRESSADO_BASE_BUFF}% por nível.",
            $"Reduces cooldown time by {Hero_Talents.APRESSADO_BASE_BUFF}% per level."
        ),
    };

    public static void RegisterAll()
    {
        foreach (TalentData talent in talents)
        {
            LanguageManager.Register(talent.Id + " Name", talent.NamePT, talent.NameEN);
            LanguageManager.Register(talent.Id + " Description", talent.DescriptionPT, talent.DescriptionEN);
        }
    }
}
