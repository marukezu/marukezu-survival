public class CircularCuts : Spell
{
    public CircularCuts(): base()
    {
        TypeSpell = SpellType.ACTIVE_CIRCULARCUTS;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_CircularCuts;
        Name = LanguageManager.Get("Circular Cuts Name");
        BaseDmg = 4f;
        BaseCooldown = 7f;
        PoderImpulsao = 0.15f;
        LevelMax = 8;
        Descricao = LanguageManager.Get("Circular Cuts Description");
    }
}
