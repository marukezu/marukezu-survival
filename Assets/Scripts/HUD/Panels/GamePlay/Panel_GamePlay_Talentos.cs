using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_Talentos : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_TALENTS;

    [Header("====== Textos do Painel ======")]
    public TextMeshProUGUI TXT_TalentsSelection;
    public TextMeshProUGUI TXT_TalentPoints;
    public TextMeshProUGUI TXT_Elemental;
    public TextMeshProUGUI TXT_StatusBase;
    public TextMeshProUGUI TXT_Chances;
    public TextMeshProUGUI TXT_Multipliers;

    [Header("====== Botões ======")]
    public Button BTN_ConfirmarEscolha;
    public Button BTN_CancelarEscolha;

    [Header("====== Textos de Botões ======")]
    public TextMeshProUGUI TXT_BTN_ConfirmarEscolha;
    public TextMeshProUGUI TXT_BTN_CancelarEscolha;

    private Hero_Talents liveTalents;
    private Hero_Talents backupTalents;

    public override void Initialize(object param1 = null, object param2 = null, object param3 = null)
    {
        // Listener dos buttons.
        BTN_ConfirmarEscolha.onClick.AddListener(BTN_Confirmar_Escolha_Action);
        BTN_CancelarEscolha.onClick.AddListener(BTN_Cancelar_Escolha_Action);

        // Textos do painel.
        TXT_TalentsSelection.text = LanguageManager.Get(LanguageTexts_Panel_GamePlay.PanelGamePlayWords.TalentSelection);
        TXT_Elemental.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Elemental);
        TXT_StatusBase.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.StatusBase);
        TXT_Chances.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Chances);
        TXT_Multipliers.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Multipliers);
        TXT_BTN_ConfirmarEscolha.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.ConfirmarEscolha);
        TXT_BTN_CancelarEscolha.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.CancelarEscolha);
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        // Cria uma cópia do Hero_Talents atual.
        liveTalents = GameManager.Instance.playerHero.heroTalents;
        backupTalents = liveTalents.Clone(); // snapshot pra rollback

        // Pausa o jogo e a chuva.
        GameManager.Instance.PausarGame();
        AudioManager.Instance.StopChuva();
    }

    public override void AtualizarPainel()
    {
        string pontosTalentos = liveTalents.PontosTalentos.ToString();
        TXT_TalentPoints.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.TalentPoints) + ": " + pontosTalentos;
    }

    // ================================================================
    // ======================== AÇÃO DE BOTÕES ========================
    // ================================================================
    private void BTN_Confirmar_Escolha_Action()
    {
        // Retorna valores padrões.
        GameManager.Instance.DesPause(true, 0.5f);
        AudioManager.Instance.PlayChuva(0);

        // Fecha os paineis.
        PanelManager.Instance.FecharPainel(PanelType.GAMEPLAY_HEROINFO);
        PanelManager.Instance.FecharPainel(PanelType.GAMEPLAY_TALENTS);
    }

    private void BTN_Cancelar_Escolha_Action()
    {
        liveTalents.CopyFrom(backupTalents);

        EventBus.On_Panel_Talents_CancelChoise?.Invoke();
    }
}
