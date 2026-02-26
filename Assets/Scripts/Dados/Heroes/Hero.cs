using UnityEngine;

// Classe que armazena os dados Base de um hero.

public class Hero
{
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
    public Hero_Cards cards;
    public Hero_BaseStatus baseStatus;

    public Hero()
    {
        cards = new Hero_Cards(this);
        baseStatus = new Hero_BaseStatus(this);
    }

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
}
