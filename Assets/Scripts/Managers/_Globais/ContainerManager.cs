using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour
{
    public static ContainerManager Instance;

    public enum ContainerType
    {
        // QUALQUER PAINEL
        SPELL_INFO,

        // MAIN MENU - BESTIARY
        MAINMENU_BESTIARY_BTNBESTIARYITEM,

        // MAIN MENU - UPGRADES
        MAINMENU_UPGRADES_BTNHERO,

        // MAIN MENU - SHOP
        MAINMENU_SHOP_BTNPOTION,
        MAINMENU_SHOP_BTNRELIC,
    }

    [Header("====== Containers ======")]
    [SerializeField] private GameObject Container_SpellInfo;
    [SerializeField] private GameObject Container_MainMenu_Bestiary_BestiaryItem;
    [SerializeField] private GameObject Container_MainMenu_Upgrades_BTNHero;
    [SerializeField] private GameObject Container_MainMenu_Shop_BTNPotion;
    [SerializeField] private GameObject Container_MainMenu_Shop_BTNRelic;

    // Dicion�rio com todos os containers.
    private Dictionary<ContainerType, GameObject> containerDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        containerDictionary = new Dictionary<ContainerType, GameObject>
        {
             // Qualquer Painel
             { ContainerType.SPELL_INFO, Container_SpellInfo },

             // Main Menu
             { ContainerType.MAINMENU_BESTIARY_BTNBESTIARYITEM, Container_MainMenu_Bestiary_BestiaryItem },
             { ContainerType.MAINMENU_UPGRADES_BTNHERO, Container_MainMenu_Upgrades_BTNHero },
             { ContainerType.MAINMENU_SHOP_BTNPOTION, Container_MainMenu_Shop_BTNPotion },
             { ContainerType.MAINMENU_SHOP_BTNRELIC, Container_MainMenu_Shop_BTNRelic },
        };
    }

    // ==========================================================================================
    // ========================= FUN��ES PARA MANUSEIO DOS CONTAINERS ===========================
    // ==========================================================================================
    public GameObject InstantiateAndReturnContainer(
        ContainerType containerType, GameObject containerDestiny)
    {
        GameObject newContainer = null;

        if (containerDictionary.TryGetValue(containerType, out GameObject container))
        {
            newContainer = Instantiate(container.gameObject, containerDestiny.transform);
        }

        return newContainer;
    }
    public GameObject InstantiateContainerInPositionAndReturnContainer(
    ContainerType containerType, Vector3 position)
    {
        GameObject newContainer = null;

        if (containerDictionary.TryGetValue(containerType, out GameObject container))
        {
            newContainer = Instantiate(container.gameObject, position, container.transform.rotation);
        }

        return newContainer;
    }
}
