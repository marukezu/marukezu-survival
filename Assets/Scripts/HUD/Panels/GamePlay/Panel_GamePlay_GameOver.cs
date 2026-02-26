using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_GamePlay_GameOver : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_GAMEOVER;

    public Text TXT_GameOver, TXT_TimeSurvived, TXT_TimeSurvivedValue, TXT_EnemysDefeated, TXT_EnemysDefeatedValue, TXT_MoneyFeito, TXT_BtnBackMenu;

    public Button BTN_VoltarMenu;

    private void Awake()
    {
        BTN_VoltarMenu.onClick.AddListener(delegate { BTN_VoltarMenu_Action(); });
    }

    public override void AtualizarPainel()
    {
        TXT_GameOver.text = LanguageManager.Get(LanguageTexts_Panel_GamePlay.PanelGamePlayWords.GameOver);
        TXT_TimeSurvived.text = LanguageManager.Get(LanguageTexts_Panel_GamePlay.PanelGamePlayWords.TimeSurvived);
        TXT_TimeSurvivedValue.text = LevelController.Instance.TimerDaFase();
        TXT_EnemysDefeated.text = LanguageManager.Get(LanguageTexts_Panel_GamePlay.PanelGamePlayWords.EnemiesDefeated);
        TXT_EnemysDefeatedValue.text = PlayerImage.inimigosDerrotados.ToString();
        TXT_MoneyFeito.text = PlayerImage.moneyFeito.ToString();
        TXT_BtnBackMenu.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Back);
    }

    public void BTN_VoltarMenu_Action()
    {
        GameManager.Instance.FinishRun();
    }
}
