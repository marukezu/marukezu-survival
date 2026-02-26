public class Panel_GamePlay_HeroInfo : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_HEROINFO;

    public Panel_GamePlay_HeroInfo_Spells panel_HeroSpells;
    public Panel_GamePlay_HeroInfo_Hero panel_HeroInfo;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

    }
}
