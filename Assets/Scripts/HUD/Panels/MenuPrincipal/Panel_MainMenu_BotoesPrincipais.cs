using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Panel;

public class Panel_MainMenu_BotoesPrincipais : Panel
{
    public override PanelType Type => PanelType.MAINMENU_BOTOESPRINCIPAIS;

    [Header("====== Texts Painel Esquerdo ======")]
    public Text TXT_Play; 
    public Text TXT_Exit; 
    public Text TXT_Upgrades; 
    public Text TXT_Bestiary;

    [Header("====== Texts Painel Direito ======")]
    public Text TXT_Game_Version;

    [Header("====== BTN Painel Esquerdo ======")]
    public Button BTN_NovoJogo;
    public Button BTN_Upgrades;
    public Button BTN_Shop;
    public Button BTN_Bestiary;
    public Button BTN_CloseGame;
    
    [Header("====== BTN Painel Direito ======")]
    public Button BTN_Options;
    public Button BTN_Credits;
    public Button BTN_ChangeLog;

    private void Awake()
    {
        BTN_NovoJogo.onClick.AddListener(() => BTN_NovoJogo_Action());
        BTN_Upgrades.onClick.AddListener(() => BTN_Upgrades_Action());
        BTN_Shop.onClick.AddListener(() => BTN_Shop_Action());
        BTN_Bestiary.onClick.AddListener(() => BTN_Bestiary_Action());
        BTN_Options.onClick.AddListener(() => BTN_Options_Action());
        BTN_Credits.onClick.AddListener(() => BTN_Credits_Action());
        BTN_ChangeLog.onClick.AddListener(() => BTN_ChangeLog_Action());
        BTN_CloseGame.onClick.AddListener(() => BTN_CloseGame_Action());

        TXT_Play.text = LanguageManager.Get("Play");
        TXT_Exit.text = LanguageManager.Get("Exit");
        TXT_Upgrades.text = LanguageManager.Get("Upgrades");
        TXT_Bestiary.text = LanguageManager.Get("Bestiary");
        TXT_Game_Version.text = GameConfig._gameVersion;
    }

    public void BTN_NovoJogo_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_PLAY);

        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void BTN_Upgrades_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_UPGRADES);

        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void BTN_Shop_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_SHOP);

        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void BTN_Bestiary_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_BESTIARY);

        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void BTN_Options_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_CONFIGURACOES);

        SelecionarResolucaoAtual();
        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void BTN_Credits_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_CREDITOS);
        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void BTN_ChangeLog_Action()
    {
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_CHANGELOG);
        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void BTN_CloseGame_Action()
    {
        SaveManager.SaveGame();
        Application.Quit();
    }

    private void SelecionarResolucaoAtual()
    {
        string resolucaoXAtual = GameConfig._resolucaoXAtual;
        string resolucaoYAtual = GameConfig._resolucaoYAtual;

        int largura = int.Parse(resolucaoXAtual);
        int altura = int.Parse(resolucaoYAtual);

        Resolution resolucaoAtual = new Resolution
        {
            width = largura,
            height = altura
        };

        //int indiceResolucaoAtual = resolucoesDisponiveis.IndexOf(resolucaoAtual);

        //dropdownResolucoes.value = Mathf.Max(0, indiceResolucaoAtual);
    }
}
