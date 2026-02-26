using UnityEngine;
using UnityEngine.UI;

public class GameManagerGamePlay : MonoBehaviour
{
    public static GameManagerGamePlay Instance;

    // Variáveis referentes ao Jogador.
    public Transform playerSpawnPoint;

    // Controle do efeito de Chuva.
    public GameObject chuvaGameObject;

    // Joystick de controle mobile
    public GameObject joystickMobile;

    // Controle de Reward Chests
    private const float CHEST_INTERVAL = 60; // Intervalo fixo de 1 minutos
    private float nextChestTime = 60; // 1 minutos em segundos

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SpawnaJogador();
    }
    private void Start()
    {
        // Seta a scene atual.
        GameManager.Instance.ActiveScene = GameManager.GameActiveScene.GamePlay;

        IniciaFase();
    }

    void Update()
    {
        MovimentarChuva();

        // Habilita ou desabilita o joystick
        if (InputsManager.Instance.PodePausar && GameConfig._androidMode)
        {
            joystickMobile.gameObject.SetActive(true);
        }
        else
        {
            joystickMobile.gameObject.SetActive(false);
        }

        // Ações que acontecem durante o tempo de jogo
        UpdateTimedRewards();
    }

    // ========================================================================
    // =========================== INICIA A FASE ==============================
    // ========================================================================
    private void SpawnaJogador()
    {
        GameObject playerHero = null;

        switch (HeroImage.heroType)
        {
            case Hero.HeroType.Zephyr: playerHero = PrefabManager.Instance.InstantiateCreaturePrefab(PrefabManager_Creatures.CreatureType.Zephyr, playerSpawnPoint); break;
            case Hero.HeroType.Kael: playerHero = PrefabManager.Instance.InstantiateCreaturePrefab(PrefabManager_Creatures.CreatureType.Kael, playerSpawnPoint); break;
            case Hero.HeroType.Broghar: playerHero = PrefabManager.Instance.InstantiateCreaturePrefab(PrefabManager_Creatures.CreatureType.Broghar, playerSpawnPoint); break;
        }

        GameManager.Instance.playerHero = playerHero.GetComponent<Hero_GameObject>();
    }
    private void IniciaFase()
    {
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_MAININFO);

        InputsManager.Instance.SetEstaPausado(false);
        InputsManager.Instance.SetApresentacaoFase(false);

        // Inicia a Música do jogo.
        AudioManager.Instance.PlayMusic(1);
        AudioManager.Instance.PlayChuva(0);

        // Inicia o LevelController
        LevelController.Instance.levelStarted = true;
    }

    // ========================================================================
    // ======================== REWARDS COM O TEMPO ===========================
    // ========================================================================
    private void UpdateTimedRewards()
    {
        CheckChestReward();
    }
    private void CheckChestReward()
    {
        float contadorTimerFase = LevelController.Instance.contadorTimerFase;

        if (contadorTimerFase >= nextChestTime)
        {
            GiveChestToPlayer();
            nextChestTime += CHEST_INTERVAL;
        }
    }
    private void GiveChestToPlayer()
    {
        GameObject panelGO = PanelManager.Instance.GetPanel(Panel.PanelType.GAMEPLAY_MAININFO);
        Panel_GamePlay_MainInfo panelScript = panelGO.GetComponent<Panel_GamePlay_MainInfo>();
        panelScript.ReceberBau();
    }

    // ======================================================
    // ============ Movimentação Efeito de Chuva ============
    // ======================================================
    private void MovimentarChuva()
    {
        Vector2 deslocamentoChuva = new Vector2(Time.time * 0.3f, Time.time * (0.3f * 3));
        chuvaGameObject.GetComponent<Image>().material.mainTextureOffset = deslocamentoChuva;
    }
}
