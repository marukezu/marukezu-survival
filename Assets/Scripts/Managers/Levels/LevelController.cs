using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnController;

public class LevelPhase
{
    public float startTime;
    public float endTime;
    public int level;
    public float spawnCooldown;
    public List<Creatures> normalCreatures;

    public LevelPhase(float startTime, float endTime, int level, float spawnCooldown, List<Creatures> creatureList)
    {
        this.startTime = startTime;
        this.endTime = endTime;
        this.level = level;
        this.spawnCooldown = spawnCooldown;
        normalCreatures = new List<Creatures>(creatureList);
    }
}

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    private List<LevelPhase> fases = new List<LevelPhase>();

    [HideInInspector] public float contadorTimerFase;
    [HideInInspector] public float spawnTimer = 1f;

    [HideInInspector] public bool levelStarted = false;
    [HideInInspector] public bool levelFinished = false;

    // Controladores de eventos.
    [HideInInspector] public bool isDoubleSpawnRate = false;

    public int faseAtualIndex = 0;

    // Tempo fixo de um ciclo (1 minutos)
    private const float DURACAO_CICLO = 60f;
    private const float TEMPO_TOTAL = 36000f; // 10 horas

    private SpawnController.Creatures[] ordemCriaturas = new SpawnController.Creatures[]
    {
        SpawnController.Creatures.Skeleton,
        SpawnController.Creatures.Bat,
        SpawnController.Creatures.Wolf,
        SpawnController.Creatures.Spider,
        SpawnController.Creatures.Zombie,
        SpawnController.Creatures.DeadTree
    };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(gameObject);
    }

    private void Start()
    {
        GerarFasesAutomaticas();
    }

    private void Update()
    {
        if (!levelStarted || fases == null || fases.Count == 0)
            return;

        contadorTimerFase += Time.deltaTime;
        spawnTimer -= Time.deltaTime;

        if (faseAtualIndex < fases.Count)
        {
            LevelPhase fase = fases[faseAtualIndex];

            if (contadorTimerFase > fase.endTime)
            {
                faseAtualIndex++;
                return;
            }

            if (contadorTimerFase >= fase.startTime && contadorTimerFase <= fase.endTime)
            {
                if (spawnTimer <= 0)
                {
                    // Spawns normais
                    foreach (var creature in fase.normalCreatures)
                        SpawnController.Instance.SpawnEnemy(creature, fase.level);

                    if (isDoubleSpawnRate)
                        spawnTimer = fase.spawnCooldown * 0.7f;

                    else
                        spawnTimer = fase.spawnCooldown;
                }
            }
        }

        ContadorTempoFase();
    }

    private void GerarFasesAutomaticas()
    {
        fases.Clear();
        float tempo = 0f;
        int level = 1;
        float spawnCooldown = 2f;
        int indexCriatura = 0;
        int indexTurno = 1;

        while (tempo < TEMPO_TOTAL)
        {
            float start = tempo;
            float end = tempo + DURACAO_CICLO;

            var criaturaBase = ordemCriaturas[indexCriatura];
            var listaNormais = new List<SpawnController.Creatures> { criaturaBase };

            LevelPhase novaFase = new LevelPhase(
                start, end, level,
                spawnCooldown: spawnCooldown, // tempo entre spawns
                creatureList: listaNormais
            );

            fases.Add(novaFase);

            // Entre os minutos 1-3
            if (indexTurno <= 3)
            {
                level += 2;
                spawnCooldown = Random.Range(1.05f, 1.45f);
            }
            if (indexTurno > 3 && indexTurno < 10)
            {
                level += 3;
                spawnCooldown = Random.Range(0.55f, 0.65f);
            }
            if (indexTurno >= 10 && indexTurno < 15)
            {
                level += 3;
                spawnCooldown = Random.Range(0.4f, 0.45f);
            }
            if (indexTurno >= 15 && indexTurno < 20)
            {
                level += 4;
                spawnCooldown = Random.Range(0.35f, 0.4f);
            }
            if (indexTurno >= 20 && indexTurno < 30)
            {
                level += 4;
                spawnCooldown = Random.Range(0.3f, 0.35f);
            }
            if (indexTurno >= 30)
            {
                level += 4;
                spawnCooldown = Random.Range(0.15f, 0.3f);
            }

            indexTurno++;
            tempo += DURACAO_CICLO;
            indexCriatura = (indexCriatura + 1) % ordemCriaturas.Length;
        }

        contadorTimerFase = 0;
        faseAtualIndex = 0;
    }

    private void ContadorTempoFase()
    {
        if (contadorTimerFase > TEMPO_TOTAL && !levelFinished)
        {
            levelFinished = true;
            StartCoroutine(ConclusaoDaFase());
        }
    }

    IEnumerator ConclusaoDaFase()
    {
        yield return new WaitForSeconds(1f);

        GameObject[] inimigosVivos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject inimigo in inimigosVivos)
        {
            inimigo.GetComponent<Enemy_GameObject>().Death();
        }

        yield return new WaitForSeconds(2f);

        GameManager.Instance.PausarGame();
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_LEVELCONCLUSION);
    }

    public string TimerDaFase()
    {
        // Pega o contador no gamemanager.
        float contadorTempoFase = contadorTimerFase;

        // Converte o tempo decorrido para minutos e segundos
        int minutos = Mathf.FloorToInt(contadorTempoFase / 60);
        int segundos = Mathf.FloorToInt(contadorTempoFase % 60);

        // Atualiza o Text com o tempo formatado
        string contadorFormatado = string.Format("{0:00}:{1:00}", minutos, segundos);

        return contadorFormatado;
    }

    public int GetMonstersLevel()
    {
        return fases[faseAtualIndex].level;
    }
}
