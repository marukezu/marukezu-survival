using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Container_BTN_Shop_Relic : Panel
{
    public TextMeshProUGUI TXT_RelicName;
    public Image IMG_RelicIcon;
    public TextMeshProUGUI TXT_RelicValue;

    private Relic relic;
    private Button BTN_ThisButton;
    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        relic = param1 as Relic;

        BTN_ThisButton = GetComponent<Button>();
        BTN_ThisButton.onClick.RemoveAllListeners();
        BTN_ThisButton.onClick.AddListener(BTN_ThisButton_Action);

        AtualizarDados();
    }

    private void AtualizarDados()
    {

    }
    private void BTN_ThisButton_Action()
    {

    }
}
