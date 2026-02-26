public class Hero_Kael : Hero
{
    public Hero_Kael(int level)
    {
        typeHero = HeroType.Kael;
        heroPortrait = SpritesManager.Instance.heroesSprites.KaelPortrait;
        heroName = "Kael";
        heroDescription = LanguageManager.Get(LanguageTexts_Heroes.HeroWords.Kael_Desc);

        cards.heroLevel = level;
    }
}
