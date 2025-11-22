public class Reroll : Spell
{
    public Reroll() : base()
    {
        TypeSpell = SpellType.SPECIAL_REROLL;
        Name = LanguageManager.Get("Reroll Name");
        LevelMax = 9999;
        Descricao = LanguageManager.Get("Reroll Description");
    }
}
