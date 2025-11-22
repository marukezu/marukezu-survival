using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel_MainMenu_Shop_Relics : Panel
{
    [Header("====== Textos do Painel ======")]
    public TextMeshProUGUI TXT_Relics;
    public TextMeshProUGUI TXT_RelicsDicas;

    public GameObject Container_Relics;
    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        
    }

    private void InstanciarBotoes()
    {
        // === Limpa todos os objetos filhos do container ===
        foreach (Transform child in Container_Relics.transform)
        {
            Destroy(child.gameObject);
        }

        // === Instancia novos botões de heróis ===
        foreach (Relic relic in RelicList.AllRelics)
        {
            GameObject container = ContainerManager.Instance.InstantiateAndReturnContainer(
                ContainerManager.ContainerType.MAINMENU_SHOP_BTNRELIC,
                Container_Relics
            );

            Container_BTN_Shop_Relic containerScript = container.GetComponent<Container_BTN_Shop_Relic>();
            containerScript.AbrirPainel(relic);
        }
    }
}
