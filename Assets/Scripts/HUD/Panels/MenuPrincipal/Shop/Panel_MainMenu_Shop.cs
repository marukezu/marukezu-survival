using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Shop : Panel
{
    public override PanelType Type => PanelType.MAINMENU_SHOP;

    [Header("====== Componentes do Painel ======")]
    public TextMeshProUGUI TXT_Shop;
    public TextMeshProUGUI TXT_PlayerMoney;
    public Button BTN_Back;

    [Header("====== Paineis Filhos ======")]
    public Panel_MainMenu_Shop_Potions Panel_Potions;
    public Panel_MainMenu_Shop_Relics Panel_Relics;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);
        
        BTN_Back.onClick.AddListener(() => BTN_Back_Action());

        Panel_Potions.AbrirPainel();
        Panel_Relics.AbrirPainel();
    }

    public override void AtualizarPainel()
    {
        // Componentes do painel.
        TXT_Shop.text = LanguageManager.Get("Shop");

        // Currency do jogador.
        TXT_PlayerMoney.text = PlayerConfig.playerMoney.ToString();
    }

    private void BTN_Back_Action()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_BOTOESPRINCIPAIS);

        AudioManager.Instance.PlaySoundEffectButtons(1);
    }
}
