using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Spell;

public class Panel_GamePlay_HeroInfo : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_HEROINFO;

    [Header("====== Painel Confirmar Apagar Spell ======")]
    public GameObject Painel_ConfirmarApagarSpell;
    public Button BTN_ConfirmarApagarSpell;
    public Text TXT_BTN_ConfirmarApagarSpell;
    public Button BTN_NegarApagarSpell;
    public Text TXT_BTN_NegarApagarSpell;

    [Header("====== Hero Spells Buttons ======")]
    public Button BTN_SpellActive1;
    public Button BTN_SpellActive2;
    public Button BTN_SpellActive3;
    public Button BTN_SpellActive4;
    public Button BTN_SpellActive5;
    private int botaoSelecionado = -1;

    [Header("====== Hero Spells Images ======")]
    public Text TXT_Spell_Level;
    public Image IMG_magiaAtiva1;
    public Image IMG_magiaAtiva2;
    public Image IMG_magiaAtiva3;
    public Image IMG_magiaAtiva4;
    public Image IMG_magiaAtiva5;
    public Image IMG_magiaPassiva1;
    public Image IMG_magiaPassiva2;
    public Image IMG_magiaPassiva3;

    [Header("====== Hero Spells Texts ======")]
    public Text TXT_magiaAtiva1Level;
    public Text TXT_magiaAtiva2Level;
    public Text TXT_magiaAtiva3Level;
    public Text TXT_magiaAtiva4Level;
    public Text TXT_magiaAtiva5Level;
    public Text TXT_magiaPassiva1Level;
    public Text TXT_magiaPassiva2Level;
    public Text TXT_magiaPassiva3Level;

    [Header("====== Hero Status Info ======")]
    public TextMeshProUGUI TXT_Character_Info;
    public TextMeshProUGUI TXT_Max_HP;
    public TextMeshProUGUI TXT_Mov_Speed;
    public TextMeshProUGUI TXT_Cooldown_Reduction;
    public TextMeshProUGUI TXT_Damage_Boost;
    public TextMeshProUGUI TXT_Max_HP_Value;
    public TextMeshProUGUI TXT_Mov_Speed_Value;
    public TextMeshProUGUI TXT_Cooldown_Reduction_Value;
    public TextMeshProUGUI TXT_Damage_Boost_Value;

    //
    public TextMeshProUGUI TXT_PhysicalBonus_Value;
    public TextMeshProUGUI TXT_DistanceBonus_Value;
    public TextMeshProUGUI TXT_FireBonus_Value;
    public TextMeshProUGUI TXT_ThunderBonus_Value;
    public TextMeshProUGUI TXT_IceBonus_Value;
    public TextMeshProUGUI TXT_PoisonBonus_Value;

    private void Update()
    {
        AtualizaPlayerSpellsLevel();
        CharacterInfoStatus();
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        BTN_ConfirmarApagarSpell.onClick.AddListener(BTN_ConfirmarApagarSpell_Action);
        BTN_NegarApagarSpell.onClick.AddListener(BTN_NegarApagarSpell_Action);

        TXT_BTN_ConfirmarApagarSpell.text = LanguageManager.Get("Yes");
        TXT_BTN_NegarApagarSpell.text = LanguageManager.Get("No");

        Painel_ConfirmarApagarSpell.SetActive(false);

        BTN_SpellActive1.onClick.AddListener(BTN_SpellActive1_Action);
        BTN_SpellActive2.onClick.AddListener(BTN_SpellActive2_Action);
        BTN_SpellActive3.onClick.AddListener(BTN_SpellActive3_Action);
        BTN_SpellActive4.onClick.AddListener(BTN_SpellActive4_Action);
        BTN_SpellActive5.onClick.AddListener(BTN_SpellActive5_Action);
    }

    private void AtualizaPlayerSpellsLevel()
    {
        TXT_Spell_Level.text = LanguageManager.Get("Spell Level");

        AtualizaMagia(HeroImage.active1, IMG_magiaAtiva1, TXT_magiaAtiva1Level, "Ativas");
        AtualizaMagia(HeroImage.active2, IMG_magiaAtiva2, TXT_magiaAtiva2Level, "Ativas");
        AtualizaMagia(HeroImage.active3, IMG_magiaAtiva3, TXT_magiaAtiva3Level, "Ativas");
        AtualizaMagia(HeroImage.active4, IMG_magiaAtiva4, TXT_magiaAtiva4Level, "Ativas");
        AtualizaMagia(HeroImage.active5, IMG_magiaAtiva5, TXT_magiaAtiva5Level, "Ativas");

        AtualizaMagia(HeroImage.passive1, IMG_magiaPassiva1, TXT_magiaPassiva1Level, "Passivas");
        AtualizaMagia(HeroImage.passive2, IMG_magiaPassiva2, TXT_magiaPassiva2Level, "Passivas");
        AtualizaMagia(HeroImage.passive3, IMG_magiaPassiva3, TXT_magiaPassiva3Level, "Passivas");
    }

    private void AtualizaMagia(Spell magia, Image img, Text txtLevel, string tipoMagia)
    {
        if (magia == null)
        {
            img.sprite = tipoMagia == "Ativas" ? SpritesManager.Instance.spellSprites.Spell_ActiveNull : SpritesManager.Instance.spellSprites.Spell_PassiveNull;
            txtLevel.text = "?";
            return;
        }

        img.sprite = magia.SpriteIcon;

        if (magia.isLevelMax)
        {
            txtLevel.color = Color.red;
            txtLevel.text = "MAX";
        }
        else
        {
            txtLevel.color = Color.white;
            txtLevel.text = magia.GetSpellLevel().ToString();
        }
    }

    private void CharacterInfoStatus()
    {
        TXT_Character_Info.text = LanguageManager.Get("Character Info");
        TXT_Max_HP.text = LanguageManager.Get("Max HP");
        TXT_Mov_Speed.text = LanguageManager.Get("Mov Speed");
        TXT_Cooldown_Reduction.text = LanguageManager.Get("Cooldown Reduction");
        TXT_Damage_Boost.text = LanguageManager.Get("Damage Boost");
        TXT_Max_HP_Value.text = HeroImage.GetHeroMaxHP().ToString();
        TXT_Mov_Speed_Value.text = HeroImage.GetHeroSpeed().ToString();
        TXT_Cooldown_Reduction_Value.text = HeroImage.GetHeroCooldownReduction().ToString() + "%";
        TXT_Damage_Boost_Value.text = HeroImage.GetHeroDamageBoost().ToString() + "%";

        Hero_Talents heroTalents = GameManager.Instance.playerHero.heroTalents;
        TXT_PhysicalBonus_Value.text = (heroTalents.BrutamontesLevel * Hero_Talents.BRUTAMONTES_BASE_BUFF).ToString() + "%";
        TXT_DistanceBonus_Value.text = (heroTalents.AtiradorEliteLevel * Hero_Talents.ATIRADOR_ELITE_BASE_BUFF).ToString() + "%";
        TXT_FireBonus_Value.text = (heroTalents.PiromaniacoLevel * Hero_Talents.PIROMANIACO_BASE_BUFF).ToString() + "%";
        TXT_ThunderBonus_Value.text = (heroTalents.TeslaLevel * Hero_Talents.TESLA_BASE_BUFF).ToString() + "%";
        TXT_IceBonus_Value.text = (heroTalents.ToqueCongelanteLevel * Hero_Talents.TOQUE_CONGELANTE_BASE_BUFF).ToString() + "%";
        TXT_PoisonBonus_Value.text = (heroTalents.PestilentoLevel * Hero_Talents.PESTILENTO_BASE_BUFF).ToString() + "%";
    }

    private void BTN_SpellActive1_Action()
    {
        if (HeroImage.active1 == null)
            return;

        botaoSelecionado = 1;

        Painel_ConfirmarApagarSpell.SetActive(true);
    }

    private void BTN_SpellActive2_Action()
    {
        if (HeroImage.active2 == null)
            return;

        botaoSelecionado = 2;

        Painel_ConfirmarApagarSpell.SetActive(true);
    }

    private void BTN_SpellActive3_Action()
    {
        if (HeroImage.active3 == null)
            return;

        botaoSelecionado = 3;

        Painel_ConfirmarApagarSpell.SetActive(true);
    }

    private void BTN_SpellActive4_Action()
    {
        if (HeroImage.active4 == null)
            return;

        botaoSelecionado = 4;

        Painel_ConfirmarApagarSpell.SetActive(true);
    }

    private void BTN_SpellActive5_Action()
    {
        if (HeroImage.active5 == null)
            return;

        botaoSelecionado = 5;

        Painel_ConfirmarApagarSpell.SetActive(true);
    }

    private void BTN_ConfirmarApagarSpell_Action()
    {
        if (PlayerImage.moneyFeito < 100)
            return;

        switch (botaoSelecionado)
        {
            case 1:
                PlayerImage.moneyFeito -= 100;
                HeroImage.active1.SpellLevel = 0;
                HeroImage.active1 = null;
                break;

            case 2:
                PlayerImage.moneyFeito -= 100;
                HeroImage.active2.SpellLevel = 0;
                HeroImage.active2 = null;
                break;

            case 3:
                PlayerImage.moneyFeito -= 100;
                HeroImage.active3.SpellLevel = 0;
                HeroImage.active3 = null;
                break;

            case 4:
                PlayerImage.moneyFeito -= 100;
                HeroImage.active4.SpellLevel = 0;
                HeroImage.active4 = null;
                break;

            case 5:
                PlayerImage.moneyFeito -= 100;
                HeroImage.active5.SpellLevel = 0;
                HeroImage.active5 = null;
                break;
        }

        Painel_ConfirmarApagarSpell.SetActive(false);
    }

    private void BTN_NegarApagarSpell_Action()
    {
        Painel_ConfirmarApagarSpell.SetActive(false);
    }
}
