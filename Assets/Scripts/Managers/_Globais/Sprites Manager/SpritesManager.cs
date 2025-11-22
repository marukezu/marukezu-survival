using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    public static SpritesManager Instance;

    public SpritesManager_Spells spellSprites;
    public SpritesManager_Heroes heroesSprites;
    public SpritesManager_Currency currencySprites;
    public SpritesManager_Relics relicsSprites;
    public SpritesManager_Condition conditionSprites;
    public SpritesManager_Upgrades upgradesSprites;
    public SpritesManager_Potions potionsSprites;

    [Header("====== Upgrade - Levels ======")]
    public Sprite spriteUpgradeLevel0;
    public Sprite spriteUpgradeLevel1; 
    public Sprite spriteUpgradeLevel2; 
    public Sprite spriteUpgradeLevel3; 
    public Sprite spriteUpgradeLevel4; 
    public Sprite spriteUpgradeLevel5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
