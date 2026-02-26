using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Panel;

public class Panel_MainMenu_Upgrades : Panel
{
    public override PanelType Type => PanelType.MAINMENU_UPGRADES;

    public Panel_MainMenu_Upgrades_Heroes Painel_Upgrade_Heroes;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        Painel_Upgrade_Heroes.AbrirPainel();
    }
}
