using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel_MainMenu_Shop_Potions : Panel
{
    [Header("====== Textos do Painel ======")]
    public TextMeshProUGUI TXT_Potions;
    public TextMeshProUGUI TXT_PotionDicas;

    public GameObject Container_Potions;
    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        InstanciarBotoes();
    }

    private void InstanciarBotoes()
    {
        // === Limpa todos os objetos filhos do container ===
        foreach (Transform child in Container_Potions.transform)
        {
            Destroy(child.gameObject);
        }

        // === Instancia novos botões de heróis ===
        foreach (Potion potion in PotionsList.potions)
        {
            GameObject container = ContainerManager.Instance.InstantiateAndReturnContainer(
                ContainerManager.ContainerType.MAINMENU_SHOP_BTNPOTION,
                Container_Potions
            );

            Container_BTN_Shop_Potion containerScript = container.GetComponent<Container_BTN_Shop_Potion>();
            containerScript.AbrirPainel(potion);
        }
    }
}
