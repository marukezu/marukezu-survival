public class Cyclone : Spell
{
    public Cyclone() : base()
    {
        TypeSpell = SpellType.ACTIVE_CYCLONE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Cyclone;
        Name = LanguageManager.Get("Cyclone Name");
        BaseDmg = 11f;
        BaseCooldown = 7f;
        PoderImpulsao = 0.25f;
        LevelMax = 7;
        Descricao = LanguageManager.Get("Cyclone Description");
    }
}
