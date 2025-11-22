using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Kael : Hero
{
    public Hero_Kael(int level)
    {
        typeHero = HeroType.Kael;
        heroPortrait = SpritesManager.Instance.heroesSprites.KaelPortrait;
        heroName = "Kael";
        heroDescription = LanguageManager.Get("Kael Description");
        heroLevel = level;
    }
}
