using System.Collections;
using System.Linq;
using UnityEngine;
using static Hero;
using static Hero_GameObject;
using static Panel;

// Essa classe representa o Hero do player.
// Classe usada DURANTE a gameplay.

public static class HeroImage
{
    // Referencia ao Hero escolhido.
    public static Hero.HeroType heroType { get; set; }

    // Atributos do Hero
    public static float heroSpeed => GetHeroSpeed();
    public static float maxHealth => GetHeroMaxHP();
    public static float healthNow { get; private set; }
    public static float delayTakeDamage { get; set; } = 0.2f;
    public static float stepAudioDelay { get; set; } = 0.3f;

    // Dados do level do Heroi
    public static int playerExpTotal { get; set; } = 0;
    public static int playerExpAtual { get; set; } = 0;
    public static int playerLevel { get; set; } = 1;

    // Spells do Hero
    public static Spell active1 { get; set; }
    public static Spell active2 { get; set; }
    public static Spell active3 { get; set; }
    public static Spell active4 { get; set; }
    public static Spell active5 { get; set; }

    public static Spell passive1 { get; set; }
    public static Spell passive2 { get; set; }
    public static Spell passive3 { get; set; }

    public static void PrepareHeroImage()
    {
        healthNow = GetHeroMaxHP();
        playerExpTotal = 0;
        playerExpAtual = 0;
        playerLevel = 1;

        active2 = null;
        active3 = null;
        active4 = null;
        active5 = null;
        passive1 = null;
        passive2 = null;
        passive3 = null;
    }

    public static void ResetHeroImage()
    {
        heroType = HeroType.None;
        playerExpTotal = 0;
        playerExpAtual = 0;
        playerLevel = 1;

        active1 = null;
        active2 = null;
        active3 = null;
        active4 = null;
        active5 = null;
        passive1 = null;
        passive2 = null;
        passive3 = null;
    }

    public static void UpLevel()
    {
        // Adiciona o Level
        playerLevel++;
        playerExpAtual = 0;

        // Adiciona Pontos de Talento
        GameManager.Instance.playerHero.heroTalents.AddTalentPoints(Hero_Talents.TALENTS_PONTOS_POR_LEVEL);

        // Chama os paineis
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.GAMEPLAY_CHOOSE_NEW_SPELL);
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.GAMEPLAY_HEROINFO);
    }

    // ======================================================================================
    // ================================ HEALTH NOW MANIPULATION =============================
    // ======================================================================================
    public static void SetHealthNow(float value)
    {
        healthNow = value;
    }
    public static void AddHealthNow(float value)
    {
        healthNow += value; 

        if (healthNow > maxHealth)
            healthNow = maxHealth;
    }

    // ======================================================================================
    // =============================== GETS STATUS BASICOS HEROI ============================
    // ======================================================================================
    public static float GetHeroSpeed()
    {
        float heroBase = 1.5f, Talents_PassoLigeiro = 0f, totalBonus = 0;

        // Pega a base do Hero
        if (heroType != Hero.HeroType.None)
        {
            Hero heroData = HerosList.heroes.FirstOrDefault(h => h.typeHero == heroType);
            heroBase = heroData.heroBaseMovSpeed;
        }

        // Bloco só é chamado em GamePlay, quando o hero está em cena
        if (GameManager.Instance.playerHero != null)
        {
            // Pega o bonus pelo nível do Talento (Passo Ligeiro)
            Talents_PassoLigeiro = (Hero_Talents.PASSO_LIGEIRO_BASE_BUFF * GameManager.Instance.playerHero.heroTalents.PassoLigeiroLevel) / 100;

            // Pega o bonus pela condition Hasted caso tenha..
            if (GameManager.Instance.playerHero.heroConditions.isHasted)
                totalBonus += 0.30f;
        }

        // Faz o calculo total dos Bonus
        totalBonus += 1 + Talents_PassoLigeiro;

        return heroBase * totalBonus;
    }

    public static float GetHeroDamageBoost()
    {
        float heroBase = 0f, totalBonus = 0;

        // Pega a base do Hero
        if (heroType != Hero.HeroType.None)
        {
            Hero heroData = HerosList.heroes.FirstOrDefault(h => h.typeHero == heroType);
            heroBase = heroData.heroBaseDamagePercent;
        }

        totalBonus = heroBase;

        return totalBonus;
    }

    public static float GetHeroCooldownReduction()
    {
        float heroBase = 0, Talents_Apressado = 0, totalBonus = 0;

        // Pega a base do Hero
        if (heroType != Hero.HeroType.None)
        {
            Hero heroData = HerosList.heroes.FirstOrDefault(h => h.typeHero == heroType);
            heroBase = heroData.heroBaseCooldownPercent;
        }

        // Pega o bonus pelo nível do Talento (Apressado)
        if (GameManager.Instance.playerHero != null)
        {
            Talents_Apressado = Hero_Talents.APRESSADO_BASE_BUFF * GameManager.Instance.playerHero.heroTalents.ApressadoLevel;
        }

        totalBonus = heroBase + Talents_Apressado;

        return totalBonus;
    }

    public static float GetHeroMaxHP()
    {
        float heroBase = 100, Talents_PeleFerro = 0f, totalBonus;

        // Pega a base do Hero
        if (heroType != Hero.HeroType.None)
        {
            Hero heroData = HerosList.heroes.FirstOrDefault(h => h.typeHero == heroType);
            heroBase = heroData.heroBaseMaxHealth;
        }

        // Pega o bonus pelo nível do Talento (Pele de Ferro)
        if (GameManager.Instance.playerHero != null)
        {
            Talents_PeleFerro = (Hero_Talents.PELE_FERRO_BASE_BUFF * GameManager.Instance.playerHero.heroTalents.PeleFerroLevel) / 100;
        }

        // Faz o calculo total dos Bonus
        totalBonus = 1 + Talents_PeleFerro;

        float somaFinal = heroBase * totalBonus;

        return somaFinal;
    }

    public static int GetExpNextLevel()
    {
        if (playerLevel == 1) { return 5; }
        if (playerLevel > 1) { return playerLevel * 5 + 3; }
        return 0;
    }
}
