using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Container_GAMEPLAY_BTN_Talentos : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("====== Qual Talento esse botão representa? ======")]
    public Hero_Talents.TalentType talentType;

    [Header("====== Dados do Container ======")]
    public TextMeshProUGUI TXT_TalentName;
    public TextMeshProUGUI TXT_TalentLevel;
    public Image IMG_TalentIcon;
    public Button BTN_ThisButton;

    private void Awake()
    {
        BTN_ThisButton.onClick.RemoveAllListeners();
        BTN_ThisButton.onClick.AddListener(BTN_ThisButton_Action);
        AtualizarContainer();

        SubscribeEvents(true);
    }

    private void OnDestroy()
    {
        SubscribeEvents(false);
    }

    private void SubscribeEvents(bool subscribe)
    {
        if (subscribe)
        {
            EventBus.On_Panel_Talents_CancelChoise += AtualizarContainer;
        }
        else
        {
            EventBus.On_Panel_Talents_CancelChoise -= AtualizarContainer;
        }
    }

    private void AtualizarContainer()
    {
        Hero_Talents heroTalents = GameManager.Instance.playerHero.heroTalents;

        int level = heroTalents.GetLevel(talentType);
        int maxLevel = Hero_Talents.GetMaxLevel(talentType);

        bool isMax = level >= maxLevel;
        TXT_TalentLevel.text = isMax ? "MAX" : LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Level) + ": " + level.ToString();
        TXT_TalentLevel.color = isMax ? Color.red : Color.yellow;

        switch (talentType)
        {

            // Status Base
            case Hero_Talents.TalentType.Dano:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.DanoBase_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.heroesSprites.Status_Damage;
                break;

            case Hero_Talents.TalentType.VelMovimento:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.VelMov_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.heroesSprites.Status_MovSpeed;
                break;

            case Hero_Talents.TalentType.VidaMaxima:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.VidaMax_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.heroesSprites.Status_MaxHealth;
                break;

            case Hero_Talents.TalentType.TempoRecarga:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.TempoRecarga_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.heroesSprites.Status_Cooldown;
                break;


            // Elementais
            case Hero_Talents.TalentType.Fisico:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.Elemento_Fisico_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Physical;
                break;

            case Hero_Talents.TalentType.Fogo:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.Elemento_Fogo_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Fire;
                break;

            case Hero_Talents.TalentType.Eletrico:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.Elemento_Eletrico_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Thunder;
                break;

            case Hero_Talents.TalentType.Gelo:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.Elemento_Gelo_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Ice;
                break;

            case Hero_Talents.TalentType.Distancia:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.Elemento_Distancia_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Distance;
                break;

            case Hero_Talents.TalentType.Veneno:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.Elemento_Veneno_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Poison;
                break;


            // Chances
            case Hero_Talents.TalentType.ChanceCritica:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.ChanceCritica_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.talentsSprites.Talent_CriticalChance;
                break;

            case Hero_Talents.TalentType.ChanceEmpalamento:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.ChanceEmpalamento_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.talentsSprites.Talent_ImpalementChance;
                break;


            // Multiplicadores
            case Hero_Talents.TalentType.MultCritico:
                TXT_TalentName.text = LanguageManager.Get(LanguageTexts_Talents.TalentWords.MultCritica_Name);
                IMG_TalentIcon.sprite = SpritesManager.Instance.talentsSprites.Talent_CriticalMultiplier;
                break;
        }
    }

    private void BTN_ThisButton_Action()
    {
        Hero_Talents heroTalents = GameManager.Instance.playerHero.heroTalents;

        heroTalents.TryUpgrade(talentType);

        AtualizarContainer();
    }

    // 
    public void OnPointerEnter(PointerEventData eventData)
    {
        EventBus.On_TalentHoverChanged?.Invoke(talentType, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EventBus.On_TalentHoverChanged?.Invoke(talentType, false);
    }
}
