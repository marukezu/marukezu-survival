using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_ChooseNewSpell : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_CHOOSE_NEW_SPELL;

    [Header("====== Panel Components  ======")]
    public TextMeshProUGUI TXT_Choose_A_Spell;

    [Header("====== Containers Scripts  ======")]
    public Panel ZephyrPanel;
    public Panel KaelPanel;

    private void Awake()
    {
        TXT_Choose_A_Spell.text = LanguageManager.Get("Choose A Spell");
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        GameManager.Instance.PausarGame();
        AudioManager.Instance.StopChuva();

        InitializeSubPanel();
    }

    private void InitializeSubPanel()
    {
        ZephyrPanel.OcultarPainel();
        KaelPanel.OcultarPainel();

        // Abre o subPanel pelo hero selecionado.
        switch (HeroImage.heroType)
        {
            case Hero.HeroType.Zephyr:
                ZephyrPanel.AbrirPainel();
                break;

            case Hero.HeroType.Kael:
                KaelPanel.AbrirPainel();
                break;
        }
    }

    public void FinalizarEscolha()
    {
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.GAMEPLAY_TALENTS);
        FecharPainel();
    }
}
