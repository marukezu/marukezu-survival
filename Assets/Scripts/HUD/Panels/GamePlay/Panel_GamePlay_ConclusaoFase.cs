using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_GamePlay_ConclusaoFase : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_LEVELCONCLUSION;

    public TextMeshProUGUI TXT_GameOver;

    [Header("====== Time Survived Texts ======")]
    public TextMeshProUGUI TXT_TimeSurvivedLabel;
    public TextMeshProUGUI TXT_TimeSurvivedValue;

    [Header("====== Enemies Defeateds Texts ======")]
    public TextMeshProUGUI TXT_EnemiesDefeatedLabel;
    public TextMeshProUGUI TXT_EnemiesDefeatedValue;

    [Header("====== Money Texts ======")]
    public TextMeshProUGUI TXT_MoneyEarned;

    [Header("====== Chests Texts ======")]
    public TextMeshProUGUI TXT_ChestsEarned;

    [Header("====== Buttons Texts ======")]
    public TextMeshProUGUI TXT_BtnMainMenu;


    public Button BTN_VoltarMenu;

    private void Awake()
    {
        BTN_VoltarMenu.onClick.AddListener(delegate { BTN_VoltarMenu_Action(); });
    }

    public override void AtualizarPainel()
    {
        TXT_GameOver.text = LanguageManager.Get("Game Over");

        // Tempo Sobrevivido
        TXT_TimeSurvivedLabel.text = LanguageManager.Get("Time Survived");
        TXT_TimeSurvivedValue.text = LevelController.Instance.TimerDaFase();

        // Money Feito
        TXT_MoneyEarned.text = PlayerImage.moneyFeito.ToString();

        // Baus Adquiridos
        TXT_ChestsEarned.text = PlayerImage.bausRecebidos.ToString();

        // Inimigos derrotados
        TXT_EnemiesDefeatedLabel.text = LanguageManager.Get("Enemys Defeated");
        TXT_EnemiesDefeatedValue.text = PlayerImage.inimigosDerrotados.ToString();

        // Textos de Botões
        TXT_BtnMainMenu.text = LanguageManager.Get("Back");
    }

    public void BTN_VoltarMenu_Action()
    {
        GameManager.Instance.FinishRun();
    }
}
