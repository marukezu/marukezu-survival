using Terresquall;
using UnityEngine;

public class InputsManager : MonoBehaviour
{
    public static InputsManager Instance;

    // Booleans Scene Gameplay
    public bool EstaPausado { get; private set; } = false;
    public bool PodePausar => !EstaPausado;
    public bool PodeControlar => !EstaPausado && !GameManager.Instance.playerHero.isDead;
    public bool ApresentacaoFase { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.ActiveScene == GameManager.GameActiveScene.LanguageSelection)
            CheckNewInput_Scene_LanguageSelection();

        else if (GameManager.Instance.ActiveScene == GameManager.GameActiveScene.MainMenu)
            CheckNewInput_Scene_MainMenu();

        else if (GameManager.Instance.ActiveScene == GameManager.GameActiveScene.GamePlay)
            CheckNewInput_Scene_GamePlay();
    }

    private void CheckNewInput_Scene_LanguageSelection()
    {
        
    }
    private void CheckNewInput_Scene_MainMenu()
    {
        
    }
    private void CheckNewInput_Scene_GamePlay()
    {
        // Controle do Heroi
        if (PodeControlar)
        {
            Vector2 heroDirection = Vector2.zero;

            if (!GameConfig._androidMode) 
            {
                heroDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            }
            else if (GameConfig._androidMode)
            {
                heroDirection = new Vector2(VirtualJoystick.GetAxisRaw("Horizontal"), VirtualJoystick.GetAxisRaw("Vertical")).normalized;
            }

            GameManager.Instance.playerHero.heroInputs.Movimentacao(heroDirection);
        }
    }

    public void SetEstaPausado(bool value)
    {
        EstaPausado = value;
    }

    public void SetApresentacaoFase(bool value)
    {
        ApresentacaoFase = value;
    }
}
