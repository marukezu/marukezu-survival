using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Panel;

public class Container_BTN_Talento : MonoBehaviour
{
    public Hero_Talents.TalentType talentType;

    public TextMeshProUGUI TXT_TalentName;
    public TextMeshProUGUI TXT_TalentLevel;
    public TextMeshProUGUI TXT_TalentDescription;
    public Image IMG_TalentIcon;

    private Button BTN_ThisButton;
    private Coroutine autoClickCoroutine;
    public float autoClickInterval = 0.25f;

    private void Awake()
    {
        BTN_ThisButton = GetComponent<Button>();
        BTN_ThisButton.onClick.RemoveAllListeners();
        BTN_ThisButton.onClick.AddListener(BTN_ThisButton_Action);
        AtualizarContainer();
    }

    private void AtualizarContainer()
    {
        Hero_Talents heroTalents = GameManager.Instance.playerHero.heroTalents;

        switch (talentType)
        {
            case Hero_Talents.TalentType.Brutamontes:
                TXT_TalentName.text = LanguageManager.Get("Brutamontes Name");
                TXT_TalentDescription.text = LanguageManager.Get("Brutamontes Description");
                TXT_TalentLevel.text = heroTalents.BrutamontesLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.Piromaniaco:
                TXT_TalentName.text = LanguageManager.Get("Piromaniaco Name");
                TXT_TalentDescription.text = LanguageManager.Get("Piromaniaco Description");
                TXT_TalentLevel.text = heroTalents.PiromaniacoLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.Tesla:
                TXT_TalentName.text = LanguageManager.Get("Tesla Name");
                TXT_TalentDescription.text = LanguageManager.Get("Tesla Description");
                TXT_TalentLevel.text = heroTalents.TeslaLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.ToqueCongelante:
                TXT_TalentName.text = LanguageManager.Get("Toque Congelante Name");
                TXT_TalentDescription.text = LanguageManager.Get("Toque Congelante Description");
                TXT_TalentLevel.text = heroTalents.ToqueCongelanteLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.AtiradorElite:
                TXT_TalentName.text = LanguageManager.Get("Atirador Elite Name");
                TXT_TalentDescription.text = LanguageManager.Get("Atirador Elite Description");
                TXT_TalentLevel.text = heroTalents.AtiradorEliteLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.Pestilento:
                TXT_TalentName.text = LanguageManager.Get("Pestilento Name");
                TXT_TalentDescription.text = LanguageManager.Get("Pestilento Description");
                TXT_TalentLevel.text = heroTalents.PestilentoLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.PassoLigeiro:
                TXT_TalentName.text = LanguageManager.Get("Passo Ligeiro Name");
                TXT_TalentDescription.text = LanguageManager.Get("Passo Ligeiro Description");
                TXT_TalentLevel.text = heroTalents.PassoLigeiroLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.PeleFerro:
                TXT_TalentName.text = LanguageManager.Get("Pele Ferro Name");
                TXT_TalentDescription.text = LanguageManager.Get("Pele Ferro Description");
                TXT_TalentLevel.text = heroTalents.PeleFerroLevel.ToString("F0");
                break;
            case Hero_Talents.TalentType.Apressado:
                TXT_TalentName.text = LanguageManager.Get("Apressado Name");
                TXT_TalentDescription.text = LanguageManager.Get("Apressado Description");
                TXT_TalentLevel.text = heroTalents.ApressadoLevel.ToString("F0");
                break;
        }
    }

    private void BTN_ThisButton_Action()
    {
        Hero_Talents heroTalents = GameManager.Instance.playerHero.heroTalents;

        switch (talentType)
        {
            case Hero_Talents.TalentType.Brutamontes:
                heroTalents.AddBrutamontesLevel();
                break;
            case Hero_Talents.TalentType.Piromaniaco:
                heroTalents.AddPiromaniacoLevel();
                break;
            case Hero_Talents.TalentType.Tesla:
                heroTalents.AddTeslaLevel();
                break;
            case Hero_Talents.TalentType.ToqueCongelante:
                heroTalents.AddToqueCongelanteLevel();
                break;
            case Hero_Talents.TalentType.AtiradorElite:
                heroTalents.AddAtiradorEliteLevel();
                break;
            case Hero_Talents.TalentType.Pestilento:
                heroTalents.AddPestilentoLevel();
                break;
            case Hero_Talents.TalentType.PassoLigeiro:
                heroTalents.AddPassoLigeiroLevel();
                break;
            case Hero_Talents.TalentType.PeleFerro:
                heroTalents.AddPeleFerroLevel();
                break;
            case Hero_Talents.TalentType.Apressado:
                heroTalents.AddApressadoLevel();
                break;
        }

        AtualizarContainer();
        FinishChoise();
    }

    private void FinishChoise()
    {
        Hero_Talents heroTalents = GameManager.Instance.playerHero.heroTalents;

        if (heroTalents.PontosTalentos <= 0)
        {
            // Retorna valores padrões
            GameManager.Instance.DesPause(true, 0.5f);
            AudioManager.Instance.PlayChuva(0);

            // Fecha os paineis
            PanelManager.Instance.FecharPainel(PanelType.GAMEPLAY_HEROINFO);
            PanelManager.Instance.FecharPainel(PanelType.GAMEPLAY_TALENTS);
        }
    }
}
