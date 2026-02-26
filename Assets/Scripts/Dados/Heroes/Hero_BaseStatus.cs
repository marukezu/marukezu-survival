using System.Collections.Generic;
using UnityEngine;
using static Hero;

public class Hero_BaseStatus
{
    // BASE PARA TODOS
    public const float BASE_MOVSPEED = 1.5f;
    public const float BASE_MAXHEALTH = 100;
    public const float BASE_COOLDOWN = 0;
    public const float BASE_DAMAGE = 0;

    public Hero hero;

    public Hero_BaseStatus(Hero hero)
    {
        this.hero = hero;
    }

    // Status
    public float heroBaseMaxHealth => GetHeroBaseMaxHealth();
    public float heroBaseMovSpeed => GetHeroBaseMovSpeed();
    public float heroBaseDamagePercent => GetHeroBaseDamage();
    public float heroBaseCooldownPercent => GetHeroBaseCooldown();

    private static readonly Dictionary<HeroType, HeroBaseStats> _baseStats = new()
    {
        { HeroType.Zephyr,  new HeroBaseStats(speed: -0.03f, health: -10f, cooldown: 0f, damage: 0.75f) },
        { HeroType.Kael,    new HeroBaseStats(speed:  0.03f, health:   0f, cooldown: 0f, damage: 0.5f) },
        { HeroType.Broghar, new HeroBaseStats(speed: -0.05f, health:  15f, cooldown: 0f, damage: 0f) },
    };

    // Status
    protected virtual float GetHeroBaseMaxHealth()
    {
        // Vida base + bônus fixo do herói + ganho por nível
        return BASE_MAXHEALTH + GetBaseHealth() + hero.cards.GetHealthPerLevel() * hero.cards.heroLevel;
    }

    protected virtual float GetHeroBaseMovSpeed()
    {
        // Velocidade base + bônus fixo do herói + ganho por nível
        return BASE_MOVSPEED + GetBaseSpeed() + hero.cards.GetSpeedPerLevel() * hero.cards.heroLevel;
    }

    protected virtual float GetHeroBaseCooldown()
    {
        // Cooldown base + bônus fixo do herói + redução por nível
        return BASE_COOLDOWN + GetBaseCooldown() + hero.cards.GetCooldownPerLevel() * hero.cards.heroLevel;
    }

    protected virtual float GetHeroBaseDamage()
    {
        // Dano base + bônus fixo do herói + ganho por nível
        return BASE_DAMAGE + GetBaseDamage() + hero.cards.GetDamagePerLevel() * hero.cards.heroLevel;
    }

    private HeroBaseStats Base
    {
        get
        {
            if (_baseStats.TryGetValue(hero.typeHero, out var s))
                return s;

            Debug.LogError($"[Hero] BaseStats não configurado para: {hero.typeHero}");
            return default;
        }
    }

    public float GetBaseSpeed() => Base.Speed;
    public float GetBaseHealth() => Base.Health;
    public float GetBaseCooldown() => Base.Cooldown;
    public float GetBaseDamage() => Base.Damage;

    public readonly struct HeroBaseStats
    {
        public readonly float Speed;
        public readonly float Health;
        public readonly float Cooldown;
        public readonly float Damage;

        public HeroBaseStats(float speed, float health, float cooldown, float damage)
        {
            Speed = speed;
            Health = health;
            Cooldown = cooldown;
            Damage = damage;
        }
    }
}
