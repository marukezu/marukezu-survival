using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Talents
{
    public enum TalentType
    {
        // Damage
        Brutamontes,
        Piromaniaco,
        Tesla,
        ToqueCongelante,
        AtiradorElite,
        Pestilento,

        // Status
        PassoLigeiro,
        PeleFerro,
        Apressado
    }

    public int PontosTalentos { get; private set; } = 0;

    // ============================
    // 🔥 Constantes
    // ============================

    // Pontos de Talento
    public const int TALENTS_PONTOS_POR_LEVEL = 5;

    // Bônus de Dano
    public const float BRUTAMONTES_BASE_BUFF = 2f;
    public const float PIROMANIACO_BASE_BUFF = 2f;
    public const float TESLA_BASE_BUFF = 2f;
    public const float TOQUE_CONGELANTE_BASE_BUFF = 2f;
    public const float ATIRADOR_ELITE_BASE_BUFF = 2f;
    public const float PESTILENTO_BASE_BUFF = 2f;

    // Bônus de Status Secundário
    public const float PASSO_LIGEIRO_BASE_BUFF = 0.25f;
    public const float PELE_FERRO_BASE_BUFF = 1f;
    public const float APRESSADO_BASE_BUFF = 0.15f;

    // ============================
    // 🎯 Níveis Atuais dos Talentos
    // ============================

    // Bônus de Dano
    public float BrutamontesLevel = 0;
    public float PiromaniacoLevel = 0;
    public float TeslaLevel = 0;
    public float ToqueCongelanteLevel = 0;
    public float AtiradorEliteLevel = 0;
    public float PestilentoLevel = 0;

    // Bônus de Status Secundário
    public float PassoLigeiroLevel = 0;
    public float PeleFerroLevel = 0;
    public float ApressadoLevel = 0;

    // ============================
    // ⚙️ Métodos de Controle
    // ============================
    public void AddTalentPoints(int value) => PontosTalentos += value;

    private bool TryConsumeTalentPoint()
    {
        if (PontosTalentos <= 0)
        {
            Debug.LogWarning("Sem pontos de talento disponíveis!");
            return false;
        }

        PontosTalentos--;
        return true;
    }

    // ============================
    // 🔥 Funções de Incremento
    // ============================

    // Bônus de Dano
    public void AddBrutamontesLevel()
    {
        if (TryConsumeTalentPoint())
            BrutamontesLevel++;
    }

    public void AddPiromaniacoLevel()
    {
        if (TryConsumeTalentPoint())
            PiromaniacoLevel++;
    }

    public void AddTeslaLevel()
    {
        if (TryConsumeTalentPoint())
            TeslaLevel++;
    }

    public void AddToqueCongelanteLevel()
    {
        if (TryConsumeTalentPoint())
            ToqueCongelanteLevel++;
    }

    public void AddAtiradorEliteLevel()
    {
        if (TryConsumeTalentPoint())
            AtiradorEliteLevel++;
    }

    public void AddPestilentoLevel()
    {
        if (TryConsumeTalentPoint())
            PestilentoLevel++;
    }

    // Bônus de Status Secundário
    public void AddPassoLigeiroLevel()
    {
        if (TryConsumeTalentPoint())
            PassoLigeiroLevel++;
    }

    public void AddPeleFerroLevel()
    {
        if (TryConsumeTalentPoint())
            PeleFerroLevel++;
    }

    public void AddApressadoLevel()
    {
        if (TryConsumeTalentPoint())
            ApressadoLevel++;
    }
}

