using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_OpeningBau : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_OPENINGBAU;

    private Animator openingBauAnimator;

    public Button BTN_Adquirir;

    [Header("====== Painel Recompensa - FINISH GAME ======")]
    public GameObject Painel_Recompensa_FinishGame;
    public Image IMG_HeroPortrait;
    public TextMeshProUGUI TXT_HeroName;
    public TextMeshProUGUI TXT_CardsQuantity;

    private void Awake()
    {
        openingBauAnimator = GetComponent<Animator>();
        BTN_Adquirir.onClick.AddListener(() => BTN_Adquirir_Action());
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        // Pausa o jogo
        GameManager.Instance.PausarGame(false);

        // Inicia animação do baú abrindo e recompensa
        openingBauAnimator.Play("OpeningBau", -1, 0);

        StartCoroutine(ApresentarRecompensa_FinishGame());

    }

    private IEnumerator ApresentarRecompensa_FinishGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        Painel_Recompensa_FinishGame.SetActive(true);

        // Sorteia a quantidade de Cards
        int cardsGanhos = SortCardsQuantity();

        IMG_HeroPortrait.sprite = Hero.GetHero(HeroImage.heroType).heroPortrait;
        TXT_HeroName.text = Hero.GetHero(HeroImage.heroType).heroName;
        TXT_CardsQuantity.text = cardsGanhos.ToString();

        // Adiciona os cards a conta do jogador.
        PlayerConfig.AddCards(HeroImage.heroType, cardsGanhos);

        BTN_Adquirir.gameObject.SetActive(true);
    }

    private int SortCardsQuantity()
    {
        int qntBaus = PlayerImage.bausRecebidos;
        int totalCards = 0;

        for (int i = 0; i < qntBaus; i++)
        {
            // Para cada baú, sorteia entre 2 e 3 cartas
            int cardsInChest = Random.Range(2, 3); // 11 porque o valor máximo é exclusivo
            totalCards += cardsInChest;
        }

        return totalCards;
    }

    private void BTN_Adquirir_Action()
    {
        BTN_Adquirir.gameObject.SetActive(false);

        // Despausa o jogo
        GameManager.Instance.DesPause();

        // Fecha o painel de bau.
        PanelManager.Instance.FecharPainel(PanelType.GAMEPLAY_OPENINGBAU);
    }
}
