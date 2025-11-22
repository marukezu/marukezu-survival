using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Container_BTN_Shop_Potion : Panel
{
    public TextMeshProUGUI TXT_PotionName;
    public Image IMG_PotionIcon;
    public TextMeshProUGUI TXT_PotionQuantity;
    public TextMeshProUGUI TXT_PotionValue;

    private Potion potion;
    private Button BTN_ThisButton;
    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        potion = param1 as Potion;

        BTN_ThisButton = GetComponent<Button>();
        BTN_ThisButton.onClick.RemoveAllListeners();
        BTN_ThisButton.onClick.AddListener(BTN_ThisButton_Action);

        AtualizarDados();
    }

    private void AtualizarDados()
    {
        TXT_PotionName.text = potion.potionName;
        IMG_PotionIcon.sprite = potion.potionIcon;
        TXT_PotionQuantity.text = potion.maxQuantity > potion.playerHave ? "x" + potion.playerHave.ToString("F0") : "MAX";
        TXT_PotionValue.text = potion.potionPrice.ToString("F0");
        TXT_PotionValue.color = PlayerConfig.playerMoney >= potion.potionPrice ? Color.green : Color.red;
    }
    private void BTN_ThisButton_Action()
    {
        // Se o tanto de potions que o jogador tem, for maior ou igual o máximo, retorna.
        if (potion.playerHave >= potion.maxQuantity)
        {
            GetComponent<Animator>().SetTrigger("Max");
            return;
        }

        // Se o jogador tem grana pra comprar
        if (PlayerConfig.playerMoney >= potion.potionPrice)
        {
            StartCoroutine(PanelManager.Instance.FlashColorCoroutine(GetComponent<Image>(), Color.green));
            GetComponent<Animator>().SetTrigger("Positive");
            PlayerConfig.playerMoney -= potion.potionPrice;
            PlayerConfig.BuyPotion(potion.typePotion);
            SaveManager.SaveGame();
            
        }
        else
        {
            StartCoroutine(PanelManager.Instance.FlashColorCoroutine(GetComponent<Image>(), Color.red));
            GetComponent<Animator>().SetTrigger("Negative");
        }

        AtualizarDados();
    }
}
