using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Configuracoes : Panel
{
    public override PanelType Type => PanelType.MAINMENU_CONFIGURACOES;

    [Header("====== Configurações de Resolução ======")]
    public Toggle toggleModoJanela;
    public TMP_Dropdown dropdownResolucoes;
    private List<Resolution> resolucoesDisponiveis;

    [Header("====== Textos ======")]
    public Text TXT_OptionsGameOptions; 
    public Text TXT_OptionsMusicVolume; 
    public Text TXT_OptionsSoundEffectsVolume; 
    public Text TXT_OptionsChuvaVolume;
    public Text TXT_OptionsTrovaoVolume; 
    public Text TXT_OptionsBtnBack;

    [Header("====== Sliders de Audio ======")]
    public Slider Slider_Musica; 
    public Slider Slider_EfeitosSonoros; 
    public Slider Slider_Chuva; 
    public Slider Slider_Trovao;

    [Header("====== Botões do Painel ======")]
    public Button BTN_Voltar;

    private void Awake()
    {
        BTN_Voltar.onClick.AddListener(delegate { BTN_Voltar_Action(); });

        SaveManager.LoadOpcoesResolucao();
        CarregaInformacoesDeResolucao();
        PreencherResolucoesDisponiveis();
    }

    private void OnEnable()
    {
        IniciaSlidersVolumes();
    }

    public override void AtualizarPainel()
    {
        TXT_OptionsGameOptions.text = LanguageManager.Get("Game Options");
        TXT_OptionsMusicVolume.text = LanguageManager.Get("Music Volume");
        TXT_OptionsSoundEffectsVolume.text = LanguageManager.Get("Sound Effect Volume");
        TXT_OptionsBtnBack.text = LanguageManager.Get("Back");
        TXT_OptionsChuvaVolume.text = LanguageManager.Get("Sound Chuva Volume");
        TXT_OptionsTrovaoVolume.text = LanguageManager.Get("Sound Trovão Volume");

        OnToggleModoJanelaChanged();
        //OnDropdownResolucoesChanged();

        SetaVolumes();
    }
    private void CarregaInformacoesDeResolucao()
    {
        Screen.fullScreen = (GameConfig._fullScreen);

        int largura = int.Parse(GameConfig._resolucaoXAtual);
        int altura = int.Parse(GameConfig._resolucaoYAtual);

        toggleModoJanela.isOn = GameConfig._fullScreen;

        Screen.SetResolution(largura, altura, toggleModoJanela.isOn);
    }
    public void OnToggleModoJanelaChanged()
    {
        Screen.fullScreen = toggleModoJanela.isOn;
        GameConfig._fullScreen = toggleModoJanela.isOn;
    }
    public void OnDropdownResolucoesChanged()
    {
        // Obtenha a resolução selecionada no Dropdown
        Resolution resolucaoSelecionada = resolucoesDisponiveis[dropdownResolucoes.value];

        // Aplique a nova resolução
        Screen.SetResolution(resolucaoSelecionada.width, resolucaoSelecionada.height, toggleModoJanela.isOn);

        GameConfig._resolucaoXAtual = resolucaoSelecionada.width.ToString();
        GameConfig._resolucaoYAtual = resolucaoSelecionada.height.ToString();
    }
    private void PreencherResolucoesDisponiveis()
    {
        resolucoesDisponiveis = new List<Resolution>(Screen.resolutions);
        dropdownResolucoes.ClearOptions();

        List<TMP_Dropdown.OptionData> opcoes = new List<TMP_Dropdown.OptionData>();

        foreach (var resolucao in resolucoesDisponiveis)
        {
            string descricaoResolucao = $"{resolucao.width}x{resolucao.height}";

            TMP_Dropdown.OptionData opcao = new TMP_Dropdown.OptionData(descricaoResolucao);
            opcoes.Add(opcao);
        }

        dropdownResolucoes.AddOptions(opcoes);

    }
    private void IniciaSlidersVolumes()
    {
        Slider_Musica.value = GameConfig.volumeMusica;
        Slider_EfeitosSonoros.value = GameConfig.volumeSoundEffects;
        Slider_Chuva.value = GameConfig.volumeChuva;
        Slider_Trovao.value = GameConfig.volumeTrovoes;
    }
    private void SetaVolumes()
    {
        GameConfig.volumeMusica = Slider_Musica.value;
        GameConfig.volumeSoundEffects = Slider_EfeitosSonoros.value;
        GameConfig.volumeChuva = Slider_Chuva.value;
        GameConfig.volumeTrovoes = Slider_Trovao.value;
    }
    public void BTN_Voltar_Action()
    {
        OnDropdownResolucoesChanged();

        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_BOTOESPRINCIPAIS);

        SaveManager.SaveGame();
        SaveManager.SalvaOpcoesResolucao();
        AudioManager.Instance.PlaySoundEffectButtons(1);
    }
}
