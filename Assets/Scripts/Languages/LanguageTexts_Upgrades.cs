using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Upgrades
{
    private class UpgradeData
    {
        public string Id { get; private set; }          // Identificador único
        public string NamePT { get; private set; }      // Nome em português
        public string NameEN { get; private set; }      // Nome em inglês
        public string DescriptionPT { get; private set; }// Descrição em português
        public string DescriptionEN { get; private set; }// Descrição em inglês

        public UpgradeData(string id, string namePT, string nameEN, string descPT, string descEN)
        {
            Id = id;
            NamePT = namePT;
            NameEN = nameEN;
            DescriptionPT = descPT;
            DescriptionEN = descEN;
        }
    }

    private static List<UpgradeData> upgrades = new List<UpgradeData>()
    {
        new UpgradeData("Upgrade Relic Skeleton", "Relíquia Esqueleto", "RelicSkeleton",
                        $"Dano das Relíquias de Esqueleto + {Upgrade.RELICSKELETON_UPGRADE_BASE}% por nível",
                        $"Skeleton Relic Damage + {Upgrade.RELICSKELETON_UPGRADE_BASE}% per level"),

        new UpgradeData("Upgrade Relic Bat", "Relíquia Morcego", "RelicBat",
                        $"Dano das Relíquias de Morcego + {Upgrade.RELICBAT_UPGRADE_BASE}% por nível",
                        $"Bat Relic Damage + {Upgrade.RELICBAT_UPGRADE_BASE}% per level"),
    };

    public static void RegisterAll()
    {
        foreach (UpgradeData upgrade in upgrades)
        {
            LanguageManager.Register(upgrade.Id + " Name", upgrade.NamePT, upgrade.NameEN);
            LanguageManager.Register(upgrade.Id + " Description", upgrade.DescriptionPT, upgrade.DescriptionEN);
        }
    }
}
