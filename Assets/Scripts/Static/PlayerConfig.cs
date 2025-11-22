// Essa classe representa toda configuração do jogador, oque ele possui, desbloqueios, conquistas.
public static class PlayerConfig
{
    public static int playerMoney { get; set; } = 50000;
    public static int playerBlueGem { get; set; } = 100;
    public static int playerRedGem { get; set; } = 100;
    public static int playerOrangeGem { get; set; } = 100;
    public static int playerGreenGem { get; set; } = 100;


    // ===========================================================================
    // ============ Configuração de Desbloqueio de Novos Personagens =============
    // ===========================================================================
    public static int zephyrUnlocked = 1, kaelUnlocked = 0, brogharUnlocked = 0;
    public static int zephyrPrice = 0, kaelPrice = 15000, brogharPrice = 15000;

    // ===========================================================================
    // ================== Configuração de Desbloqueio de FASES ===================
    // ===========================================================================
    
    public static bool desertoVentosoUnlocked = false;

    // ===========================================================================
    // ================ Configuração de Desbloqueio de Reliquias =================
    // ===========================================================================
    
    public static int SkeletonRelicAdquired = 0;
    public static int BatRelicAdquired = 0;
    public static int WolfRelicAdquired = 0;
    public static int ZombieRelicAdquired = 0;
    public static int DeadTreeRelicAdquired = 0;

    // ===========================================================================
    // ========== Configuração dos Upgrades (MENU PRINCIPAL - UPGRADES) ==========
    // ===========================================================================

    // Heroes
    public static int zephyrCards = 250, kaelCards = 0, brogharCards = 0;
    public static int zephyrLevel = 1, kaelLevel = 1, brogharLevel = 1;

    public static void AddCards(Hero.HeroType heroType, int value)
    {
        switch (heroType)
        {
            case Hero.HeroType.Zephyr:
                zephyrCards += value;
                break;

            case Hero.HeroType.Kael:
                kaelCards += value;
                break;

            case Hero.HeroType.Broghar:
                brogharCards += value;
                break;
        }
    }

    public static int GetCardsQuantity(Hero.HeroType heroType)
    {
        switch (heroType)
        {
            case Hero.HeroType.Zephyr:
                return zephyrCards;

            case Hero.HeroType.Kael:
                return kaelCards;

            case Hero.HeroType.Broghar:
                return brogharCards;

            default: return 0;
        }
    }

    // Relics
    public static int skeletonRelicUpgradeLevel = 0;
    public static int batRelicUpgradeLevel = 0;

    // ===========================================================================
    // ================================= Poções ==================================
    // ===========================================================================
    public static int potionExplosions = 0;
    public static int potionHealing = 0;

    public static void BuyPotion(Potion.PotionType potionType)
    {
        switch (potionType)
        {
            case Potion.PotionType.Explosive:
                potionExplosions++;
                break;

            case Potion.PotionType.Restoration:
                potionHealing++;
                break;
        }
    }

    // ===========================================================================
    // ================== Configuração do desbloqueio BESTIARY ===================
    // ===========================================================================

    // Monsters Fase 01 - KILLS
    public static int bestiarySkeletonKilled = 0, bestiaryBatKilled = 0, bestiaryWolfKilled = 0, bestiaryZombieKilled = 0, bestiaryDeadTreeKilled = 0, bestiarySpiderKilled;
    public static int bestiarySkeletonBossKilled = 0, bestiaryBatBossKilled = 0, bestiaryWolfBossKilled = 0, bestiaryZombieBossKilled = 0, bestiaryDeadTreeBossKilled = 0, bestiarySpiderBossKilled;

    // Monsters Fase 02 - KILLS
    public static int bestiarySnakeKilled = 0, bestiaryMummyKilled = 0, bestiaryCameloKilled = 0, bestiaryCaixaoKilled = 0, bestiaryDjinnKilled = 0;
    public static int bestiarySnakeBossKilled = 0, bestiaryMummyBossKilled = 0, bestiaryCameloBossKilled = 0, bestiaryCaixaoBossKilled = 0, bestiaryDjinnBossKilled = 0;

    // Monsters Conhecidos
    public static bool bestiarySkeletonUnlocked = false;
    public static bool bestiaryBatUnlocked = false;
    public static bool bestiaryWolfUnlocked = false;
    public static bool bestiaryZombieUnlocked = false;
    public static bool bestiaryDeadTreeUnlocked = false;
    public static bool bestiarySpiderUnlocked = false;
    public static bool bestiarySkeletonBossUnlocked = false;
    public static bool bestiaryBatBossUnlocked = false;
    public static bool bestiaryWolfBossUnlocked = false;
    public static bool bestiaryZombieBossUnlocked = false;
    public static bool bestiaryDeadTreeBossUnlocked = false;
    public static bool bestiarySnakeUnlocked = false;
    public static bool bestiaryMummyUnlocked = false;
    public static bool bestiaryCameloUnlocked = false;
    public static bool bestiaryCaixaoUnlocked = false;
    public static bool bestiaryDjinnUnlocked = false;
    public static bool bestiarySnakeBossUnlocked = false;
    public static bool bestiaryMummyBossUnlocked = false;
    public static bool bestiaryCameloBossUnlocked = false;
    public static bool bestiaryCaixaoBossUnlocked = false;
    public static bool bestiaryDjinnBossUnlocked = false;

    // Relics Conhecidas
    public static bool bestiarySkeletonRelicUnlocked = false;
    public static bool bestiaryBatRelicUnlocked = false;
    public static bool bestiaryWolfRelicUnlocked = false;
    public static bool bestiaryZombieRelicUnlocked = false;
    public static bool bestiaryDeadTreeRelicUnlocked = false;

    // Spells Conhecidas
    public static bool bestiaryShurikenUnlocked = false;
    public static bool bestiaryArrowUnlocked = false;
    public static bool bestiaryFireballUnlocked = false;
    public static bool bestiaryExplosionUnlocked = false;
    public static bool bestiaryIcicleUnlocked = false;
    public static bool bestiaryThunderUnlocked = false;
    public static bool bestiaryThunderBallUnlocked = false;
    public static bool bestiaryThunderaUnlocked = false;
    public static bool bestiaryThunderBarrierUnlocked = false;
    public static bool bestiaryAxeThrowUnlocked = false;
    public static bool bestiaryPierceDaggerUnlocked = false;
    public static bool bestiaryGauntletUnlocked = false;
    public static bool bestiaryClockUnlocked = false;
    public static bool bestiaryBootsUnlocked = false;
    public static bool bestiaryHandUnlocked = false;
    public static bool bestiaryHeartUnlocked = false;
    public static bool bestiaryRerolUnlocked = false;
    public static bool bestiaryCorteCircularUnlocked = false;
    public static bool bestiaryThunderPulseUnlocked = false;
    public static bool bestiaryFireElementalUnlocked = false;
    public static bool bestiaryTornadoFuryUnlocked = false;
    public static bool bestiaryMeteorUnlocked = false;
    public static bool bestiaryIgnisArrowUnlocked = false;
    public static bool bestiaryRainOfArrowUnlocked = false;
    public static bool bestiaryTheEightKunaisUnlocked = false;
    public static bool bestiaryMultipleShotUnlocked = false;
    public static bool bestiaryPoisonKunaiUnlocked = false;
    public static bool bestiaryTerremotoUnlocked = false;
    public static bool bestiaryShieldThrowUnlocked = false;
    public static bool bestiaryCycloneUnlocked = false;
}
