public class ShieldThrow : Spell
{
    public ShieldThrow() : base()
    {
        TypeSpell = SpellType.ACTIVE_SHIELDTHROW;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_ShieldThrow;
        Name = LanguageManager.Get("Shield Throw Name");
        BaseDmg = 4f;
        BaseCooldown = 3f;
        PoderImpulsao = 0.1f;
        JumpQuantity = 3;
        LevelMax = 8;
        Descricao = LanguageManager.Get("Shield Throw Description");
    }
}
