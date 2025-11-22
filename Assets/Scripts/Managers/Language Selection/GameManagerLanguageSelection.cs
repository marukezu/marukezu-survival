using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLanguageSelection : MonoBehaviour
{
    private void Start()
    {
        // Seta a scene atual.
        GameManager.Instance.ActiveScene = GameManager.GameActiveScene.LanguageSelection;

        SaveManager.LoadGame();
        SaveManager.LoadOpcoesResolucao();
    }

    public void ButtonPortugues()
    {
        GameConfig._gameIdioma = LanguageManager.GameLanguage.PTBR;
        CarregaMenuPrincipal();
    }
    public void ButtonEnglish()
    {
        GameConfig._gameIdioma = LanguageManager.GameLanguage.ENUS;
        CarregaMenuPrincipal();
    }

    private void CarregaMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
