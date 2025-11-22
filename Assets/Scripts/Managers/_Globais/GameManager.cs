using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // O Hero que o jogador está na Scene de GamePlay.
    public Hero_GameObject playerHero;

    // Armazena todos os orbs na partida.
    public List<GameObject> OrbsInScene = new List<GameObject>();

    // Representa em qual Scene o jogo está no momento.
    public enum GameActiveScene
    {
        LanguageSelection,
        MainMenu,
        GamePlay,
    }

    public GameActiveScene ActiveScene;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);

        // Registra todos os Textos de idioma do jogo.
        LanguageTexts_Events.RegisterAll();
        LanguageTexts_Spells.RegisterAll();
        LanguageTexts_Talents.RegisterAll();
        LanguageTexts_Upgrades.RegisterAll();
        LanguageTexts_Relics.RegisterAll();
        LanguageTexts_Potions.RegisterAll();
        LanguageTexts_Panel_MainMenu.RegisterAll();
        LanguageTexts_Panel_GamePlay.RegisterAll();
        LanguageTexts_BasicWords.RegisterAll();
    }

    // ====================================================
    // A GAME RUN CONFIGURATION
    // ====================================================
    public void PrepareNewGame()
    {
        // Limpa variáveis
        OrbsInScene.Clear();

        PlayerImage.ResetPlayerImage();
        HeroImage.PrepareHeroImage();

        foreach (Spell spell in SpellsList.AllSpells)
        {
            spell.ResetSpell();
        }
    }

    public IEnumerator CallGameOver()
    {
        playerHero.isDead = true;

        yield return new WaitForSeconds(1.5f);

        PausarGame(false);

        AudioManager.Instance.PlaySoundEffectButtons(6);
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_LEVELCONCLUSION);
    }

    public void FinishRun()
    {
        StartCoroutine(FinishRun_Action());
    }

    private IEnumerator FinishRun_Action()
    {
        AudioManager.Instance.PlaySoundEffectButtons(0);

        if (PlayerImage.bausRecebidos > 0)
            yield return StartCoroutine(OpenChests());

        // Despausa
        DesPause();

        // Soma as currency
        PlayerConfig.playerMoney += PlayerImage.moneyFeito;

        // Salva database
        SaveManager.SaveGame();

        // Carrega o menu principal
        SceneManager.LoadScene("MenuPrincipal");

        // Reinicia as classes Statics
        PlayerImage.ResetPlayerImage();
        HeroImage.ResetHeroImage();
    }

    private IEnumerator OpenChests()
    {
        GameObject painelBau = PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_OPENINGBAU);

        yield return new WaitUntil(() => painelBau == null);
    }

    // ========================================================================
    // ============================ PAUSE GAME ================================
    // ========================================================================
    public void PausarGame(bool playSoundEffect = true)
    {
        // Garante que só funcione nas scenes de gameplay
        if (ActiveScene != GameActiveScene.GamePlay || !InputsManager.Instance.PodePausar)
            return; 

        InputsManager.Instance.SetEstaPausado(true);
        
        if (playSoundEffect)
            AudioManager.Instance.PlaySoundEffectButtons(0);

        Time.timeScale = 0f;
    }
    public void DesPause(bool playSoundEffect = true, float desPauseDelay = 0f)
    {
        // Garante que só funcione nas scenes de gameplay
        if (ActiveScene != GameActiveScene.GamePlay)
            return;

        InputsManager.Instance.SetEstaPausado(false); 

        if (playSoundEffect)
            AudioManager.Instance.PlaySoundEffectButtons(0);

        StartCoroutine(RetornarTimeScale(desPauseDelay));
    }
    private IEnumerator RetornarTimeScale(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        Time.timeScale = 1f;
    }
}
