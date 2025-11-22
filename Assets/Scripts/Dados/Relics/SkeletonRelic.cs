public class SkeletonRelic : Relic
{
    public SkeletonRelic() : base()
    {
        relicType = RelicType.SKELETON;
        SpriteIcon = SpritesManager.Instance.relicsSprites.Relics_Skeleton;
        SpriteIconFade = SpritesManager.Instance.relicsSprites.Relics_Skeleton_Fade;
        Cooldown = 30f;
        DuracaoEfeito = 2f;
        Active = PlayerConfig.SkeletonRelicAdquired;
    }
}
