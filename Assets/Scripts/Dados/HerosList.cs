using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HerosList 
{
    // Cria os Hero
    public static Hero_Zephyr Hero_Zephyr = new Hero_Zephyr(PlayerConfig.zephyrLevel);
    public static Hero_Kael Hero_Kael = new Hero_Kael(PlayerConfig.kaelLevel);
    public static Hero_Broghar Hero_Broghar = new Hero_Broghar(PlayerConfig.brogharLevel);

    public static List<Hero> heroes = new List<Hero>()
    {
        Hero_Zephyr, Hero_Kael, Hero_Broghar
    };
}
