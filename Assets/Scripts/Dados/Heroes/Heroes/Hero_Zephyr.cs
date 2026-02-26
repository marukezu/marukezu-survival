public class Hero_Zephyr : Hero
{
    public Hero_Zephyr(int level)
    {
        typeHero = HeroType.Zephyr;
        heroPortrait = SpritesManager.Instance.heroesSprites.ZephyrPortrait;
        heroName = "Zephyr";
        heroDescription = LanguageManager.Get(LanguageTexts_Heroes.HeroWords.Zephyr_Desc);

        cards.heroLevel = level;
    }
}
