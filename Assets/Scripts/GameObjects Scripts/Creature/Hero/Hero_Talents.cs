using System;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Talents
{
    public enum TalentType
    {
        // Damage
        Fisico,
        Fogo,
        Eletrico,
        Gelo,
        Distancia,
        Veneno,

        // Status Base
        Dano,
        VelMovimento,
        VidaMaxima,
        TempoRecarga,

        // Chances
        ChanceCritica,
        ChanceEmpalamento,

        // Multiplicadores
        MultCritico,
    }

    public int PontosTalentos { get; private set; } = 0;
    public const int TALENTOS_POR_LEVEL = 5;

    // ✅ Level de cada talento (escala pra 200 fácil)
    private readonly Dictionary<TalentType, int> _levels = new();

    // ✅ Config de cada talento (max e “buff base” etc.)
    private static readonly Dictionary<TalentType, TalentConfig> _config = new()
    {
        // Elementais
        { TalentType.Fisico,                new TalentConfig(maxLevel: 1000, baseBuff: 2f,   cost: 1) },
        { TalentType.Fogo,                  new TalentConfig(maxLevel: 1000, baseBuff: 2f,   cost: 1) },
        { TalentType.Eletrico,              new TalentConfig(maxLevel: 1000, baseBuff: 2f,   cost: 1) },
        { TalentType.Gelo,                  new TalentConfig(maxLevel: 1000, baseBuff: 2f,   cost: 1) },
        { TalentType.Distancia,             new TalentConfig(maxLevel: 1000, baseBuff: 2f,   cost: 1) },
        { TalentType.Veneno,                new TalentConfig(maxLevel: 1000, baseBuff: 2f,   cost: 1) },

        // Status Base
        { TalentType.Dano,                  new TalentConfig(maxLevel: 1000, baseBuff: 1f,   cost: 1) },
        { TalentType.VelMovimento,          new TalentConfig(maxLevel: 1000, baseBuff: 0.25f,cost: 1) },
        { TalentType.VidaMaxima,            new TalentConfig(maxLevel: 1000, baseBuff: 1f,   cost: 1) },
        { TalentType.TempoRecarga,          new TalentConfig(maxLevel: 100,  baseBuff: 0.5f, cost: 1) },
        
        // Chances
        { TalentType.ChanceCritica,         new TalentConfig(maxLevel: 50,  baseBuff: 1f, cost: 1) },
        { TalentType.ChanceEmpalamento,     new TalentConfig(maxLevel: 50,  baseBuff: 1f, cost: 1) },

        // Multiplicadores
        { TalentType.MultCritico,           new TalentConfig(maxLevel: 100,  baseBuff: 2.5f, cost: 1) },
    };

    // ============================
    // Construtores
    // ============================
    public Hero_Talents() { }

    public Hero_Talents(Hero_Talents toCopy)
    {
        if (toCopy == null) throw new ArgumentNullException(nameof(toCopy));

        PontosTalentos = toCopy.PontosTalentos;

        // copia os levels
        foreach (var kv in toCopy._levels)
            _levels[kv.Key] = kv.Value;
    }

    public Hero_Talents Clone() => new Hero_Talents(this);

    public void CopyFrom(Hero_Talents other)
    {
        PontosTalentos = other.PontosTalentos;

        _levels.Clear();
        foreach (var kv in other._levels)
            _levels[kv.Key] = kv.Value;
    }

    // ============================
    // ⚙️ API pública (simples)
    // ============================
    public void AddTalentPoints(int value) => PontosTalentos += value;

    public int GetLevel(TalentType type)
        => _levels.TryGetValue(type, out var lv) ? lv : 0;

    public static float GetBaseBuff(TalentType type) => GetConfig(type).BaseBuff;
    public static int GetMaxLevel(TalentType type) => GetConfig(type).MaxLevel;
    public static int GetCost(TalentType type) => GetConfig(type).Cost;

    // Método pra upar qualquer talento
    public bool TryUpgrade(TalentType type)
    {
        var cfg = GetConfig(type);
        int currentLevel = GetLevel(type);

        if (currentLevel >= cfg.MaxLevel)
            return false;

        if (!TryConsumeTalentPoints(cfg.Cost))
            return false;

        _levels[type] = currentLevel + 1;
        return true;
    }

    // ============================
    // Internos
    // ============================
    private static TalentConfig GetConfig(TalentType type)
    {
        if (_config.TryGetValue(type, out var cfg))
            return cfg;

        Debug.LogError($"Talent sem config: {type}");
        return default;
    }

    private bool TryConsumeTalentPoints(int cost)
    {
        if (PontosTalentos < cost)
        {
            Debug.LogWarning("Sem pontos de talento disponíveis!");
            return false;
        }

        PontosTalentos -= cost;
        return true;
    }

    private readonly struct TalentConfig
    {
        public readonly int MaxLevel;
        public readonly float BaseBuff;
        public readonly int Cost;

        public TalentConfig(int maxLevel, float baseBuff, int cost)
        {
            MaxLevel = maxLevel;
            BaseBuff = baseBuff;
            Cost = cost;
        }
    }
}
