using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_MainInfo : Panel
{
    public override PanelType Type => PanelType.GAMEPLAY_MAININFO;

    [Header("====== Sliders ======")]
    public Slider SLIDER_PlayerHealth;
    public Slider SLIDER_PlayerExp;

    [Header("====== Texts ======")]
    public Text TXT_PlayerLevel;
    public Text TXT_TimerPhase;

    [Header("====== Section Money ======")]
    public Text TXT_MoneyFeitoValue;

    [Header("====== Section Baú Recebido ======")]
    public Image IMG_BauRecompensa;
    public TextMeshProUGUI TXT_BausConquistados;
    public TextMeshProUGUI TXT_BauRecebido;

    [Header("====== Buttons ======")]
    public Button BTN_Pause;

    [Header("====== Potions Buttons ======")]
    public Button BTN_Potion_Explosion;
    public TextMeshProUGUI TXT_Potion_Explosion_Quantity;
    public Button BTN_Potion_Restoration;
    public TextMeshProUGUI TXT_Potion_Restoration_Quantity;

    // 🔹 Fila e controle
    private Queue<IEnumerator> bauQueue = new Queue<IEnumerator>();
    private bool isPlayingBauAnimation = false;

    private void Awake()
    {
        BTN_Pause.onClick.RemoveAllListeners();
        BTN_Pause.onClick.AddListener(() => BTN_Pause_Action());

        BTN_Potion_Explosion.onClick.RemoveAllListeners();
        BTN_Potion_Explosion.onClick.AddListener(BTN_Potion_Explosion_Action);

        BTN_Potion_Restoration.onClick.RemoveAllListeners();
        BTN_Potion_Restoration.onClick.AddListener(BTN_Potion_Restoration_Action);
    }

    public override void AtualizarPainel()
    {
        SLIDER_PlayerHealth.maxValue = HeroImage.GetHeroMaxHP();
        SLIDER_PlayerHealth.value = HeroImage.healthNow;

        SLIDER_PlayerExp.maxValue = HeroImage.GetExpNextLevel();
        SLIDER_PlayerExp.value = HeroImage.playerExpAtual;
        TXT_PlayerLevel.text = HeroImage.playerLevel.ToString();

        TXT_TimerPhase.text = LevelController.Instance.TimerDaFase();
        TXT_MoneyFeitoValue.text = PlayerImage.moneyFeito.ToString();
        TXT_BausConquistados.text = PlayerImage.bausRecebidos.ToString("F0");

        TXT_Potion_Explosion_Quantity.text = "x" + PlayerConfig.potionExplosions.ToString("F0");
        TXT_Potion_Restoration_Quantity.text = "x" + PlayerConfig.potionHealing.ToString("F0");
    }

    private void BTN_Pause_Action()
    {
        if (!InputsManager.Instance.PodePausar)
            return;

        GameManager.Instance.PausarGame();
        AudioManager.Instance.StopChuva();

        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_HEROINFO);
        PanelManager.Instance.InstanciarERetornarPainel(Panel.PanelType.GAMEPLAY_PAUSE);
    }

    private void BTN_Potion_Explosion_Action()
    {
        if (PlayerConfig.potionExplosions <= 0)
            return;

        PotionsList.Potion_Explosion.ConsumePotion();
    }
    private void BTN_Potion_Restoration_Action()
    {
        if (PlayerConfig.potionHealing <= 0)
            return;

        PotionsList.Potion_Restauration.ConsumePotion();
    }

    public void ReceberBau()
    {
        // Adiciona uma animação na fila
        bauQueue.Enqueue(ReceberBau_Action());

        // Se nenhuma animação está rodando, começa o processamento da fila
        if (!isPlayingBauAnimation)
            StartCoroutine(ProcessarFilaBaus());
    }

    private IEnumerator ProcessarFilaBaus()
    {
        isPlayingBauAnimation = true;

        while (bauQueue.Count > 0)
        {
            IEnumerator anim = bauQueue.Dequeue();
            yield return StartCoroutine(anim);
        }

        isPlayingBauAnimation = false;
    }

    private IEnumerator ReceberBau_Action()
    {
        TXT_BauRecebido.gameObject.SetActive(true);
        TXT_BauRecebido.GetComponent<Animator>().SetTrigger("run");
        IMG_BauRecompensa.GetComponent<Animator>().SetTrigger("run");

        yield return new WaitForSeconds(2f);

        TXT_BauRecebido.GetComponent<Animator>().SetTrigger("finish");
        TXT_BauRecebido.gameObject.SetActive(false);

        PlayerImage.bausRecebidos++;
        TXT_BausConquistados.text = PlayerImage.bausRecebidos.ToString("F0");
    }
}
