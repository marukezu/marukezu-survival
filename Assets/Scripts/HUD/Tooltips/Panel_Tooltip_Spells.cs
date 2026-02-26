using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Tooltip_Spells : MonoBehaviour
{
    [Header("====== Panel Texts ======")]
    public TextMeshProUGUI TXT_SpellInfo;
    public TextMeshProUGUI TXT_SpellConditions;

    [Header("====== Spell Image/Name/Element ======")]
    [Header("Name/Icon")]
    public Image IMG_SpellIcon;
    public TextMeshProUGUI TXT_SpellName;
    [Header("Element")]
    public Image IMG_SpellElement;
    public TextMeshProUGUI TXT_SpellElementName;

    [Header("====== Spell Info ======")]
    [Header("Damage")]
    public Image IMG_CombatType;
    public TextMeshProUGUI TXT_CombatTypeValue;
    public TextMeshProUGUI TXT_CombatTypeDesc;
    [Header("Cooldown")]
    public Image IMG_CooldownIcon;
    public TextMeshProUGUI TXT_CooldownValue;
    public TextMeshProUGUI TXT_CooldownDesc;
    [Header("Max Projectiles")]
    public Image IMG_RecastIcon;
    public TextMeshProUGUI TXT_MaxProjectilesValue;
    public TextMeshProUGUI TXT_MaxProjectilesDesc;

    [Header("====== Spell Conditions ======")]
    public Image IMG_ConditionIcon;
    public TextMeshProUGUI TXT_ConditionDesc;

    // Spell que esse Tooltip representa.
    private Spell spell;

    [Header("Config Para seguir o mouse")]
    [SerializeField] private Vector2 offset = new Vector2(18f, 18f);
    [SerializeField] private float edgePadding = 10f;

    private RectTransform _rect;
    private Canvas _canvas;
    private RectTransform _canvasRect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();

        if (_canvas == null)
        {
            Debug.LogError("Panel_Tooltip_Spells: Canvas não encontrado no parent.");
            enabled = false;
            return;
        }

        _canvasRect = (RectTransform)_canvas.transform;
    }

    private void LateUpdate()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        if (_canvasRect == null) return;

        // 1) mouse screen -> local point in canvas
        Vector2 mouse = Input.mousePosition;

        Camera cam = _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _canvas.worldCamera;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvasRect,
            mouse,
            cam,
            out Vector2 localPoint
        );

        // 2) posição desejada (acima do mouse)
        Vector2 target = localPoint + offset;

        // 3) clamp pra não sair da tela (considera pivot)
        Vector2 canvasSize = _canvasRect.rect.size;
        Vector2 tooltipSize = _rect.rect.size;

        Vector2 pivot = _rect.pivot;

        float minX = (-canvasSize.x * 0.5f) + (tooltipSize.x * pivot.x) + edgePadding;
        float maxX = (canvasSize.x * 0.5f) - (tooltipSize.x * (1f - pivot.x)) - edgePadding;

        float minY = (-canvasSize.y * 0.5f) + (tooltipSize.y * pivot.y) + edgePadding;
        float maxY = (canvasSize.y * 0.5f) - (tooltipSize.y * (1f - pivot.y)) - edgePadding;

        target.x = Mathf.Clamp(target.x, minX, maxX);
        target.y = Mathf.Clamp(target.y, minY, maxY);

        _rect.anchoredPosition = target;
    }

    // ===================================================================
    // ======================== CONTAINER SCRIPTS ========================
    // ===================================================================
    public void InicializarPainel(Spell spell)
    {
        this.spell = spell;

        if (spell == null)
        {
            Destroy(gameObject);
            return;
        }

        // Panel Texts
        TXT_SpellInfo.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.SpellInfo);
        TXT_SpellConditions.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.SpellConditions);

        // Spell name/icon
        IMG_SpellIcon.sprite = spell.SpriteIcon;
        TXT_SpellName.text = spell.Name;

        // Element
        SetSpellElement();

        // CombatType
        SetSpellCombatType();

        // Cooldown
        SetSpellCooldown();

        // Max Projectiles
        SetSpellMaxProjectiles();

        SetSpellConditions();
    }

    private void SetSpellElement()
    {
        switch (spell.SpellElement)
        {
            case Spell.Elemento.PHYSICAL:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Physical;
                TXT_SpellElementName.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ElementPhysical);
                break;

            case Spell.Elemento.DISTANCE:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Distance;
                TXT_SpellElementName.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ElementDistance);
                break;

            case Spell.Elemento.FIRE:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Fire;
                TXT_SpellElementName.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ElementFire);
                break;

            case Spell.Elemento.ICE:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Ice;
                TXT_SpellElementName.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ElementIce);
                break;

            case Spell.Elemento.THUNDER:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Thunder;
                TXT_SpellElementName.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ElementThunder);
                break;

            case Spell.Elemento.POISON:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Poison;
                TXT_SpellElementName.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ElementPoison);
                break;
        }
    }

    private void SetSpellCombatType()
    {
        switch (spell.TypeCombat)
        {
            case Spell.CombatType.DAMAGE:
                IMG_CombatType.sprite = SpritesManager.Instance.spellSprites.Spell_CombatType_Damage;
                TXT_CombatTypeValue.text = spell.BaseDmg.ToString();
                TXT_CombatTypeDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.CombatType_Damage);
                break;

            case Spell.CombatType.PROTECTION:
                IMG_CombatType.sprite = SpritesManager.Instance.spellSprites.Spell_CombatType_Protection;
                TXT_CombatTypeValue.text = spell.BaseDmg.ToString();
                TXT_CombatTypeDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.CombatType_Protection);
                break;

            case Spell.CombatType.SUMMON:
                IMG_CombatType.sprite = SpritesManager.Instance.spellSprites.Spell_CombatType_Summon;
                if (spell.BaseDmg == 0)
                    TXT_CombatTypeValue.text = "∞";
                else
                    TXT_CombatTypeValue.text = spell.BaseDmg.ToString();
                TXT_CombatTypeDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.CombatType_Summon);
                break;
        }
    }

    private void SetSpellCooldown()
    {
        switch (spell.TypeCombat)
        {
            case Spell.CombatType.DAMAGE:
                IMG_CooldownIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Cooldown;
                TXT_CooldownValue.text = spell.BaseCooldown.ToString("F1");
                TXT_CooldownDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.Cooldown_Normal);
                break;

            case Spell.CombatType.PROTECTION:
                IMG_CooldownIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Cooldown;
                TXT_CooldownValue.text = spell.BaseCooldown.ToString("F1");
                TXT_CooldownDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.Cooldown_Normal);
                break;

            case Spell.CombatType.SUMMON:
                IMG_CooldownIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Cooldown;  
                TXT_CooldownValue.text = spell.BaseCooldown.ToString("F1");
                if (spell.BaseCooldown == 0)
                    TXT_CooldownDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.Cooldown_Unique);
                else
                    TXT_CooldownDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.Cooldown_Normal);
                break;
        }
    }

    private void SetSpellMaxProjectiles()
    {
        switch (spell.TypeCombat)
        {
            case Spell.CombatType.DAMAGE:
                IMG_RecastIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Recasts;
                TXT_MaxProjectilesValue.text = spell.MaxRecasts.ToString();
                TXT_MaxProjectilesDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.MaxProjectiles_Damage) + spell.MaxRecasts.ToString();
                break;

            case Spell.CombatType.PROTECTION:
                IMG_RecastIcon.sprite = SpritesManager.Instance.conditionSprites.Condition_None;
                TXT_MaxProjectilesValue.text = spell.MaxRecasts.ToString();
                TXT_MaxProjectilesDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.MaxProjectiles_Protection);
                break;

            case Spell.CombatType.SUMMON:
                IMG_RecastIcon.sprite = SpritesManager.Instance.spellSprites.Spell_Recasts;
                TXT_MaxProjectilesValue.text = spell.MaxSummon.ToString();
                TXT_MaxProjectilesDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.MaxProjectiles_Summon) + spell.MaxSummon.ToString();
                break;
        }
    }

    private void SetSpellConditions()
    {
        if (spell.statusBurn)
        {
            IMG_ConditionIcon.sprite = SpritesManager.Instance.conditionSprites.Condition_Burning;
            TXT_ConditionDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ConditionBurnDesc);
        }

        else if (spell.statusFreeze)
        {
            IMG_ConditionIcon.sprite = SpritesManager.Instance.conditionSprites.Condition_Freeze;
            TXT_ConditionDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ConditionFreezeDesc);
        }

        else if (spell.statusPoison)
        {
            IMG_ConditionIcon.sprite = SpritesManager.Instance.conditionSprites.Condition_Poison;
            TXT_ConditionDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ConditionPoison);
        }

        else if (spell.statusEletrify)
        {
            IMG_ConditionIcon.sprite = SpritesManager.Instance.conditionSprites.Condition_Eletrify;
            TXT_ConditionDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ConditionEletrifyDesc);
        }

        else if (spell.consumeEletrify)
        {
            IMG_ConditionIcon.sprite = SpritesManager.Instance.conditionSprites.Condition_ConsumeEletrify;
            TXT_ConditionDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ConditionConsumeEletrifyDesc);
        }

        else
        {
            IMG_ConditionIcon.sprite = SpritesManager.Instance.conditionSprites.Condition_None;
            TXT_ConditionDesc.text = LanguageManager.Get(LanguageTexts_Tooltip_Spells.TooltipWords.ConditionNoneDesc);
        }
    }
}
