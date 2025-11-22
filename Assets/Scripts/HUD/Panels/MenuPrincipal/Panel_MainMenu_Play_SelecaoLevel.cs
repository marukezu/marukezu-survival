using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_MainMenu_Play_SelecaoLevel : Panel
{
    [Header("====== Painel Pai ======")]
    [SerializeField] private Panel_MainMenu_Play PanelPai;

    [Header("====== Components ======")]
    public Image IMG_DesertoFade;
    public Text TXT_LevelSelect; 
    public Text TXT_Fase01Name; 
    public Text TXT_Fase02Name; 
    public Text TXT_BtnBack;

    [Header("====== Buttons ======")]
    public Button BTN_Fase01;
    public Button BTN_Fase02;
    public Button BTN_Back;

    private int levelSelected = 0;
    private bool isLevelSelected = false;

    private void Awake()
    {
        BTN_Fase01.onClick.AddListener(delegate { BTN_SelectFase01(); });
        BTN_Fase02.onClick.AddListener(delegate { BTN_SelectFase02(); });

        BTN_Back.onClick.AddListener(delegate { BTN_Voltar_Action(); });
    }

    public override void AtualizarPainel()
    {
        TXT_LevelSelect.text = LanguageManager.Get("Level Select");
        TXT_Fase01Name.text = LanguageManager.Get("Fase01");
        TXT_Fase02Name.text = LanguageManager.Get("Fase02");
        TXT_BtnBack.text = LanguageManager.Get("Back");

        if (!PlayerConfig.desertoVentosoUnlocked) // Se não tiver liberado a fase do deserto.
        {
            IMG_DesertoFade.gameObject.SetActive(true);
        }
        else
        {
            IMG_DesertoFade.gameObject.SetActive(false);
        }
    }

    private void BTN_SelectFase01()
    {
        isLevelSelected = true;
        levelSelected = 1;

        IniciarFase();
    }
    private void BTN_SelectFase02()
    {
        if (PlayerConfig.desertoVentosoUnlocked)
        {
            isLevelSelected = true; 
            levelSelected = 2;
            IniciarFase();
        }
        else
        {
            isLevelSelected = false;
            levelSelected = 0; 
            AudioManager.Instance.PlaySoundEffectButtons(2);
        }
    }
    private void IniciarFase()
    {
        if (isLevelSelected)
        {
            PanelPai.StartLevel(levelSelected);
        }
        else
        {
            AudioManager.Instance.PlaySoundEffectButtons(2);
        }
    }
    private void BTN_Voltar_Action()
    {
        isLevelSelected = false;
        levelSelected = 0;

        PanelPai.Goto_SpellSelect();

        AudioManager.Instance.PlaySoundEffectButtons(1);
    }
}
