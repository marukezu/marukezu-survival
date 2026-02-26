using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_HeroInfo_Spells : Panel
{
    [Header("====== Hero Spells Images ======")]
    public TextMeshProUGUI TXT_Spell;
    public Image IMG_magiaAtiva1;
    public Image IMG_magiaAtiva2;
    public Image IMG_magiaAtiva3;
    public Image IMG_magiaAtiva4;
    public Image IMG_magiaAtiva5;

    [Header("====== Hero Spells Texts ======")]
    public Text TXT_magiaAtiva1Level;
    public Text TXT_magiaAtiva2Level;
    public Text TXT_magiaAtiva3Level;
    public Text TXT_magiaAtiva4Level;
    public Text TXT_magiaAtiva5Level;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        TXT_Spell.text = LanguageManager.Get(LanguageTexts_BasicWords.BasicWords.Spell);
    }

    public override void AtualizarPainel()
    {
        AtualizaMagia(HeroImage.active1, IMG_magiaAtiva1, TXT_magiaAtiva1Level, "Ativas");
        AtualizaMagia(HeroImage.active2, IMG_magiaAtiva2, TXT_magiaAtiva2Level, "Ativas");
        AtualizaMagia(HeroImage.active3, IMG_magiaAtiva3, TXT_magiaAtiva3Level, "Ativas");
        AtualizaMagia(HeroImage.active4, IMG_magiaAtiva4, TXT_magiaAtiva4Level, "Ativas");
        AtualizaMagia(HeroImage.active5, IMG_magiaAtiva5, TXT_magiaAtiva5Level, "Ativas");
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
}
