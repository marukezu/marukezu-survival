using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic : ThingData
{

    // =========================
    // REGISTRO GLOBAL DE RELICS
    // =========================
    private static int _nextID = 0;
    private static readonly List<Relic> _allRelics = new List<Relic>();

    public static IReadOnlyList<Relic> AllRelics => _allRelics.AsReadOnly();

    public static Relic GetByID(int id) => _allRelics.FirstOrDefault(s => s.ID == id);
    public enum RelicType
    {
        SKELETON,
        BAT,
        WOLF,
        ZOMBIE,
        DEADTREE,
    }
    public override DataType Type => DataType.RELIC;
    public RelicType relicType { get; set; }
    public int ID { get; set; }
    public string Name { get; set; }
    public Sprite SpriteIcon { get; set; }
    public Sprite SpriteIconFade { get; set; }
    public float Cooldown { get; set; }
    public float DuracaoEfeito { get; set; }
    public string Description { get; set; }
    public int Active { get; set; }

    // Construtor para a classe RelicList
    public Relic()
    {
        ID = _nextID++;
        _allRelics.Add(this);
    }

    public float GetRelicDuracaoEfeito()
    {
        switch (relicType)
        {
            case RelicType.SKELETON:
                switch (PlayerConfig.skeletonRelicUpgradeLevel)
                {
                    case 0: return DuracaoEfeito;
                    case 1: return DuracaoEfeito + 0.5f;
                    case 2: return DuracaoEfeito + 1.0f;
                    case 3: return DuracaoEfeito + 1.5f;
                    case 4: return DuracaoEfeito + 2.0f;
                    case 5: return DuracaoEfeito + 2.5f;
                    default: return 0;
                }

            case RelicType.BAT:
                switch (PlayerConfig.batRelicUpgradeLevel)
                {
                    case 0: return DuracaoEfeito;
                    case 1: return DuracaoEfeito + 1f;
                    case 2: return DuracaoEfeito + 2f;
                    case 3: return DuracaoEfeito + 3f;
                    case 4: return DuracaoEfeito + 4f;
                    case 5: return DuracaoEfeito + 5f;
                    default: return 0;
                }
            default: return 0f;
        }
    }
}
