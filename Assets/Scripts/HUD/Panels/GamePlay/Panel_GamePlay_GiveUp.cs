using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Panel;

public class Panel_GamePlay_GiveUp : Panel
{
    [Header("====== Painel Pai ======")]
    public Panel_GamePlay_Pause Panel_Pause;

    [Header("====== Texts ======")]
    public Text TXT_PauseAreYouSure;

    [Header("====== Buttons ======")]
    public Button BTN_Yes;
    public Button BTN_No;

    public override void Initialize(object param1 = null, object param2 = null, object param3 = null)
    {
        base.Initialize(param1, param2, param3);

        BTN_Yes.onClick.AddListener(BTN_GiveUp_Yes_Action);
        BTN_No.onClick.AddListener(BTN_GiveUp_No_Action);
    }

    public void BTN_GiveUp_Yes_Action()
    {
        GameManager.Instance.FinishRun();
    }
    public void BTN_GiveUp_No_Action()
    {
        AudioManager.Instance.PlaySoundEffectButtons(0);
        OcultarPainel();
    }
}
