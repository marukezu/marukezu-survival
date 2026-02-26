using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Play_HeroInfo : Panel
{

    [Header("====== Character Info ======")]
    public TextMeshProUGUI TXT_CharacterInfo;
    public TextMeshProUGUI TXT_Selection;

    [Header("====== Level ======")]
    public Image IMG_Level;
    public TextMeshProUGUI TXT_Level;
    public TextMeshProUGUI TXT_LevelValue;

    [Header("====== Damage Boost ======")]
    public Image IMG_DamageBoost;
    public TextMeshProUGUI TXT_DamageBoost;
    public TextMeshProUGUI TXT_DamageBoostValue;

    [Header("====== Max HP ======")]
    public Image IMG_MaxHP;
    public TextMeshProUGUI TXT_MaxHP;
    public TextMeshProUGUI TXT_MaxHPValue;

    [Header("====== Mov Speed ======")]
    public Image IMG_MovSpeed;
    public TextMeshProUGUI TXT_MovSpeed;
    public TextMeshProUGUI TXT_MovSpeedValue;

    [Header("====== Cooldown ======")]
    public Image IMG_CooldownReduction;
    public TextMeshProUGUI TXT_CooldownReduction;
    public TextMeshProUGUI TXT_CooldownReductionValue;

    [Header("====== Selection ======")]
    public Image IMG_SelectedHero;
    public TextMeshProUGUI TXT_SelectedHero;
    public Image IMG_SelectedSpell;
    public TextMeshProUGUI TXT_SelectedSpell;

    public override void AtualizarPainel()
    {
        // Textos do Painel
        TXT_CharacterInfo.text = LanguageManager.Get(LanguageTexts_Panel_MainMenu.MainMenuWords.InformacaoHeroi);
        TXT_Selection.text = LanguageManager.Get(LanguageTexts_Panel_MainMenu.MainMenuWords.Selection);

        // Hero Info
        IMG_Level.sprite = SpritesManager.Instance.heroesSprites.Status_Level;
        IMG_DamageBoost.sprite = SpritesManager.Instance.heroesSprites.Status_Damage;
        IMG_MaxHP.sprite = SpritesManager.Instance.heroesSprites.Status_MaxHealth;
        IMG_MovSpeed.sprite = SpritesManager.Instance.heroesSprites.Status_MovSpeed;
        IMG_CooldownReduction.sprite = SpritesManager.Instance.heroesSprites.Status_Cooldown;

        TXT_Level.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Level) + ":";
        TXT_MaxHP.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.MaxHP) + ":";
        TXT_MovSpeed.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.MovSpeed) + ":";
        TXT_CooldownReduction.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.CooldownReduction) + ":";
        TXT_DamageBoost.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.DamageBoost) + ":";

        TXT_LevelValue.text = HeroImage.heroType == Hero.HeroType.None ? "---" : Hero_Cards.GetHeroLevel(HeroImage.heroType).ToString("F0");
        TXT_MaxHPValue.text = HeroImage.heroType == Hero.HeroType.None ? "---" : HeroImage.GetHeroMaxHP().ToString("F1");
        TXT_MovSpeedValue.text = HeroImage.heroType == Hero.HeroType.None ? "---" : HeroImage.GetHeroSpeed().ToString("F3");
        TXT_CooldownReductionValue.text = HeroImage.heroType == Hero.HeroType.None ? "---" : HeroImage.GetHeroCooldownReduction().ToString("F1") + "%";
        TXT_DamageBoostValue.text = HeroImage.heroType == Hero.HeroType.None ? "---" : HeroImage.GetHeroDamageBoost().ToString("F1") + "%";

        // Selection
        switch (HeroImage.heroType)
        {
            case Hero.HeroType.None:
                IMG_SelectedHero.sprite = SpritesManager.Instance.heroesSprites.NonePortrait;
                TXT_SelectedHero.text = "---";
                break;

            case Hero.HeroType.Zephyr:
                IMG_SelectedHero.sprite = SpritesManager.Instance.heroesSprites.ZephyrPortrait;
                TXT_SelectedHero.text = "Zephyr";
                break;

            case Hero.HeroType.Kael:
                IMG_SelectedHero.sprite = SpritesManager.Instance.heroesSprites.KaelPortrait;
                TXT_SelectedHero.text = "Kael";
                break;

            case Hero.HeroType.Broghar:
                IMG_SelectedHero.sprite = SpritesManager.Instance.heroesSprites.BrogharPortrait;
                TXT_SelectedHero.text = "Broghar";
                break;
        }

        if (HeroImage.active1 != null)
        {
            IMG_SelectedSpell.sprite = HeroImage.active1.SpriteIcon;
            TXT_SelectedSpell.text = HeroImage.active1.Name;
        }
        else
        {
            IMG_SelectedSpell.sprite = SpritesManager.Instance.spellSprites.Spell_ActiveNull;
            TXT_SelectedSpell.text = "---";
        }
    }
}
