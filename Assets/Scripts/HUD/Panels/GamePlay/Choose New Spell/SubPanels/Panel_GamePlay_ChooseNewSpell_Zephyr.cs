using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_ChooseNewSpell_Zephyr : Panel
{
    [Header("====== Painel Pai ======")]
    public Panel PanelPai;

    [Header("====== Container onde será instanciado as Spells ======")]
    public GameObject SpellsContainer; 

    [Header("====== Buttons ======")]
    public Button BTN_FireSpells;
    public Button BTN_ThunderSpells;
    public Button BTN_IceSpells;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        BTN_FireSpells.onClick.RemoveAllListeners();
        BTN_FireSpells.onClick.AddListener(() => BTN_FireSpells_Action());

        BTN_ThunderSpells.onClick.RemoveAllListeners();
        BTN_ThunderSpells.onClick.AddListener(() => BTN_ThunderSpells_Action());

        BTN_IceSpells.onClick.RemoveAllListeners();
        BTN_IceSpells.onClick.AddListener(() => BTN_IceSpells_Action());

        BTN_FireSpells_Action();
    }

    private void BTN_FireSpells_Action()
    {
        List<Spell> zephyrFireSpells = new List<Spell>();

        foreach (Spell spell in SpellsList.ZephyrSpells)
        {
            if (spell.SpellElement == Spell.Elemento.FIRE)
                zephyrFireSpells.Add(spell);
        }

        InstantiateSpellContainers(zephyrFireSpells);
    }
    private void BTN_ThunderSpells_Action()
    {
        List<Spell> zephyrThunderSpells = new List<Spell>();

        foreach (Spell spell in SpellsList.ZephyrSpells)
        {
            if (spell.SpellElement == Spell.Elemento.THUNDER)
                zephyrThunderSpells.Add(spell);
        }

        InstantiateSpellContainers(zephyrThunderSpells);
    }
    private void BTN_IceSpells_Action()
    {
        List<Spell> zephyrIceSpells = new List<Spell>();

        foreach (Spell spell in SpellsList.ZephyrSpells)
        {
            if (spell.SpellElement == Spell.Elemento.ICE)
                zephyrIceSpells.Add(spell);
        }

        InstantiateSpellContainers(zephyrIceSpells);
    }

    private void InstantiateSpellContainers(List<Spell> spellList)
    {
        // 1️⃣ Limpar filhos existentes
        foreach (Transform child in SpellsContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // 2️⃣ Instanciar um container para cada spell
        foreach (Spell spell in spellList)
        {
            GameObject newContainer = ContainerManager.Instance.InstantiateAndReturnContainer(
                ContainerManager.ContainerType.SPELL_INFO,
                SpellsContainer
            );

            // 3️⃣ Inicializar o container com a spell correta
            Container_BTN_SelectSpell containerScript = newContainer.GetComponent<Container_BTN_SelectSpell>();
            containerScript.AbrirPainel(spell, PanelPai);
        }
    }
}
