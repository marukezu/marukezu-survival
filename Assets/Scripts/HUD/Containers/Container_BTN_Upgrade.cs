using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Container_BTN_Upgrade : Panel
{
    private Upgrade upgrade;

    [Header("====== Basic Info ======")]
    public Image IMG_UpgradeIcon;
    public TextMeshProUGUI TXT_UpgradeName;
    public TextMeshProUGUI TXT_UpgradeDescription;

    [Header("====== Value ======")]
    public Image IMG_CurrencyIcon;
    public TextMeshProUGUI TXT_UpgradeValue;

    [Header("====== Upgrade Level ======")]
    public Image IMG_UpgradeLevel;


    private Button BTN_ThisButton;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        upgrade = param1 as Upgrade;

        BTN_ThisButton = GetComponent<Button>();
        BTN_ThisButton.onClick.AddListener(delegate { ThisButton_Action(); });

        AtualizarInformacoes();
    }

    private void ThisButton_Action()
    {
        RealizarUpgrade();
        AtualizarInformacoes();
    }

    private void AtualizarInformacoes()
    {
        // Basic Info
        IMG_UpgradeIcon.sprite = upgrade.upgradeIcon;
        TXT_UpgradeName.text = upgrade.upgradeName;
        TXT_UpgradeDescription.text = upgrade.upgradeDescription;

        // Value
        IMG_CurrencyIcon.sprite = SpritesManager.Instance.currencySprites.GreenGem;
        TXT_UpgradeValue.text = upgrade.upgradeValue.ToString();
        TXT_UpgradeValue.color = upgrade.upgradeValue <= PlayerConfig.playerGreenGem ? Color.green : Color.red;

        // Upgrade Level
        switch (upgrade.upgradeLevel)
        {
            case 0:
                IMG_UpgradeLevel.sprite = SpritesManager.Instance.spriteUpgradeLevel0;
                break;

            case 1:
                IMG_UpgradeLevel.sprite = SpritesManager.Instance.spriteUpgradeLevel1;
                break;

            case 2:
                IMG_UpgradeLevel.sprite = SpritesManager.Instance.spriteUpgradeLevel2;
                break;

            case 3:
                IMG_UpgradeLevel.sprite = SpritesManager.Instance.spriteUpgradeLevel3;
                break;

            case 4:
                IMG_UpgradeLevel.sprite = SpritesManager.Instance.spriteUpgradeLevel4;
                break;

            case 5:
                IMG_UpgradeLevel.sprite = SpritesManager.Instance.spriteUpgradeLevel5;
                TXT_UpgradeValue.text = "MAX";
                TXT_UpgradeValue.color = Color.white;
                break;
        }
    }

    private void RealizarUpgrade()
    {
        // Se o jogador tem a quantidade para comprar o upgrade E o upgrade ainda não está no nível máximo.
        if (upgrade.upgradeValue <= PlayerConfig.playerGreenGem && upgrade.upgradeLevel < upgrade.upgradeMaxLevel)
        {
            // Pisca Verde
            //StartCoroutine(FlashColorCoroutine(Color.green));

            // Debita a currency
            PlayerConfig.playerGreenGem -= upgrade.upgradeValue;

            // Aumenta o nivel do upgrade
            upgrade.AddLevel();

            // Salva o jogo
            SaveManager.SaveGame();
        }
        else
        {
            // AudioManager.Instance.PlaySoundEffectButtons();

            // Pisca Vermelho
            //StartCoroutine(FlashColorCoroutine(Color.red));
            return;
        }
    }
}
