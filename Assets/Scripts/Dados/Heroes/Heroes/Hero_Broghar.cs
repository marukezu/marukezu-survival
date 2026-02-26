public class Hero_Broghar : Hero
{
    public Hero_Broghar(int level)
    {
        typeHero = HeroType.Broghar;
        heroPortrait = SpritesManager.Instance.heroesSprites.BrogharPortrait;
        heroName = "Broghar";
        heroDescription = LanguageManager.Get(LanguageTexts_Heroes.HeroWords.Broghar_Desc);

        cards.heroLevel = level;
    }
}
