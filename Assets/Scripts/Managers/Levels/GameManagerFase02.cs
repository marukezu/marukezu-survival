using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerFase02 : MonoBehaviour
{
    public static GameManagerFase02 Instance;
    private Coroutine apresentacaoFaseCoroutine;
    // Variáveis da inicialização da fase (Nome da Fase, Objetivo)
    public float velocidadeAlpha = 0.5f;
    private bool apresentacaoConcluida = false;

    // Variáveis referentes ao Jogador.
    public GameObject playerSpawnPoint, playerCharacterMage, playerCharacterRogue, playerCharacterDwarf;

    // Variáveis de controle
    private bool concluiuAFase;

    // Controle dos acontecimentos da Fase (spawns).
    public float _contadorTimerFase, _timerSpawn;
    private bool _siege1Snake, _siege1Mummy, _siege1Camelo, _siege1Caixao, _siege1Djinn;
    private bool _bossSnake, _bossMummy, _bossCamelo, _bossCaixao, _bossDjinn;

    // Controle do efeito de Ventania.
    public GameObject ventaniaGameObject;


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
    }
    void Start()
    {
        // Seta a scene atual.
        GameManager.Instance.ActiveScene = GameManager.GameActiveScene.GamePlay;

        IniciaValores();
        IniciaFase();
    }
    void Update()
    {
        MovimentarVentania();

        // Comportamento da Fase.
        //ControladorDaFase();
        ContadorTempoFase();
    }

    private void IniciaValores()
    {
        // Inicia a Música do jogo.
        AudioManager.Instance.PlayMusic(2); // Desert OST
        AudioManager.Instance.PlayChuva(1); // Windy Sound

        // Variáveis de controle do tempo da fase.
        _contadorTimerFase = 0f;
        _timerSpawn = 2f;
    }

    // ======================================================
    // ====== INICIA A FASE - NOME DA FASE - DESAFIO ========
    // ======================================================
    private void IniciaFase()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_MAININFO);
        apresentacaoConcluida = true;        
    }

    public void DesativaApresentacaoFaseCasoAperteEsc()
    {
        PanelManager.Instance.FecharTodosPaineis();
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_MAININFO);
        apresentacaoConcluida = true;

        InputsManager.Instance.SetApresentacaoFase(false);

        StopCoroutine(apresentacaoFaseCoroutine);
    }

    // ======================================================
    // ============ Movimentação Efeito de Ventania ============
    // ======================================================
    private void MovimentarVentania()
    {
        Vector2 deslocamentoVentania = new Vector2(Time.time * 1f, 0);
        ventaniaGameObject.GetComponent<Image>().material.mainTextureOffset = deslocamentoVentania;
    }

    // ======================================================
    // =============== COMPORTAMENTO DA FASE ================
    // ======================================================
    private void ContadorTempoFase()
    {
        if (apresentacaoConcluida)
        {
            _contadorTimerFase += Time.deltaTime;
            _timerSpawn -= Time.deltaTime;
        }
        if (_contadorTimerFase > 1800f && !concluiuAFase) // Ao Chegar aos 30 minutos.
        {
            concluiuAFase = true;
            PlayerConfig.desertoVentosoUnlocked = true;
            StartCoroutine(ConclusaoDaFase());
        }
    }
    IEnumerator ConclusaoDaFase()
    {
        yield return new WaitForSeconds(1f);

        // Encontra todos inimigos e "mata" eles.
        GameObject[] inimigosVivos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject inimigo in inimigosVivos)
        {
            inimigo.SendMessage("Morte");
        }

        yield return new WaitForSeconds(2f);

        Time.timeScale = 0f;
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_LEVELCONCLUSION);
    }
    /*private void ControladorDaFase()
    {
        if (_contadorTimerFase > 0f && _contadorTimerFase < 59f && _timerSpawn <= 0) // 1° minuto de jogo
        {
            SummonSnake();
            _timerSpawn = 1.5f;
        }

        if (_contadorTimerFase > 60f && _contadorTimerFase < 119f && _timerSpawn <= 0) // 2° minuto de jogo
        {
            SummonSnake();
            _timerSpawn = 1.25f;
        }

        if (_contadorTimerFase > 120f && _contadorTimerFase < 179f && _timerSpawn <= 0) // 3° minuto de jogo
        {
            SnakeSiege();       // Siege Snake *****
            SummonSnake();
            _timerSpawn = 1.5f;
        }

        if (_contadorTimerFase > 180f && _contadorTimerFase < 239f && _timerSpawn <= 0) // 4° minuto de jogo
        {
            SummonSnake();
            _timerSpawn = 0.85f;
        }

        if (_contadorTimerFase > 240f && _contadorTimerFase < 299f && _timerSpawn <= 0) // 5° minuto de jogo
        {
            SummonSnake();
            _timerSpawn = 0.9f;
        }

        if (_contadorTimerFase > 300f && _contadorTimerFase < 359f && _timerSpawn <= 0) // 6° minuto de jogo
        {
            SummonSnake();
            SnakeBoss();                    // *************  BOSSSSS
            _timerSpawn = 0.7f;
        }

        if (_contadorTimerFase > 360f && _contadorTimerFase < 419f && _timerSpawn <= 0) // 7° minuto de jogo
        {
            SummonMummy();
            _timerSpawn = 0.65f;
        }

        if (_contadorTimerFase > 420f && _contadorTimerFase < 479f && _timerSpawn <= 0) // 8° minuto de jogo  
        {
            SummonMummy();
            _timerSpawn = 0.6f;
        }

        if (_contadorTimerFase > 480f && _contadorTimerFase < 539f && _timerSpawn <= 0) // 9° minuto de jogo
        {
            MummySiege();       // SIEGE MUMMY ****
            SummonMummy();
            _timerSpawn = 1f;
        }

        if (_contadorTimerFase > 540f && _contadorTimerFase < 599f && _timerSpawn <= 0) // 10° minuto de jogo
        {
            SummonMummy();
            _timerSpawn = 0.6f;
        }

        if (_contadorTimerFase > 600f && _contadorTimerFase < 659f && _timerSpawn <= 0) // 11° minuto de jogo
        {
            SummonMummy();
            MummyBoss();                    // *************  BOSSSSS
            _timerSpawn = 0.85f;
        }

        if (_contadorTimerFase > 660f && _contadorTimerFase < 719f && _timerSpawn <= 0) // 12° minuto de jogo
        {
            SummonCamelo();
            _timerSpawn = 0.6f;
        }

        if (_contadorTimerFase > 720f && _contadorTimerFase < 779f && _timerSpawn <= 0) // 13° minuto de jogo
        {
            SummonCamelo();
            _timerSpawn = 0.55f;
        }

        if (_contadorTimerFase > 780f && _contadorTimerFase < 839f && _timerSpawn <= 0) // 14° minuto de jogo
        {
            CameloSiege();  // SIEGE CAMELO ****
            SummonCamelo();
            _timerSpawn = 0.9f;
        }

        if (_contadorTimerFase > 840f && _contadorTimerFase < 899f && _timerSpawn <= 0) // 15° minuto de jogo
        {
            SummonCamelo();
            _timerSpawn = 0.55f;
        }

        if (_contadorTimerFase > 900f && _contadorTimerFase < 959f && _timerSpawn <= 0) // 16° minuto de jogo
        {
            SummonCamelo();
            CameloBoss();                    // *************  BOSSSSS
            _timerSpawn = 0.65f;
        }

        if (_contadorTimerFase > 960f && _contadorTimerFase < 1019f && _timerSpawn <= 0) // 17° minuto de jogo
        {
            SummonCaixao();
            _timerSpawn = 0.55f;
        }

        if (_contadorTimerFase > 1020f && _contadorTimerFase < 1079f && _timerSpawn <= 0) // 18° minuto de jogo
        {
            SummonCaixao();
            _timerSpawn = 0.525f;
        }

        if (_contadorTimerFase > 1080f && _contadorTimerFase < 1139f && _timerSpawn <= 0) // 19° minuto de jogo
        {
            CaixaoSiege();  // SIEGE CAIXAO ****
            SummonCaixao();
            _timerSpawn = 0.5f;
        }

        if (_contadorTimerFase > 1140f && _contadorTimerFase < 1199f && _timerSpawn <= 0) // 20° minuto de jogo
        {
            SummonCaixao();
            _timerSpawn = 0.5f;
        }

        if (_contadorTimerFase > 1200f && _contadorTimerFase < 1259f && _timerSpawn <= 0) // 21° minuto de jogo
        {
            SummonCaixao();
            CaixaoBoss();                    // *************  BOSSSSS
            _timerSpawn = 0.6f;
        }

        if (_contadorTimerFase > 1260f && _contadorTimerFase < 1319f && _timerSpawn <= 0) // 22° minuto de jogo
        {
            SummonDjinn();
            _timerSpawn = 0.475f;
        }

        if (_contadorTimerFase > 1320f && _contadorTimerFase < 1379f && _timerSpawn <= 0) // 23° minuto de jogo
        {
            SummonDjinn();
            _timerSpawn = 0.45f;
        }

        if (_contadorTimerFase > 1380f && _contadorTimerFase < 1439f && _timerSpawn <= 0) // 24° minuto de jogo
        {
            DjinnSiege();   // SIEGE DJINN ****
            SummonDjinn();
            _timerSpawn = 0.5f;
        }

        if (_contadorTimerFase > 1440f && _contadorTimerFase < 1499f && _timerSpawn <= 0) // 25° minuto de jogo
        {
            SummonDjinn();
            _timerSpawn = 0.45f;
        }

        if (_contadorTimerFase > 1500f && _contadorTimerFase < 1559f && _timerSpawn <= 0) // 26° minuto de jogo
        {
            SummonDjinn();
            DjinnBoss();                    // *************  BOSSSSS
            _timerSpawn = 0.50f;
        }

        if (_contadorTimerFase > 1560f && _contadorTimerFase < 1619f && _timerSpawn <= 0) // 27° minuto de jogo
        {
            SummonCaixao();
            SummonDjinn();
            _timerSpawn = 0.45f;
        }

        if (_contadorTimerFase > 1620f && _contadorTimerFase < 1679f && _timerSpawn <= 0) // 28° minuto de jogo
        {
            SummonCaixao();
            SummonDjinn();
            _timerSpawn = 0.4f;
        }

        if (_contadorTimerFase > 1680f && _contadorTimerFase < 1739f && _timerSpawn <= 0) // 29° minuto de jogo
        {
            SummonCaixao();
            SummonDjinn();
            _timerSpawn = 0.35f;
        }

        if (_contadorTimerFase > 1740f && _contadorTimerFase < 1769f && _timerSpawn <= 0) // 30° minuto de jogo
        {
            SummonCaixao();
            SummonDjinn();
            _timerSpawn = 0.325f;
        }
        if (_contadorTimerFase > 1770f && _contadorTimerFase < 1799f && _timerSpawn <= 0) // Ultimos 30 segundos
        {
            SummonCaixao();
            SummonDjinn();
            _timerSpawn = 0.3f;
        }
        if (_contadorTimerFase > 1800f && _timerSpawn <= 0) // 31° minuto de jogo
        {

        }
    }
    // Monstros Comuns
    private void SummonSnake()
    {
        SpawnControllerFase01.Instance.SpawnEnemy(6);
    }
    private void SummonMummy()
    {
        SpawnControllerFase01.Instance.SpawnEnemy(7);
    }
    private void SummonCamelo()
    {
        SpawnControllerFase01.Instance.SpawnEnemy(8);
    }
    private void SummonCaixao()
    {
        SpawnControllerFase01.Instance.SpawnEnemy(9);
    }
    private void SummonDjinn()
    {
        SpawnControllerFase01.Instance.SpawnEnemy(10);
    }

    // Sieges
    private void SnakeSiege()
    {
        if (!_siege1Snake)
        {
            SpawnControllerFase01.Instance.SpawnSiege(5);
            _siege1Snake = true;
        }
    }
    private void MummySiege()
    {
        if (!_siege1Mummy)
        {
            SpawnControllerFase01.Instance.SpawnSiege(6);
            _siege1Mummy = true;
        }
    }
    private void CameloSiege()
    {
        if (!_siege1Camelo)
        {
            SpawnControllerFase01.Instance.SpawnSiege(7);
            _siege1Camelo = true;
        }
    }
    private void CaixaoSiege()
    {
        if (!_siege1Caixao)
        {
            SpawnControllerFase01.Instance.SpawnSiege(8);
            _siege1Caixao = true;
        }
    }
    private void DjinnSiege()
    {
        if (!_siege1Djinn)
        {
            SpawnControllerFase01.Instance.SpawnSiege(9);
            _siege1Djinn = true;
        }
    }

    // Bosses
    private void SnakeBoss()
    {
        if (!_bossSnake)
        {
            SpawnControllerFase01.Instance.SpawnBoss(5);
            _bossSnake = true;
        }
    }
    private void MummyBoss()
    {
        if (!_bossMummy)
        {
            SpawnControllerFase01.Instance.SpawnBoss(6);
            _bossMummy = true;
        }
    }
    private void CameloBoss()
    {
        if (!_bossCamelo)
        {
            SpawnControllerFase01.Instance.SpawnBoss(7);
            _bossCamelo = true;
        }
    }
    private void CaixaoBoss()
    {
        if (!_bossCaixao)
        {
            SpawnControllerFase01.Instance.SpawnBoss(8);
            _bossCaixao = true;
        }
    }
    private void DjinnBoss()
    {
        if (!_bossDjinn)
        {
            SpawnControllerFase01.Instance.SpawnBoss(9);
            _bossDjinn = true;
        }
    }*/
}
