using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerMenu : MonoBehaviour
{
    public static GameManagerMenu Instance;

    // Variáveis para iniciar novo jogo.
    [HideInInspector] public Hero.HeroType StartingHero = Hero.HeroType.None;
    [HideInInspector] public Spell StartingSpell = null;

    // Controle dos efeitos do menu.
    public GameObject chuvaGameObject;
    public Animator logoAnimator, painelTrovaoAnimator;
    private Color corOriginalPainelTrovao, corPainelTrovaoComClarao;
    private float velocidadeChuva = 0.3f, tempoMinimoEntreTrovoes = 2f;

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
    private void Start()
    {
        // Seta a scene atual.
        GameManager.Instance.ActiveScene = GameManager.GameActiveScene.MainMenu;

        // Inicia a Musica tema.
        IniciaMusicaTema();

        // Instancia o painel de botões principais
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.MAINMENU_BOTOESPRINCIPAIS);
    }

    private void Update()
    {
        // Atualizador dos Efeitos.
        MovimentarChuva();
        SortearTrovao();
    }
    // ===========================================================
    // ========== CONTROLE DA MUSICA DO MENU PRINCIPAL ===========
    // ===========================================================
    private void IniciaMusicaTema()
    {
        AudioManager.Instance.PlayMusic(0);
        AudioManager.Instance.PlayChuva(0);
    }

    // ===========================================================
    // =================== CONTROLE DE EFEITO ====================
    // ===========================================================
    private void MovimentarChuva()
    {
        Vector2 deslocamentoChuva = new Vector2(Time.time * velocidadeChuva, Time.time * (velocidadeChuva * 3));
        chuvaGameObject.GetComponent<Image>().material.mainTextureOffset = deslocamentoChuva;
    }
    private void SortearTrovao()
    {
        tempoMinimoEntreTrovoes -= Time.deltaTime;

        if (tempoMinimoEntreTrovoes < 0)
        {
            int sorteioTrovao = Random.Range(0, 100);
            if (sorteioTrovao >= 70)
            {
                AudioManager.Instance.PlayTrovao(Random.Range(0, 3));
                logoAnimator.SetBool("Trovao", true);
                painelTrovaoAnimator.SetBool("Trovao", true);
                Invoke("DesativarEfeitoTrovao", 0.4f);
            }

            tempoMinimoEntreTrovoes = 2f;
        }
    }
    private void DesativarEfeitoTrovao()
    {
        logoAnimator.SetBool("Trovao", false);
        painelTrovaoAnimator.SetBool("Trovao", false);
    }

}
