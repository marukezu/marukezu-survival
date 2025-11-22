using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Panel;

public class Panel_MainMenu_ChangeLog : Panel
{
    public override PanelType Type => PanelType.MAINMENU_CHANGELOG;

    public Button BTN_Voltar;

    private void Awake()
    {
        BTN_Voltar.onClick.AddListener(delegate { BTN_Voltar_Action(); });
    }
    public void BTN_Voltar_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_BOTOESPRINCIPAIS);

        AudioManager.Instance.PlaySoundEffectButtons(1);
    }
}
