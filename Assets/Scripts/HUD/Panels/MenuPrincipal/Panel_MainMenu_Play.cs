using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel_MainMenu_Play : Panel
{
    public override PanelType Type => PanelType.MAINMENU_PLAY;

    public Panel Panel_HeroInfo;
    public Panel Panel_HeroSelect;
    public Panel Panel_SpellSelect;
    public Panel Panel_LevelSelect;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        // Abre o painel esquerdo de informação do heroi.
        Panel_HeroInfo.AbrirPainel();

        // Abre o primeiro painel, de seleção de heroi.
        Goto_HeroSelect();
    }

    public void Goto_HeroSelect()
    {
        Panel_HeroSelect.AbrirPainel();
        Panel_SpellSelect.OcultarPainel();
        Panel_LevelSelect.OcultarPainel();
    }
    public void Goto_SpellSelect()
    {
        Panel_HeroSelect.OcultarPainel();
        Panel_SpellSelect.AbrirPainel();
        Panel_LevelSelect.OcultarPainel();
    }
    public void Goto_LevelSelect()
    {
        Panel_HeroSelect.OcultarPainel();
        Panel_SpellSelect.OcultarPainel();
        Panel_LevelSelect.AbrirPainel();
    }
    public void StartLevel(int levelSelected)
    {
        AudioManager.Instance.PlaySoundEffectButtons(0);
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopChuva();

        // Libera a spell selecionada no bestiario
        SpellsList.UnlockSpellBestiary(HeroImage.active1.TypeSpell);

        // Inicia as variáveis do Hero para uma nova partida.
        GameManager.Instance.PrepareNewGame();

        switch (levelSelected)
        {
            case 1: SceneManager.LoadScene("Fase01"); break;
            case 2: SceneManager.LoadScene("Fase02"); break;
        }
    }
}
