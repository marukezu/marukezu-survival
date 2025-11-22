using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Broghar : Hero
{
    public Hero_Broghar(int level)
    {
        typeHero = HeroType.Broghar;
        heroPortrait = SpritesManager.Instance.heroesSprites.BrogharPortrait;
        heroName = "Broghar";
        heroDescription = LanguageManager.Get("Broghar Description");
        heroLevel = level;
    }
}
