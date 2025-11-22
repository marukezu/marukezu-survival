using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Container_BTN_Upgrade_Heroes : Panel
{
    [Header("====== Hero Dados ======")]
    public TextMeshProUGUI TXT_HeroName;
    public Image IMG_HeroPortrait;

    [Header("====== Hero Level ======")]
    public Image IMG_HeroLevel_Icon;
    public TextMeshProUGUI TXT_HeroLevel;

    [Header("====== Hero Cards ======")]
    public Image IMG_HeroCards_Icon;
    public TextMeshProUGUI TXT_HeroCardsAtual;
    public TextMeshProUGUI TXT_HeroCardsNecessarios;

    [Header("====== Hero Status - HEALTH ======")]
    public Image IMG_HeroMaxHealth_Icon;
    public TextMeshProUGUI TXT_HeroMaxHealth;
    public TextMeshProUGUI TXT_HeroMaxHealthBonus; // Aumento que receberá ao passar de nivel

    [Header("====== Hero Status - MOV SPEED ======")]
    public Image IMG_HeroMovSpeed_Icon;
    public TextMeshProUGUI TXT_HeroMovSpeed;
    public TextMeshProUGUI TXT_HeroMovSpeedBonus; // Aumento que receberá ao passar de nivel

    [Header("====== Hero Status - DAMAGE ======")]
    public Image IMG_HeroDamage_Icon;
    public TextMeshProUGUI TXT_HeroDamage;
    public TextMeshProUGUI TXT_HeroDamageBonus; // Aumento que receberá ao passar de nivel

    [Header("====== Hero Status - COOLDOWN ======")]
    public Image IMG_HeroCooldown_Icon;
    public TextMeshProUGUI TXT_HeroCooldown;
    public TextMeshProUGUI TXT_HeroCooldownBonus; // Aumento que receberá ao passar de nivel

    private Button BTN_ThisButton;
    private Hero hero;

    private float btnClickInterval = 0.75f;
    private float btnClickTimer;
    private bool canClick => btnClickTimer <= 0;

    private void Update()
    {
        btnClickTimer -= Time.deltaTime;
    }

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        BTN_ThisButton = GetComponent<Button>();
        BTN_ThisButton.onClick.RemoveAllListeners();
        BTN_ThisButton.onClick.AddListener(delegate { BTN_ThisButton_Action(); });

        hero = param1 as Hero;

        AtualizarDados();
    }

    private void AtualizarDados()
    {
        // Dados básicos
        TXT_HeroName.text = hero.heroName;
        IMG_HeroPortrait.sprite = hero.heroPortrait;

        // Level
        IMG_HeroLevel_Icon.sprite = SpritesManager.Instance.heroesSprites.Status_Level;
        TXT_HeroLevel.text = hero.heroLevel.ToString();

        // Hero Cards
        IMG_HeroCards_Icon.sprite = hero.heroPortrait;
        TXT_HeroCardsAtual.text = PlayerConfig.GetCardsQuantity(hero.typeHero).ToString();
        TXT_HeroCardsNecessarios.text = hero.cardsToNextLevel.ToString();

        // Max Health
        IMG_HeroMaxHealth_Icon.sprite = SpritesManager.Instance.heroesSprites.Status_MaxHealth;
        TXT_HeroMaxHealth.text = hero.heroBaseMaxHealth.ToString("F0");
        TXT_HeroMaxHealthBonus.text = "+ " + hero.GetHealthPerLevel().ToString();

        // Mov Speed
        IMG_HeroMovSpeed_Icon.sprite = SpritesManager.Instance.heroesSprites.Status_MovSpeed;
        TXT_HeroMovSpeed.text = hero.heroBaseMovSpeed.ToString("F3");
        TXT_HeroMovSpeedBonus.text = "+ " + hero.GetSpeedPerLevel().ToString();

        // Damage
        IMG_HeroDamage_Icon.sprite = SpritesManager.Instance.heroesSprites.Status_Damage;
        TXT_HeroDamage.text = hero.heroBaseDamagePercent.ToString("F1") + "%";
        TXT_HeroDamageBonus.text = "+ " + hero.GetDamagePerLevel().ToString() + "%";

        // Cooldown
        IMG_HeroCooldown_Icon.sprite = SpritesManager.Instance.heroesSprites.Status_Cooldown;
        TXT_HeroCooldown.text = hero.heroBaseCooldownPercent.ToString("F2") + "%";
        TXT_HeroCooldownBonus.text = "+ " + hero.GetCooldownPerLevel().ToString() + "%";
    }

    private void BTN_ThisButton_Action()
    {
        if (!canClick)
            return;

        if (PlayerConfig.GetCardsQuantity(hero.typeHero) >= hero.cardsToNextLevel)
        {
            hero.UpToNextLevel();
            AtualizarDados();
            StartCoroutine(FlashColorCoroutine(Color.green));
            GetComponent<Animator>().SetTrigger("RunPositive");

            SaveManager.SaveGame();
        }
        else
        {

            GetComponent<Animator>().SetTrigger("RunNegative");
            StartCoroutine(FlashColorCoroutine(Color.red));
        }

        btnClickTimer = btnClickInterval;
    }

    private IEnumerator FlashColorCoroutine(Color flashColor)
    {
        Color originalColor = Color.white;
        float duration = 0.25f;
        Image image = GetComponent<Image>();

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
