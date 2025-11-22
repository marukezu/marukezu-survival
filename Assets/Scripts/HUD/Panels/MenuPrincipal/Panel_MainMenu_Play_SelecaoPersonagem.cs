using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Play_SelecaoPersonagem : Panel
{

    [Header("====== Painel Pai ======")]
    [SerializeField] private Panel_MainMenu_Play PanelPai;

    [Header("====== Texts ======")]
    public Text TXT_SelectCharacter;
    public Text TXT_Btn_Back;
    public Text TXT_PlayerMoneyValue;
    public Text TXT_RogueValue;
    public Text TXT_DwarfValue;

    [Header("====== Images ======")]
    public Image IMG_RogueFade; 
    public Image IMG_DwarfFade; 
    public Image IMG_RogueMoney; 
    public Image IMG_DwarfMoney;

    [Header("====== Buttons ======")]
    public Button BTN_Zephyr;
    public Button BTN_Kael;
    public Button BTN_Brogar;
    public Button BTN_Voltar;

    private void Awake()
    {
        BTN_Zephyr.onClick.AddListener(delegate { BTN_Zephyr_Action(); });
        BTN_Kael.onClick.AddListener(delegate { BTN_Kael_Action(); });
        BTN_Brogar.onClick.AddListener(delegate { BTN_Brogar_Action(); });
        BTN_Voltar.onClick.AddListener(delegate { BTN_Voltar_Action(); });
    }

    public override void AtualizarPainel()
    {
        TXT_SelectCharacter.text = LanguageManager.Get("Select Character");
        TXT_PlayerMoneyValue.text = PlayerConfig.playerMoney.ToString();

        TXT_Btn_Back.text = LanguageManager.Get("Back");

        // Configuração de desbloqueio dos personágens.
        if (PlayerConfig.kaelUnlocked == 0) // Rogue
        {
            IMG_RogueFade.gameObject.SetActive(true);
            IMG_RogueMoney.gameObject.SetActive(true);
            TXT_RogueValue.text = PlayerConfig.kaelPrice.ToString();
            TXT_RogueValue.color = PlayerConfig.kaelPrice <= PlayerConfig.playerBlueGem ? Color.green : Color.red;
        }
        else
        {
            IMG_RogueFade.gameObject.SetActive(false);
            IMG_RogueMoney.gameObject.SetActive(false);
        }

        if (PlayerConfig.brogharUnlocked == 0) // Dwarf
        {
            IMG_DwarfFade.gameObject.SetActive(true);
            IMG_DwarfMoney.gameObject.SetActive(true);
            TXT_DwarfValue.text = PlayerConfig.brogharPrice.ToString();
            TXT_DwarfValue.color = PlayerConfig.brogharPrice <= PlayerConfig.playerBlueGem ? Color.green : Color.red;
        }
        else
        {
            IMG_DwarfFade.gameObject.SetActive(false);
            IMG_DwarfMoney.gameObject.SetActive(false);
        }
    }
    public void BTN_Zephyr_Action()
    {
        HeroImage.heroType = Hero.HeroType.Zephyr;
        BTN_Avancar_Action();
    }
    public void BTN_Kael_Action()
    {
        if (PlayerConfig.kaelUnlocked == 1)
        {
            HeroImage.heroType = Hero.HeroType.Kael;
            BTN_Avancar_Action();
        }
        else
        {
            if (PlayerConfig.playerMoney >= PlayerConfig.kaelPrice)
            {
                PlayerConfig.playerMoney -= PlayerConfig.kaelPrice;
                PlayerConfig.kaelUnlocked = 1;
                AudioManager.Instance.PlaySoundEffectButtons(3);
                SaveManager.SaveGame();
            }
            else
            {
                AudioManager.Instance.PlaySoundEffectButtons(2);
            }
        }
    }
    public void BTN_Brogar_Action()
    {
        if (PlayerConfig.brogharUnlocked == 1)
        {
            HeroImage.heroType = Hero.HeroType.Broghar;
            BTN_Avancar_Action();
        }
        else
        {
            if (PlayerConfig.playerMoney >= PlayerConfig.brogharPrice)
            {
                PlayerConfig.playerMoney -= PlayerConfig.brogharPrice;
                PlayerConfig.brogharUnlocked = 1;
                AudioManager.Instance.PlaySoundEffectButtons(3);
                SaveManager.SaveGame();
            }
            else
            {
                AudioManager.Instance.PlaySoundEffectButtons(2);
            }
        }
    }
    public void BTN_Avancar_Action()
    {
        // Checa se o jogador tem um heroi selecionado
        if (HeroImage.heroType != Hero.HeroType.None)
        {
            PanelPai.Goto_SpellSelect();
        }
        else
        {
            AudioManager.Instance.PlaySoundEffectButtons(2);
        }
    }
    public void BTN_Voltar_Action()
    {
        HeroImage.heroType = Hero.HeroType.None;

        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_BOTOESPRINCIPAIS);

        AudioManager.Instance.PlaySoundEffectButtons(1);
    }
}
