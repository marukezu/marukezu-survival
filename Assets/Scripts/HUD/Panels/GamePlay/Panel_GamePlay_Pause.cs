using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_GamePlay_Pause : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_PAUSE;

    [Header("====== SubPanels ======")]
    public Panel_GamePlay_GameConfiguration Panel_Configuration;
    public Panel_GamePlay_GiveUp Panel_GiveUp;

    [Header("====== Texts ======")]
    public Text TXT_PauseGamePaused;
    public Text TXT_PauseBtnGiveUp;
    public Text TXT_PauseBtnYes;
    public Text TXT_PauseBTNNo;

    [Header("====== Buttons ======")]
    public Button BTN_GameConfiguration;
    public Button BTN_GiveUp;
    public Button BTN_Fechar;

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        BTN_GameConfiguration.onClick.AddListener(delegate { BTN_GameConfiguration_Action(); });
        BTN_GiveUp.onClick.AddListener(delegate { BTN_GiveUP_Action(); });
        BTN_Fechar.onClick.AddListener(delegate { BTN_Fechar_Action(); });

        // Inicializa os subpaineis.
        Panel_Configuration.OcultarPainel();
        Panel_GiveUp.OcultarPainel();
    }

    private void BTN_GameConfiguration_Action()
    {
        Panel_Configuration.AbrirPainel();
    }
    private void BTN_GiveUP_Action()
    {
        AudioManager.Instance.PlaySoundEffectButtons(2);
        Panel_GiveUp.AbrirPainel();
    }

    private void BTN_Fechar_Action()
    {
        // Despausa e retorna chuva
        GameManager.Instance.DesPause(true, 0.5f);
        AudioManager.Instance.PlayChuva(0);

        // Fecha os paineis
        PanelManager.Instance.FecharPainel(PanelType.GAMEPLAY_HEROINFO);
        FecharPainel();
    }
}
