using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Bestiary_Spells : Panel
{ 
    [Header("====== Painel Pai ======")]
    [SerializeField] private Panel_MainMenu_Bestiary Panel_Bestiary;

    [Header("====== Content onde será instanciado os botões ======")]
    public GameObject Content_Spells_Buttons;

    public Image IMG_Spell;
    public Text TXT_Spell_Description, TXT_Spell_Type, TXT_Spell_Damage, TXT_Spell_Cooldown;

    private void Awake()
    {
        Instantiate_Spells_Buttons();
    }

    private void Instantiate_Spells_Buttons()
    {
        // Ordena as spells pela ID.
        var ordenedSpells = SpellsList.AllSpells.OrderBy(x => x.ID).ToList();

        foreach (Spell spell in ordenedSpells)
        {
            GameObject newContainer = ContainerManager.Instance.InstantiateAndReturnContainer(ContainerManager.ContainerType.MAINMENU_BESTIARY_BTNBESTIARYITEM, Content_Spells_Buttons);
            Container_BTN_Bestiary_Item containerScript = newContainer.GetComponent<Container_BTN_Bestiary_Item>();
            containerScript.AbrirPainel(spell, Panel_Bestiary);
        }
    }
}
