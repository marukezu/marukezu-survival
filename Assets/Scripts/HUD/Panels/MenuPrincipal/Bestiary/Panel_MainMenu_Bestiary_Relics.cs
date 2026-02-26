using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Bestiary_Relics : Panel
{
    [Header("====== Painel Pai ======")]
    [SerializeField] private Panel_MainMenu_Bestiary Panel_Bestiary;

    [Header("====== Content onde será instanciado os botões ======")]
    public GameObject Content_Relics_Buttons;

    [Header("====== Componentes de HUD ======")]
    public Image IMG_Relic;
    public Text TXT_BestiaryRelicDescription;
    public Text TXT_ClockCooldownRelicValue;

    private void Awake()
    {
        Instantiate_Relics_Buttons();
    }

    private void Instantiate_Relics_Buttons()
    {
        var ordenedRelics = RelicList.AllRelics.OrderBy(x => x.ID).ToList();

        foreach (Relic relic in ordenedRelics)
        {
            GameObject newContainer = ContainerManager.Instance.InstantiateAndReturnContainer(ContainerManager.ContainerType.MAINMENU_BESTIARY_BTNBESTIARYITEM, Content_Relics_Buttons);
            Container_BTN_Bestiary_Item containerScript = newContainer.GetComponent<Container_BTN_Bestiary_Item>();
            containerScript.AbrirPainel(relic, Panel_Bestiary);
        }
    }
}
