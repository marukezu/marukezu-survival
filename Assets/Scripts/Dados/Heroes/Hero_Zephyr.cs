using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Zephyr : Hero
{
    public Hero_Zephyr(int level)
    {
        typeHero = HeroType.Zephyr;
        heroPortrait = SpritesManager.Instance.heroesSprites.ZephyrPortrait;
        heroName = "Zephyr";
        heroDescription = LanguageManager.Get("Zephyr Description");
        heroLevel = level;
    }
}
