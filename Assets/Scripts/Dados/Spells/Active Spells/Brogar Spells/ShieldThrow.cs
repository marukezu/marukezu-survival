public class ShieldThrow : Spell
{
    public ShieldThrow() : base()
    {
        TypeSpell = SpellType.ACTIVE_SHIELDTHROW;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_ShieldThrow;
        Name = LanguageManager.Get(LanguageTexts_Spells.SpellWords.ShieldThrow_Name);
        BaseDmg = 4f;
        BaseCooldown = 3f;
        PoderImpulsao = 0.1f;
        JumpQuantity = 3;
        LevelMax = 8;
        Descricao = LanguageManager.Get(LanguageTexts_Spells.SpellWords.ShieldThrow_Desc);
    }
}
