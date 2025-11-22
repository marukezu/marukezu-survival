using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Play_SelecaoSpellInicial : Panel
{

    [Header("====== Painel Pai ======")]
    [SerializeField] private Panel_MainMenu_Play PanelPai;

    [Header("====== Panel Texts ======")]
    public Text TXT_SelectFirstSpell;
    public Text TXT_BtnBack_SelectWeapon;

    [Header("====== Panel Buttons ======")]
    public Button BTN_Voltar;

    [Header("====== Containers Spells ======")]
    public Container_BTN_SelectSpell BTN_Spell1;
    public Container_BTN_SelectSpell BTN_Spell2;
    public Container_BTN_SelectSpell BTN_Spell3;


    // Spells Iniciais de cada Hero
    private Spell ZephyrSpell1, ZephyrSpell2, ZephyrSpell3;
    private Spell KaelSpell1, KaelSpell2, KaelSpell3;
    private Spell BrogarSpell1, BrogarSpell2, BrogarSpell3;

    private void Awake()
    {
        BTN_Voltar.onClick.AddListener(delegate { BTN_Voltar_Action(); });

        // Zephyr spells Inicial.
        ZephyrSpell1 = SpellsList.Icicle;
        ZephyrSpell2 = SpellsList.Thunder;
        ZephyrSpell3 = SpellsList.IgnisArrow;

        // Kael spells Inicial.
        KaelSpell1 = SpellsList.Arrow;
        KaelSpell2 = SpellsList.PoisonKunai;
        KaelSpell3 = SpellsList.PierceDagger;

        // Brogar spells Inicial.
        BrogarSpell1 = SpellsList.AxeThrow;
        BrogarSpell2 = SpellsList.PierceDagger;
        BrogarSpell3 = SpellsList.CircularCuts;

        TXT_SelectFirstSpell.text = LanguageManager.Get("Select First Weapon");
        TXT_BtnBack_SelectWeapon.text = LanguageManager.Get("Back");
    }

    public override void AtualizarPainel()
    {
        switch (HeroImage.heroType)
        {
            case Hero.HeroType.Zephyr:
                BTN_Spell1.AbrirPainel(ZephyrSpell1, this);
                BTN_Spell2.AbrirPainel(ZephyrSpell2, this);
                BTN_Spell3.AbrirPainel(ZephyrSpell3, this);
                break;

            case Hero.HeroType.Kael:
                BTN_Spell1.AbrirPainel(KaelSpell1, this);
                BTN_Spell2.AbrirPainel(KaelSpell2, this);
                BTN_Spell3.AbrirPainel(KaelSpell3, this);
                break;

            case Hero.HeroType.Broghar:
                BTN_Spell1.AbrirPainel(BrogarSpell1, this);
                BTN_Spell2.AbrirPainel(BrogarSpell2, this);
                BTN_Spell3.AbrirPainel(BrogarSpell3, this);
                break;
        }
    }

    public void BTN_Avancar_Action() // Avança para seleção da fase
    {
        if (HeroImage.active1 != null)
        {
            PanelPai.Goto_LevelSelect();

            AudioManager.Instance.PlaySoundEffectButtons(0);
        }
        else
        {
            AudioManager.Instance.PlaySoundEffectButtons(2);
        }
    }
    public void BTN_Voltar_Action() // Volta para seleção de personagem
    {
        HeroImage.active1 = null;

        PanelPai.Goto_HeroSelect();

        HeroImage.heroType = Hero.HeroType.None;

        AudioManager.Instance.PlaySoundEffectButtons(1);
    }
}
