public class BatRelic : Relic
{
    public BatRelic() : base()
    {
        relicType = RelicType.BAT;
        SpriteIcon = SpritesManager.Instance.relicsSprites.Relics_Bat;
        SpriteIconFade = SpritesManager.Instance.relicsSprites.Relics_Bat_Fade;
        Cooldown = 180f;
        DuracaoEfeito = 3f;
        Active = PlayerConfig.BatRelicAdquired;
    }
}
