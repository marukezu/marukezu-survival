// Classe que simboliza a Base de um hero.

using System;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    // BASE
    public const float BASE_MOVSPEED = 1.5f;
    public const float BASE_MAXHEALTH = 100;
    public const float BASE_COOLDOWN = 0;
    public const float BASE_DAMAGE = 0;

    // BASESPEED
    public const float ZEPHYR_HERO_SPEED = -0.05f;
    public const float KAEL_HERO_SPEED = 0.05f;
    public const float BROGHAR_HERO_SPEED = -0.10f;

    // DAMAGE
    public const int ZEPHYR_HERO_DAMAGE = 5;
    public const int KAEL_HERO_DAMAGE = 3;
    public const int BROGHAR_HERO_DAMAGE = 1;

    // COOLDOWN
    public const int ZEPHYR_HERO_COOLDOWN = 0;
    public const int KAEL_HERO_COOLDOWN = 0;
    public const int BROGHAR_HERO_COOLDOWN = 0;

    // MAX HEALTH
    public const float ZEPHYR_HERO_HEALTH = -20;
    public const float KAEL_HERO_HEALTH = 0;
    public const float BROGHAR_HERO_HEALTH = 25;

    // ========================
    // PER LEVEL

    // MAX HEALTH
    public const float ZEPHYR_HEALTH_PERLEVEL = 3f;
    public const float KAEL_HEALTH_PERLEVEL = 4f;
    public const float BROGHAR_HEALTH_PERLEVEL = 5f;

    // BASESPEED
    public const float ZEPHYR_SPEED_PERLEVEL = 0.007f;
    public const float KAEL_SPEED_PERLEVEL = 0.009f;
    public const float BROGHAR_SPEED_PERLEVEL = 0.005f;

    // DAMAGE
    public const float ZEPHYR_DAMAGE_PERLEVEL = 2.6f;
    public const float KAEL_DAMAGE_PERLEVEL = 2.5f;
    public const float BROGHAR_DAMAGE_PERLEVEL = 2.4f;

    // COOLDOWN
    public const float ZEPHYR_COOLDOWN_PERLEVEL = 0.45f;
    public const float KAEL_COOLDOWN_PERLEVEL = 0.55f;
    public const float BROGHAR_COOLDOWN_PERLEVEL = 0.50f;

    public enum HeroType
    {
        None,
        Zephyr,
        Broghar,
        Kael,
    }

    // Atributos básicos
    public HeroType typeHero;
    public Sprite heroPortrait;
    public string heroName;
    public string heroDescription;

    // Level do heroi
    public int heroLevel;
    public int cardsToNextLevel => GetCardsToNextLevel();

    // Status
    public float heroBaseMaxHealth => GetHeroBaseMaxHealth();
    public float heroBaseMovSpeed => GetHeroBaseMovSpeed();
    public float heroBaseDamagePercent => GetHeroBaseDamage();
    public float heroBaseCooldownPercent => GetHeroBaseCooldown();

    public static Hero GetHero(HeroType typeHero)
    {
        return typeHero switch
        {
            HeroType.Zephyr => HerosList.Hero_Zephyr,
            HeroType.Kael => HerosList.Hero_Kael,
            HeroType.Broghar => HerosList.Hero_Broghar,
            _ => null // valor padrão caso o tipo não seja reconhecido
        };
    }
    public static int GetHeroLevel(HeroType typeHero) // Função global para pegar o nivel de algum Hero.
    {
        return typeHero switch
        {
            HeroType.Zephyr => HerosList.Hero_Zephyr.heroLevel,
            HeroType.Kael => HerosList.Hero_Kael.heroLevel,
            HeroType.Broghar => HerosList.Hero_Broghar.heroLevel,
            _ => 0 // valor padrão caso o tipo não seja reconhecido
        };
    }


    // Cards
    protected virtual int GetCardsToNextLevel()
    {
        // return (int)(10 * Mathf.Pow(2, heroLevel - 1));

        return heroLevel * 10;
    }

    public void UpToNextLevel()
    {
        int cardsToConsume = GetCardsToNextLevel();

        var heroCards = new Dictionary<HeroType, Action>
        {
            { HeroType.Zephyr, () =>
                {
                    PlayerConfig.zephyrCards -= cardsToConsume;
                    PlayerConfig.zephyrLevel = heroLevel + 1;
                }
            },
            { HeroType.Kael, () =>
                {
                    PlayerConfig.kaelCards -= cardsToConsume;
                    PlayerConfig.kaelLevel = heroLevel + 1;
                }
            },
            { HeroType.Broghar, () =>
                {
                    PlayerConfig.brogharCards -= cardsToConsume;
                    PlayerConfig.brogharLevel = heroLevel + 1;
                }
            }
        };

        // Executa a ação correspondente ao herói atual
        heroCards[typeHero].Invoke();

        // Atualiza o level local também, se for o caso
        heroLevel++;
    }



    // Status
    protected virtual float GetHeroBaseMaxHealth()
    {
        // Vida base + bônus fixo do herói + ganho por nível
        return BASE_MAXHEALTH + GetBaseHealth() + GetHealthPerLevel() * heroLevel;
    }

    protected virtual float GetHeroBaseMovSpeed()
    {
        // Velocidade base + bônus fixo do herói + ganho por nível
        return BASE_MOVSPEED + GetBaseSpeed() + GetSpeedPerLevel() * heroLevel;
    }

    protected virtual float GetHeroBaseCooldown()
    {
        // Cooldown base + bônus fixo do herói + redução por nível
        return BASE_COOLDOWN + GetBaseCooldown() + GetCooldownPerLevel() * heroLevel;
    }

    protected virtual float GetHeroBaseDamage()
    {
        // Dano base + bônus fixo do herói + ganho por nível
        return BASE_DAMAGE + GetBaseDamage() + GetDamagePerLevel() * heroLevel;
    }


    // Gets Constantes - BASE
    public float GetBaseSpeed()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_HERO_SPEED,
            HeroType.Kael => KAEL_HERO_SPEED,
            HeroType.Broghar => BROGHAR_HERO_SPEED,
            _ => 0f
        };
    }

    public int GetBaseDamage()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_HERO_DAMAGE,
            HeroType.Kael => KAEL_HERO_DAMAGE,
            HeroType.Broghar => BROGHAR_HERO_DAMAGE,
            _ => 0
        };
    }

    public int GetBaseCooldown()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_HERO_COOLDOWN,
            HeroType.Kael => KAEL_HERO_COOLDOWN,
            HeroType.Broghar => BROGHAR_HERO_COOLDOWN,
            _ => 0
        };
    }

    public float GetBaseHealth()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_HERO_HEALTH,
            HeroType.Kael => KAEL_HERO_HEALTH,
            HeroType.Broghar => BROGHAR_HERO_HEALTH,
            _ => 0f
        };
    }


    // Gets de Constantes - PER LEVEL
    public float GetHealthPerLevel()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_HEALTH_PERLEVEL,
            HeroType.Kael => KAEL_HEALTH_PERLEVEL,
            HeroType.Broghar => BROGHAR_HEALTH_PERLEVEL,
            _ => 1f
        };
    }

    public float GetSpeedPerLevel()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_SPEED_PERLEVEL,
            HeroType.Kael => KAEL_SPEED_PERLEVEL,
            HeroType.Broghar => BROGHAR_SPEED_PERLEVEL,
            _ => 0.05f
        };
    }

    public float GetDamagePerLevel()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_DAMAGE_PERLEVEL,
            HeroType.Kael => KAEL_DAMAGE_PERLEVEL,
            HeroType.Broghar => BROGHAR_DAMAGE_PERLEVEL,
            _ => 0.5f
        };
    }

    public float GetCooldownPerLevel()
    {
        return typeHero switch
        {
            HeroType.Zephyr => ZEPHYR_COOLDOWN_PERLEVEL,
            HeroType.Kael => KAEL_COOLDOWN_PERLEVEL,
            HeroType.Broghar => BROGHAR_COOLDOWN_PERLEVEL,
            _ => 0.25f
        };
    }
}
