using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_ChooseNewSpell_Kael : Panel
{
    [Header("====== Painel Pai ======")]
    public Panel PanelPai;

    [Header("====== Container onde será instanciado as Spells ======")]
    public GameObject SpellsContainer;

    [Header("====== Textos do Painel ======")]
    public TextMeshProUGUI TXT_LevelUp;
    public TextMeshProUGUI TXT_ChooseSpell;

    [Header("====== Buttons ======")]
    public Button BTN_DistanceSpells;
    public Button BTN_PoisonSpells;

    [Header("====== Buttons Texts ======")]
    public TextMeshProUGUI TXT_Btn_PhysicalSpells;
    public TextMeshProUGUI TXT_Btn_DistanceSpells;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        TXT_LevelUp.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.LevelUp);
        TXT_ChooseSpell.text = LanguageManager.Get(LanguageTexts_Panel_GamePlay.PanelGamePlayWords.ChooseASpell);

        TXT_Btn_PhysicalSpells.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Physical);
        TXT_Btn_DistanceSpells.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Distance);

        BTN_DistanceSpells.onClick.RemoveAllListeners();
        BTN_DistanceSpells.onClick.AddListener(() => BTN_DistanceSpells_Action());

        BTN_PoisonSpells.onClick.RemoveAllListeners();
        BTN_PoisonSpells.onClick.AddListener(() => BTN_PhysicalSpells_Action());

        BTN_PhysicalSpells_Action();
    }

    private void BTN_DistanceSpells_Action()
    {
        List<Spell> kaelDistanceSpells = new List<Spell>();

        foreach (Spell spell in SpellsList.KaelSpells)
        {
            if (spell.SpellElement == Spell.Elemento.DISTANCE)
                kaelDistanceSpells.Add(spell);
        }

        InstantiateSpellContainers(kaelDistanceSpells);
    }

    private void BTN_PhysicalSpells_Action()
    {
        List<Spell> kaelPhysicalSpells = new List<Spell>();

        foreach (Spell spell in SpellsList.KaelSpells)
        {
            if (spell.SpellElement == Spell.Elemento.PHYSICAL)
                kaelPhysicalSpells.Add(spell);
        }

        InstantiateSpellContainers(kaelPhysicalSpells);
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
