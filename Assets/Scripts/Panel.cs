using UnityEngine;

public class Panel : MonoBehaviour
{
    public enum PanelType
    {
        // Main Menu
        MAINMENU_BOTOESPRINCIPAIS,
        MAINMENU_PLAY,
        MAINMENU_UPGRADES,
        MAINMENU_CREDITOS,
        MAINMENU_CONFIGURACOES,
        MAINMENU_CHANGELOG,
        MAINMENU_BESTIARY,
        MAINMENU_SHOP,

        // GamePlay
        GAMEPLAY_APRESENTACAOFASE,
        GAMEPLAY_MAININFO,
        GAMEPLAY_HEROINFO,
        GAMEPLAY_CHOOSE_NEW_SPELL,
        GAMEPLAY_PAUSE,
        GAMEPLAY_GAMEOVER,
        GAMEPLAY_LEVELCONCLUSION,
        GAMEPLAY_OPENINGBAU,
        GAMEPLAY_TALENTS,

        // Outros
        EVENT_INFO,
    }

    public virtual PanelType Type { get; set; }
    protected bool Initialized = false;

    protected virtual void OnDestroy()
    {
        PanelManager.Instance.UnregisterPanel(this);
    }

    private void Update()
    {
        // Atualiza sempre que o painel estiver ativo.
        if (gameObject.activeSelf)
        {
            AtualizarPainel();
        }

        // Inicializa uma vez o painel.
        if (!Initialized)
        {
            Initialize();
            Initialized = true;
        }
    }

    // Initialize para containers.
    public virtual void Initialize(object param1 = null, object param2 = null, object param3 = null) { }
    public virtual void AtualizarPainel() { }

    // Funções para GameObjects do tipo Panel.
    public virtual void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        gameObject.SetActive(true);
    }
    public virtual void OcultarPainel()
    {
        gameObject.SetActive(false);
    }
    public virtual void FecharPainel()
    {
        Destroy(gameObject);
    }
}
