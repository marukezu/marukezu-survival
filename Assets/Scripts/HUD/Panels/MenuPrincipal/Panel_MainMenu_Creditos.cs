using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Panel;

public class Panel_MainMenu_Creditos : Panel
{
    public override PanelType Type => PanelType.MAINMENU_CREDITOS;

    public Text TXT_Credits; 
    public Text TXT_CreditsBack;

    public Button BTN_Back;

    private void Awake()
    {
        BTN_Back.onClick.AddListener(delegate { BtnCreditsVoltar(); });
    }

    public override void AtualizarPainel()
    {
        TXT_Credits.text = LanguageManager.Get("Credits");
        TXT_CreditsBack.text = LanguageManager.Get("Back");
    }
    public void BtnCreditsVoltar()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_BOTOESPRINCIPAIS);

        AudioManager.Instance.PlaySoundEffectButtons(1);
    }
}
