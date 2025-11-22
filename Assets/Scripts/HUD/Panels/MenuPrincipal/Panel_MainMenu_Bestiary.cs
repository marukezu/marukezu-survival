using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Panel;

public class Panel_MainMenu_Bestiary : Panel
{
    public override PanelType Type => PanelType.MAINMENU_BESTIARY;

    [Header("====== Sub Panels ======")]
    public Panel_MainMenu_Bestiary_Monsters Panel_Monsters;
    public Panel_MainMenu_Bestiary_Spells Panel_Spells;
    public Panel_MainMenu_Bestiary_Relics Panel_Relics;

    [Header("====== Panel Configuration ======")]
    public Text TXT_BestiaryBestiary; 
    public Text TXT_BestiaryBack;
    public Button BTN_Back;

    [Header("====== Monsters Configuration ======")]
    public Button BTN_Monster;

    [Header("====== Relics Configuration ======")]
    public Button BTN_Relic;

    [Header("====== Spells Configuration ======")]
    public Button BTN_Spells;


    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        BTN_Monster.onClick.AddListener(Btn_BestiaryChooseMonster);
        BTN_Relic.onClick.AddListener(Btn_BestiaryChooseRelic);
        BTN_Spells.onClick.AddListener(Btn_BestiaryChooseSpell);
        BTN_Back.onClick.AddListener(BtnBestiaryVoltar);

        TXT_BestiaryBestiary.text = LanguageManager.Get("Bestiary");
        TXT_BestiaryBack.text = LanguageManager.Get("Back");
    }

    public void Btn_BestiaryChooseMonster()
    {
        Panel_Monsters.AbrirPainel();
        Panel_Spells.OcultarPainel();
        Panel_Relics.OcultarPainel();

        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void Btn_BestiaryChooseRelic()
    {
        Panel_Monsters.OcultarPainel();
        Panel_Spells.OcultarPainel();
        Panel_Relics.AbrirPainel();

        AudioManager.Instance.PlaySoundEffectButtons(0);
    }
    public void Btn_BestiaryChooseSpell()
    {
        Panel_Monsters.OcultarPainel();
        Panel_Spells.AbrirPainel();
        Panel_Relics.OcultarPainel();

        AudioManager.Instance.PlaySoundEffectButtons(0);
    }

    public void BtnBestiaryVoltar()
    {
        PanelManager.Instance.InstanciarERetornarPainel(PanelType.MAINMENU_BOTOESPRINCIPAIS);
        AudioManager.Instance.PlaySoundEffectButtons(1);

        FecharPainel();
    }
}
