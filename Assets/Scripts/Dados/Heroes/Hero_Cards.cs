using System;
using System.Collections.Generic;
using static Hero;

public class Hero_Cards
{
    public Hero hero;

    private static readonly Dictionary<HeroType, HeroPerLevelStats> _perLevel = new()
    {
        { HeroType.Zephyr,  new HeroPerLevelStats(health: 2f, speed: 0.007f, damage: 0.6f, cooldown: 0.20f) },
        { HeroType.Kael,    new HeroPerLevelStats(health: 3f, speed: 0.009f, damage: 0.5f, cooldown: 0.30f) },
        { HeroType.Broghar, new HeroPerLevelStats(health: 4f, speed: 0.005f, damage: 0.4f, cooldown: 0.25f) },
    };

    // Level do heroi
    public int heroLevel;
    public int cardsToNextLevel => GetCardsToNextLevel();

    public Hero_Cards(Hero hero)
    {
        this.hero = hero;
    }

    public static int GetHeroLevel(HeroType typeHero) // Função global para pegar o nivel de algum Hero.
    {
        return typeHero switch
        {
            HeroType.Zephyr => HerosList.Hero_Zephyr.cards.heroLevel,
            HeroType.Kael => HerosList.Hero_Kael.cards.heroLevel,
            HeroType.Broghar => HerosList.Hero_Broghar.cards.heroLevel,
            _ => 0 // valor padrão caso o tipo não seja reconhecido
        };
    }

    // Cards
    protected virtual int GetCardsToNextLevel()
    {
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
        heroCards[hero.typeHero].Invoke();

        // Atualiza o level local também, se for o caso
        heroLevel++;
    }

    private HeroPerLevelStats PerLevel
    {
        get
        {
            if (_perLevel.TryGetValue(hero.typeHero, out var s)) return s;
            throw new InvalidOperationException($"Per-level não configurado para {hero.typeHero}");
        }
    }

    // Gets de Constantes - PER LEVEL
    public float GetHealthPerLevel() => PerLevel.Health;
    public float GetSpeedPerLevel() => PerLevel.Speed;
    public float GetDamagePerLevel() => PerLevel.Damage;
    public float GetCooldownPerLevel() => PerLevel.Cooldown;

    public readonly struct HeroPerLevelStats
    {
        public readonly float Health;
        public readonly float Speed;
        public readonly float Damage;
        public readonly float Cooldown;

        public HeroPerLevelStats(float health, float speed, float damage, float cooldown)
        {
            Health = health;
            Speed = speed;
            Damage = damage;
            Cooldown = cooldown;
        }
    }
}
