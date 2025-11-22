using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Play_HeroInfo : Panel
{

    [Header("====== Character Info ======")]
    public Text TXT_CharacterInfo;

    public Text TXT_Level;
    public Text TXT_LevelValue;

    public Text TXT_MaxHP;
    public Text TXT_MaxHPValue;

    public Text TXT_MovSpeed;
    public Text TXT_MovSpeedValue;

    public Text TXT_CooldownReduction;
    public Text TXT_CooldownReductionValue;

    public Text TXT_DamageBoost;  
    public Text TXT_DamageBoostValue;

    [Header("====== Selection ======")]
    public Image IMG_SelectedHero;
    public TextMeshProUGUI TXT_SelectedHero;
    public Image IMG_SelectedSpell;
    public TextMeshProUGUI TXT_SelectedSpell;

    public override void AtualizarPainel()
    {
        TXT_CharacterInfo.text = LanguageManager.Get("Character Info");

        // Hero Info
        TXT_Level.text = LanguageManager.Get("Level");
        TXT_MaxHP.text = LanguageManager.Get("MaxHP");
        TXT_MovSpeed.text = LanguageManager.Get("Vel Mov");
        TXT_CooldownReduction.text = LanguageManager.Get("Cooldown Reduction");
        TXT_DamageBoost.text = LanguageManager.Get("Damage Boost");

        TXT_LevelValue.text = HeroImage.heroType == Hero.HeroType.None ? "---" : Hero.GetHeroLevel(HeroImage.heroType).ToString("F0");
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
