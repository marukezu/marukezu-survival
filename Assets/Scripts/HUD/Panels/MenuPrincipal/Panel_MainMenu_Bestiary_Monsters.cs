using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Panel_MainMenu_Bestiary_Monsters : Panel
{
    [Header("====== Painel Pai ======")]
    [SerializeField] private Panel_MainMenu_Bestiary Panel_Bestiary;

    [Header("====== Content onde será instanciado os botões ======")]
    public GameObject Content_Monsters_Buttons;

    [Header("====== Componentes de HUD ======")]
    public Image IMG_BestiaryMonster;
    public Text TXT_Killed, TXT_KilledValue, TXT_BestiaryMonsterHP, TXT_BestiaryMonsterHPValue, TXT_BestiaryMonsterSpeed, TXT_BestiaryMonsterSpeedValue, TXT_BestiaryMonsterDescription;

    private void Awake()
    {
        TXT_Killed.text = LanguageManager.Get("Killed");
        TXT_BestiaryMonsterHP.text = LanguageManager.Get("Health");
        TXT_BestiaryMonsterSpeed.text = LanguageManager.Get("Speed");
        Instantiate_Monsters_Buttons();
    }

    private void Instantiate_Monsters_Buttons()
    {
        // Ordena os monstros por nome
        var orderedMonsters = MonsterList.AllMonsters.OrderBy(monster => monster.ID);

        foreach (Monster monster in orderedMonsters)
        {
            GameObject newContainer = ContainerManager.Instance.InstantiateAndReturnContainer(
                ContainerManager.ContainerType.MAINMENU_BESTIARY_BTNBESTIARYITEM,
                Content_Monsters_Buttons
            );

            Container_BTN_Bestiary_Item containerScript = newContainer.GetComponent<Container_BTN_Bestiary_Item>();
            containerScript.AbrirPainel(monster, Panel_Bestiary);
        }
    }

}
