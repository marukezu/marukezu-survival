using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_Talentos : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_TALENTS;

    [Header("====== Textos do Painel ======")]
    public TextMeshProUGUI TXT_Talents;
    public TextMeshProUGUI TXT_TalentPoints;

    public override void Initialize(object param1 = null, object param2 = null, object param3 = null)
    {
        TXT_Talents.text = LanguageManager.Get("Talents");
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        // Pausa o jogo e a chuva
        GameManager.Instance.PausarGame();
        AudioManager.Instance.StopChuva();
    }

    public override void AtualizarPainel()
    {
        string pontosTalentos = GameManager.Instance.playerHero.heroTalents.PontosTalentos.ToString();
        TXT_TalentPoints.text = LanguageManager.Get("Talent Points") + ": " + pontosTalentos;
    }
}
