using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_HeroInfo_Hero : Panel
{
    public TextMeshProUGUI TXT_StatusBase;
    public TextMeshProUGUI TXT_DamageModifiers;
    public TextMeshProUGUI TXT_Chances;
    public TextMeshProUGUI TXT_Multipliers;

    [Header("====== Base Stats ======")]

    [Header("Max HP")]
    public Image IMG_MaxHP;
    public TextMeshProUGUI TXT_Max_HP;
    public TextMeshProUGUI TXT_Max_HP_Value;

    [Header("Movement Speed")]
    public Image IMG_MovSpeed;
    public TextMeshProUGUI TXT_Mov_Speed;
    public TextMeshProUGUI TXT_Mov_Speed_Value;

    [Header("Cooldown Reduction")]
    public Image IMG_CooldownReduction;
    public TextMeshProUGUI TXT_Cooldown_Reduction;
    public TextMeshProUGUI TXT_Cooldown_Reduction_Value;

    [Header("Damage Boost")]
    public Image IMG_DamageBoost;
    public TextMeshProUGUI TXT_Damage_Boost;
    public TextMeshProUGUI TXT_Damage_Boost_Value;


    [Header("====== Elementais ======")]

    [Header("Physical")]
    public Image IMG_Element_Physical;
    public TextMeshProUGUI TXT_PhysicalBonus;
    public TextMeshProUGUI TXT_PhysicalBonus_Value;

    [Header("Distance")]
    public Image IMG_Element_Distance;
    public TextMeshProUGUI TXT_DistanceBonus;
    public TextMeshProUGUI TXT_DistanceBonus_Value;

    [Header("Fire")]
    public Image IMG_Element_Fire;
    public TextMeshProUGUI TXT_FireBonus;
    public TextMeshProUGUI TXT_FireBonus_Value;

    [Header("Thunder")]
    public Image IMG_Element_Thunder;
    public TextMeshProUGUI TXT_ThunderBonus;
    public TextMeshProUGUI TXT_ThunderBonus_Value;

    [Header("Ice")]
    public Image IMG_Element_Ice;
    public TextMeshProUGUI TXT_IceBonus;
    public TextMeshProUGUI TXT_IceBonus_Value;

    [Header("Poison")]
    public Image IMG_Element_Poison;
    public TextMeshProUGUI TXT_PoisonBonus;
    public TextMeshProUGUI TXT_PoisonBonus_Value;

    [Header("====== Chances ======")]
    [Header("Critical")]
    public Image IMG_CriticalChance;
    public TextMeshProUGUI TXT_CriticalChance;
    public TextMeshProUGUI TXT_CriticalChance_Value;

    [Header("Empalamento")]
    public Image IMG_ImpalementChance;
    public TextMeshProUGUI TXT_ImpalementChance;
    public TextMeshProUGUI TXT_ImpalementChance_Value;

    [Header("====== Multiplicadores ======")]
    [Header("Mult Critical")]
    public Image IMG_MultCritical;
    public TextMeshProUGUI TXT_MultCritical;
    public TextMeshProUGUI TXT_MultCritical_Value;
    
    // Para Highlight ao colocar o mouse em cima de um talento
    private readonly Dictionary<Hero_Talents.TalentType, TextMeshProUGUI> att_description = new();
    private readonly Dictionary<Hero_Talents.TalentType, TextMeshProUGUI> att_value = new();

    private Color _defaultInfoColor;
    private Color _defaultValueColor;

    protected override void OnDestroy()
    {
        base.OnDestroy();
        SubscribeEvents(false);
    }

    public override void Initialize(object param1 = null, object param2 = null, object param3 = null)
    {
        // Cor base
        _defaultInfoColor = TXT_Max_HP.color;
        _defaultValueColor = TXT_Max_HP_Value.color;

        // limpa por segurança
        att_description.Clear();
        att_value.Clear();

        // Mapeia talento -> TXT do atributo que ele afeta
        att_description[Hero_Talents.TalentType.Dano] = TXT_Damage_Boost;
        att_description[Hero_Talents.TalentType.VelMovimento] = TXT_Mov_Speed;
        att_description[Hero_Talents.TalentType.VidaMaxima] = TXT_Max_HP;
        att_description[Hero_Talents.TalentType.TempoRecarga] = TXT_Cooldown_Reduction;

        att_description[Hero_Talents.TalentType.Fisico] = TXT_PhysicalBonus;
        att_description[Hero_Talents.TalentType.Distancia] = TXT_DistanceBonus;
        att_description[Hero_Talents.TalentType.Fogo] = TXT_FireBonus;
        att_description[Hero_Talents.TalentType.Eletrico] = TXT_ThunderBonus;
        att_description[Hero_Talents.TalentType.Gelo] = TXT_IceBonus;
        att_description[Hero_Talents.TalentType.Veneno] = TXT_PoisonBonus;

        att_description[Hero_Talents.TalentType.ChanceEmpalamento] = TXT_ImpalementChance;
        att_description[Hero_Talents.TalentType.ChanceCritica] = TXT_CriticalChance;
        att_description[Hero_Talents.TalentType.MultCritico] = TXT_MultCritical;

        // Mapeia talento -> TXT do atributo que ele afeta
        att_value[Hero_Talents.TalentType.Dano] = TXT_Damage_Boost_Value;
        att_value[Hero_Talents.TalentType.VelMovimento] = TXT_Mov_Speed_Value;
        att_value[Hero_Talents.TalentType.VidaMaxima] = TXT_Max_HP_Value;
        att_value[Hero_Talents.TalentType.TempoRecarga] = TXT_Cooldown_Reduction_Value;

        att_value[Hero_Talents.TalentType.Fisico] = TXT_PhysicalBonus_Value;
        att_value[Hero_Talents.TalentType.Distancia] = TXT_DistanceBonus_Value;
        att_value[Hero_Talents.TalentType.Fogo] = TXT_FireBonus_Value;
        att_value[Hero_Talents.TalentType.Eletrico] = TXT_ThunderBonus_Value;
        att_value[Hero_Talents.TalentType.Gelo] = TXT_IceBonus_Value;
        att_value[Hero_Talents.TalentType.Veneno] = TXT_PoisonBonus_Value;

        att_value[Hero_Talents.TalentType.ChanceEmpalamento] = TXT_ImpalementChance_Value;
        att_value[Hero_Talents.TalentType.ChanceCritica] = TXT_CriticalChance_Value;
        att_value[Hero_Talents.TalentType.MultCritico] = TXT_MultCritical_Value;

        SubscribeEvents(true);
    }

    private void SubscribeEvents(bool subscribe)
    {
        if (subscribe)
        {
            EventBus.On_TalentHoverChanged += HighlightTalent;
        }
        else
        {
            EventBus.On_TalentHoverChanged -= HighlightTalent;
        }
    }

    public override void AtualizarPainel()
    {
        UpdatePanel();
    }

    private void UpdatePanel()
    {
        // Referência ao script de Talentos do Hero
        Hero_Talents heroTalents = GameManager.Instance.playerHero.heroTalents;

        // Texto de Tópicos
        TXT_StatusBase.text = LanguageManager.Get(LanguageTexts_Panel_GamePlay.PanelGamePlayWords.StatusBase);
        TXT_DamageModifiers.text = LanguageManager.Get(LanguageTexts_Panel_GamePlay.PanelGamePlayWords.ElementalModifier);
        TXT_Chances.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Chances);
        TXT_Multipliers.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Multipliers);

        // =======================================================================================
        // ===================================== STATUS BASE =====================================
        // =======================================================================================
        // MAX HP
        IMG_MaxHP.sprite = SpritesManager.Instance.heroesSprites.Status_MaxHealth;
        TXT_Max_HP.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.MaxHP);
        TXT_Max_HP_Value.text = HeroImage.GetHeroMaxHP().ToString();

        // MOV SPEED
        IMG_MovSpeed.sprite = SpritesManager.Instance.heroesSprites.Status_MovSpeed;
        TXT_Mov_Speed.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.MovSpeed);
        TXT_Mov_Speed_Value.text = HeroImage.GetHeroSpeed().ToString();

        // COOLDOWN REDUCTION
        IMG_CooldownReduction.sprite = SpritesManager.Instance.heroesSprites.Status_Cooldown;
        TXT_Cooldown_Reduction.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.CooldownReduction);
        TXT_Cooldown_Reduction_Value.text = HeroImage.GetHeroCooldownReduction().ToString() + "%";

        // DAMAGE BOOST
        IMG_DamageBoost.sprite = SpritesManager.Instance.heroesSprites.Status_Damage;
        TXT_Damage_Boost.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.DamageBoost);
        TXT_Damage_Boost_Value.text = HeroImage.GetHeroDamageBoost().ToString() + "%";

        // =======================================================================================
        // ====================================== ELEMENTAIS =====================================
        // =======================================================================================

        // ELEMENT PHYSICAL
        IMG_Element_Physical.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Physical;
        TXT_PhysicalBonus.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Physical);
        TXT_PhysicalBonus_Value.text = "+" + (heroTalents.GetLevel(Hero_Talents.TalentType.Fisico) * Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Fisico)).ToString() + "%";

        // ELEMENT DISTANCE
        IMG_Element_Distance.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Distance;
        TXT_DistanceBonus.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Distance);
        TXT_DistanceBonus_Value.text = "+" + (heroTalents.GetLevel(Hero_Talents.TalentType.Distancia) * Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Distancia)).ToString() + "%";

        // ELEMENT FIRE
        IMG_Element_Fire.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Fire;
        TXT_FireBonus.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Fire);
        TXT_FireBonus_Value.text = "+" + (heroTalents.GetLevel(Hero_Talents.TalentType.Fogo) * Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Fogo)).ToString() + "%";

        // ELEMENT THUNDER
        IMG_Element_Thunder.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Thunder;
        TXT_ThunderBonus.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Thunder);
        TXT_ThunderBonus_Value.text = "+" + (heroTalents.GetLevel(Hero_Talents.TalentType.Eletrico) * Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Eletrico)).ToString() + "%";

        // ELEMENT ICE
        IMG_Element_Ice.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Ice;
        TXT_IceBonus.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Ice);
        TXT_IceBonus_Value.text = "+" + (heroTalents.GetLevel(Hero_Talents.TalentType.Gelo) * Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Gelo)).ToString() + "%";

        // ELEMENT POISON
        IMG_Element_Poison.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Poison;
        TXT_PoisonBonus.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell_Element_Poison);
        TXT_PoisonBonus_Value.text = "+" + (heroTalents.GetLevel(Hero_Talents.TalentType.Veneno) * Hero_Talents.GetBaseBuff(Hero_Talents.TalentType.Veneno)).ToString() + "%";

        // =======================================================================================
        // ======================================= CHANCES =======================================
        // =======================================================================================
        IMG_CriticalChance.sprite = SpritesManager.Instance.talentsSprites.Talent_CriticalChance;
        TXT_CriticalChance.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.CriticalChance);
        TXT_CriticalChance_Value.text = HeroImage.GetHeroCriticalChance().ToString() + "%";

        IMG_ImpalementChance.sprite = SpritesManager.Instance.talentsSprites.Talent_ImpalementChance;
        TXT_ImpalementChance.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.ImpalementChance);
        TXT_ImpalementChance_Value.text = HeroImage.GetHeroImpalementChance().ToString() + "%";

        // =======================================================================================
        // =================================== MULTIPLICADORES ===================================
        // =======================================================================================
        IMG_MultCritical.sprite = SpritesManager.Instance.talentsSprites.Talent_CriticalMultiplier;
        TXT_MultCritical.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.CriticalMultiplier);
        TXT_MultCritical_Value.text = HeroImage.GetHeroCriticalMultiplier().ToString() + "%";
    }

    public void HighlightTalent(Hero_Talents.TalentType type, bool on)
    {
        if (!att_description.TryGetValue(type, out var txt_desc) || txt_desc == null)
            return;

        if (!att_value.TryGetValue(type, out var txt_value) || txt_value == null)
            return;

        if (on)
        {
            txt_desc.color = Color.green;
            txt_value.color = Color.green;
        }
        else
        {
            txt_desc.color = _defaultInfoColor;
            txt_value.color = _defaultValueColor;
        }
    }
}
