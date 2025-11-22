public class AxeThrow : Spell
{
    public AxeThrow() : base()
    {
        TypeSpell = SpellType.ACTIVE_AXETHROW;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_AxeThrow;
        Name = LanguageManager.Get("Axe Throw Name");
        BaseDmg = 9;
        BaseCooldown = 4.5f;
        PoderImpulsao = 0.3f;
        LevelMax = 7;
        Descricao = LanguageManager.Get("Axe Throw Description");
    }
}
