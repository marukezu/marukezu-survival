public class Terremoto : Spell
{
    public Terremoto() : base()
    {
        TypeSpell = SpellType.ACTIVE_TERREMOTO;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_Terremoto;
        Name = LanguageManager.Get("Terremoto Name");
        BaseDmg = 13f;
        BaseCooldown = 6f;
        PoderImpulsao = 0.35f;
        LevelMax = 7;
        Descricao = LanguageManager.Get("Terremoto Description");
    }
}
