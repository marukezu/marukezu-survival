using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Upgrades_Heroes : Panel
{
    [Header("====== Panel Texts ======")]
    public TextMeshProUGUI TXT_HeroesUpgrade;

    [Header("====== Container onde será instanciado os botões ======")]
    public GameObject container_HeroesButtons;

    public Button BTN_Sair;
    public TextMeshProUGUI TXT_BTN_Sair;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        BTN_Sair.onClick.RemoveAllListeners();
        BTN_Sair.onClick.AddListener(delegate { BTN_Sair_Action(); });

        TXT_BTN_Sair.text = LanguageManager.Get("Back");

        InstanciarBotoes();
    }

    private void InstanciarBotoes()
    {
        // === Limpa todos os objetos filhos do container ===
        foreach (Transform child in container_HeroesButtons.transform)
        {
            Destroy(child.gameObject);
        }

        // === Instancia novos botões de heróis ===
        foreach (Hero hero in HerosList.heroes)
        {
            GameObject container = ContainerManager.Instance.InstantiateAndReturnContainer(
                ContainerManager.ContainerType.MAINMENU_UPGRADES_BTNHERO,
                container_HeroesButtons
            );

            Container_BTN_Upgrade_Heroes containerScript = container.GetComponent<Container_BTN_Upgrade_Heroes>();
            containerScript.AbrirPainel(hero);
        }
    }

    private void BTN_Sair_Action()
    {
        // Abre o menu principal
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.MAINMENU_BOTOESPRINCIPAIS);

        // Fecha o painel de upgrades
        PanelManager.Instance.FecharPainel(Panel.PanelType.MAINMENU_UPGRADES);
    }

}
