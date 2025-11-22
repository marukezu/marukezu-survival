using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Panel;
using static UnityEngine.Rendering.DebugUI;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;

    // Aponta para o canvas principal da Cena, OBS: O painel que será instanciado os paineis modulares PRECISAM ter o nome Exato do "GameObject.Find("NOME")"
    private RectTransform _canvas;
    private RectTransform Canvas
    {
        get
        {
            if (_canvas == null)
                _canvas = GameObject.Find("Painel JOGO").GetComponent<RectTransform>();
            return _canvas;
        }
    }

    [Header("====== Paineis Main Menu ======")]
    [SerializeField] private GameObject Panel_MainMenu_BotoesPrincipais;
    [SerializeField] private GameObject Panel_MainMenu_Play;
    [SerializeField] private GameObject Panel_MainMenu_Upgrades;
    [SerializeField] private GameObject Panel_MainMenu_Creditos;
    [SerializeField] private GameObject Panel_MainMenu_Configuracoes;
    [SerializeField] private GameObject Panel_MainMenu_ChangeLog;
    [SerializeField] private GameObject Panel_MainMenu_Bestiary;
    [SerializeField] private GameObject Panel_MainMenu_Shop;

    [Header("====== Paineis GamePlay ======")]
    [SerializeField] private GameObject Panel_HUDGameplay_MainInfo;
    [SerializeField] private GameObject Panel_HUDGameplay_HeroInfo;
    [SerializeField] private GameObject Panel_HUDGameplay_ChooseNewSpell;
    [SerializeField] private GameObject Panel_HUDGameplay_Pause;
    [SerializeField] private GameObject Panel_HUDGameplay_GameOver;
    [SerializeField] private GameObject Panel_HUDGameplay_LevelConclusion;
    [SerializeField] private GameObject Panel_HUDGameplay_OpeningBau;
    [SerializeField] private GameObject Panel_HUDGameplay_Talents;

    [Header("====== Outros ======")]
    [SerializeField] private GameObject Panel_Event_Info;

    // Dicionarios
    private Dictionary<PanelType, GameObject> painelDictionary;

    // Lista de paineis ativos no momento
    private List<GameObject> painelList = new List<GameObject>();    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);

        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        painelDictionary = new Dictionary<PanelType, GameObject>
        {
            // Paineis de Main Menu
            { PanelType.MAINMENU_BOTOESPRINCIPAIS, Panel_MainMenu_BotoesPrincipais },
            { PanelType.MAINMENU_PLAY, Panel_MainMenu_Play },
            { PanelType.MAINMENU_UPGRADES, Panel_MainMenu_Upgrades },
            { PanelType.MAINMENU_CREDITOS, Panel_MainMenu_Creditos },
            { PanelType.MAINMENU_CONFIGURACOES, Panel_MainMenu_Configuracoes },
            { PanelType.MAINMENU_CHANGELOG, Panel_MainMenu_ChangeLog },
            { PanelType.MAINMENU_BESTIARY, Panel_MainMenu_Bestiary },
            { PanelType.MAINMENU_SHOP, Panel_MainMenu_Shop },

            // Paineis de Gameplay
            { PanelType.GAMEPLAY_MAININFO, Panel_HUDGameplay_MainInfo },
            { PanelType.GAMEPLAY_HEROINFO, Panel_HUDGameplay_HeroInfo },
            { PanelType.GAMEPLAY_CHOOSE_NEW_SPELL, Panel_HUDGameplay_ChooseNewSpell },
            { PanelType.GAMEPLAY_PAUSE, Panel_HUDGameplay_Pause },
            { PanelType.GAMEPLAY_GAMEOVER, Panel_HUDGameplay_GameOver },
            { PanelType.GAMEPLAY_LEVELCONCLUSION, Panel_HUDGameplay_LevelConclusion },
            { PanelType.GAMEPLAY_OPENINGBAU, Panel_HUDGameplay_OpeningBau },
            { PanelType.GAMEPLAY_TALENTS, Panel_HUDGameplay_Talents },

            // Outros Paineis
            { PanelType.EVENT_INFO, Panel_Event_Info },
        };
    }

    // ==========================================================================================
    // =========================== FUNÇÕES PARA MANUSEIO DOS PAINEIS ============================
    // ==========================================================================================
    public GameObject GetPanel(PanelType panelType)
    {
        foreach (GameObject panel in painelList)
        {
            Panel panelScript = panel.GetComponent<Panel>();
            if (panelScript.Type == panelType)
                return panel;
        }

        return null;
    }
    public GameObject InstanciarERetornarPainel(PanelType panelType, object param1 = null, object param2 = null, object param3 = null)
    {
        if (painelDictionary.TryGetValue(panelType, out GameObject painel))
        {
            GameObject newPanel = Instantiate(painel, Canvas);
            newPanel.GetComponent<Panel>().AbrirPainel(param1, param2, param3);
            painelList.Add(newPanel);
            return newPanel;
        }

        return null;
    }
    public void FecharPainel(PanelType panelType)
    {
        GameObject painelEncontrado = painelList
            .FirstOrDefault(p => p.GetComponent<Panel>()?.Type == panelType);

        if (painelEncontrado != null)
        {
            painelEncontrado.GetComponent<Panel>().FecharPainel();
        }
    }
    public void FecharTodosPaineis()
    {
        foreach (GameObject painel in new List<GameObject>(painelList))
        {
            if (painel != null)
                painel.GetComponent<Panel>().FecharPainel();
        }

        painelList.Clear(); // limpa a lista de vez
    }

    public void UnregisterPanel(Panel panel)
    {
        painelList.Remove(panel.gameObject);
    }

    // ==========================================================================================
    // ============================= FUNÇÕES VISUAIS PARA PAINEIS ===============================
    // ==========================================================================================
    public IEnumerator FlashColorCoroutine(Image image, Color flashColor)
    {
        Color originalColor = Color.white;
        float duration = 0.25f;

        // Transição para a cor escolhida
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            image.color = Color.Lerp(originalColor, flashColor, t / duration);
            yield return null;
        }

        // Transição de volta para branco
        t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            image.color = Color.Lerp(flashColor, originalColor, t / duration);
            yield return null;
        }

        image.color = originalColor;
    }
}
