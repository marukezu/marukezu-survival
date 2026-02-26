public class CircularCuts : Spell
{
    public CircularCuts(): base()
    {
        TypeSpell = SpellType.ACTIVE_CIRCULARCUTS;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_CircularCuts;
        Name = LanguageManager.Get(LanguageTexts_Spells.SpellWords.CircularCuts_Name);
        BaseDmg = 4f;
        BaseCooldown = 7f;
        PoderImpulsao = 0.15f;
        LevelMax = 8;
        Descricao = LanguageManager.Get(LanguageTexts_Spells.SpellWords.CircularCuts_Desc);
    }
}
