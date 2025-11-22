using UnityEngine;

public static class SaveManager
{
    public static void SalvaOpcoesResolucao()
    {
        PlayerPrefs.SetInt("FullScreen", GameConfig._fullScreen ? 1 : 0);
        PlayerPrefs.SetString("ResolucaoXAtual", GameConfig._resolucaoXAtual);
        PlayerPrefs.SetString("ResolucaoYAtual", GameConfig._resolucaoYAtual);
    }

    public static void LoadOpcoesResolucao()
    {
        GameConfig._fullScreen = PlayerPrefs.GetInt("FullScreen", 1) == 1;
        GameConfig._resolucaoXAtual = PlayerPrefs.GetString("ResolucaoXAtual", "1920");
        GameConfig._resolucaoYAtual = PlayerPrefs.GetString("ResolucaoYAtual", "1080");
    }

    public static void SaveGame()
    {
        if (GameConfig._debugMode)
            return;

        // Dados do Jogo.
        PlayerPrefs.SetFloat("VolumeMusica", GameConfig.volumeMusica);
        PlayerPrefs.SetFloat("VolumeSoundEffects", GameConfig.volumeSoundEffects);
        PlayerPrefs.SetFloat("VolumeChuva", GameConfig.volumeChuva);
        PlayerPrefs.SetFloat("VolumeTrovoes", GameConfig.volumeTrovoes);

        // Player Currency
        PlayerPrefs.SetInt("PlayerMoney", PlayerConfig.playerMoney);
        PlayerPrefs.SetInt("PlayerBlueGem", PlayerConfig.playerBlueGem);
        PlayerPrefs.SetInt("PlayerRedGem", PlayerConfig.playerRedGem);
        PlayerPrefs.SetInt("PlayerOrangeGem", PlayerConfig.playerOrangeGem);
        PlayerPrefs.SetInt("PlayerGreenGem", PlayerConfig.playerGreenGem);

        // Upgrades
        PlayerPrefs.SetInt("SkeletonRelicUpgradeLevel", PlayerConfig.skeletonRelicUpgradeLevel);
        PlayerPrefs.SetInt("BatRelicUpgradeLevel", PlayerConfig.batRelicUpgradeLevel);

        // Relíquias adquiridas
        PlayerPrefs.SetInt("ReliquiaSkeletonActive", PlayerConfig.SkeletonRelicAdquired);
        PlayerPrefs.SetInt("ReliquiaMorcegoActive", PlayerConfig.BatRelicAdquired);
        PlayerPrefs.SetInt("ReliquiaLoboActive", PlayerConfig.WolfRelicAdquired);
        PlayerPrefs.SetInt("ReliquiaZumbiActive", PlayerConfig.ZombieRelicAdquired);
        PlayerPrefs.SetInt("ReliquiaArvoreActive", PlayerConfig.DeadTreeRelicAdquired);

        // Personagens desbloqueados
        PlayerPrefs.SetInt("MageUnlocked", PlayerConfig.zephyrUnlocked);
        PlayerPrefs.SetInt("RogueUnlocked", PlayerConfig.kaelUnlocked);
        PlayerPrefs.SetInt("DwarfUnlocked", PlayerConfig.brogharUnlocked);

        // Heroes Cards
        PlayerPrefs.SetInt("ZephyrCards", PlayerConfig.zephyrCards);
        PlayerPrefs.SetInt("KaelCards", PlayerConfig.kaelCards);
        PlayerPrefs.SetInt("BrogharCards", PlayerConfig.brogharCards);

        // Heroes Level
        PlayerPrefs.SetInt("ZephyrLevel", PlayerConfig.zephyrLevel);
        PlayerPrefs.SetInt("KaelLevel", PlayerConfig.kaelLevel);
        PlayerPrefs.SetInt("BrogharLevel", PlayerConfig.brogharLevel);

        // Fases Desbloqueadas
        PlayerPrefs.SetInt("DesertoVentosoUnlocked", PlayerConfig.desertoVentosoUnlocked ? 1 : 0);

        // Poções
        PlayerPrefs.SetInt("PotionExplosion", PlayerConfig.potionExplosions);
        PlayerPrefs.SetInt("PotionHealing", PlayerConfig.potionHealing);

        // Bestiário
        // Kills
        PlayerPrefs.SetInt("BestiarySkeletonKilled", PlayerConfig.bestiarySkeletonKilled);
        PlayerPrefs.SetInt("BestiaryBatKilled", PlayerConfig.bestiaryBatKilled);
        PlayerPrefs.SetInt("BestiaryWolfKilled", PlayerConfig.bestiaryWolfKilled);
        PlayerPrefs.SetInt("BestiaryZombieKilled", PlayerConfig.bestiaryZombieKilled);
        PlayerPrefs.SetInt("BestiaryDeadTreeKilled", PlayerConfig.bestiaryDeadTreeKilled);
        PlayerPrefs.SetInt("BestiarySpiderKilled", PlayerConfig.bestiarySpiderKilled);
        PlayerPrefs.SetInt("BestiarySkeletonBossKilled", PlayerConfig.bestiarySkeletonBossKilled);
        PlayerPrefs.SetInt("BestiaryBatBossKilled", PlayerConfig.bestiaryBatBossKilled);
        PlayerPrefs.SetInt("BestiaryWolfBossKilled", PlayerConfig.bestiaryWolfBossKilled);
        PlayerPrefs.SetInt("BestiaryZombieBossKilled", PlayerConfig.bestiaryZombieBossKilled);
        PlayerPrefs.SetInt("BestiaryDeadTreeBossKilled", PlayerConfig.bestiaryDeadTreeBossKilled);
        PlayerPrefs.SetInt("BestiarySnakeKilled", PlayerConfig.bestiarySnakeKilled);
        PlayerPrefs.SetInt("BestiaryMummyKilled", PlayerConfig.bestiaryMummyKilled);
        PlayerPrefs.SetInt("BestiaryCameloKilled", PlayerConfig.bestiaryCameloKilled);
        PlayerPrefs.SetInt("BestiaryCaixaoKilled", PlayerConfig.bestiaryCaixaoKilled);
        PlayerPrefs.SetInt("BestiaryDjinnKilled", PlayerConfig.bestiaryDjinnKilled);
        PlayerPrefs.SetInt("BestiarySnakeBossKilled", PlayerConfig.bestiarySnakeBossKilled);
        PlayerPrefs.SetInt("BestiaryMummyBossKilled", PlayerConfig.bestiaryMummyBossKilled);
        PlayerPrefs.SetInt("BestiaryCameloBossKilled", PlayerConfig.bestiaryCameloBossKilled);
        PlayerPrefs.SetInt("BestiaryCaixaoBossKilled", PlayerConfig.bestiaryCaixaoBossKilled);
        PlayerPrefs.SetInt("BestiaryDjinnBossKilled", PlayerConfig.bestiaryDjinnBossKilled);

        // Monsters
        PlayerPrefs.SetInt("BestiarySkeletonUnlocked", PlayerConfig.bestiarySkeletonUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryBatUnlocked", PlayerConfig.bestiaryBatUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryWolfUnlocked", PlayerConfig.bestiaryWolfUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryZombieUnlocked", PlayerConfig.bestiaryZombieUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryDeadTreeUnlocked", PlayerConfig.bestiaryDeadTreeUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiarySpiderUnlocked", PlayerConfig.bestiarySpiderUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiarySkeletonBossUnlocked", PlayerConfig.bestiarySkeletonBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryBatBossUnlocked", PlayerConfig.bestiaryBatBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryWolfBossUnlocked", PlayerConfig.bestiaryWolfBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryZombieBossUnlocked", PlayerConfig.bestiaryZombieBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryDeadTreeBossUnlocked", PlayerConfig.bestiaryDeadTreeBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiarySnakeUnlocked", PlayerConfig.bestiarySnakeUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryMummyUnlocked", PlayerConfig.bestiaryMummyUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryCameloUnlocked", PlayerConfig.bestiaryCameloUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryCaixaoUnlocked", PlayerConfig.bestiaryCaixaoUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryDjinnUnlocked", PlayerConfig.bestiaryDjinnUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiarySnakeBossUnlocked", PlayerConfig.bestiarySnakeBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryMummyBossUnlocked", PlayerConfig.bestiaryMummyBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryCameloBossUnlocked", PlayerConfig.bestiaryCameloBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryCaixaoBossUnlocked", PlayerConfig.bestiaryCaixaoBossUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryDjinnBossUnlocked", PlayerConfig.bestiaryDjinnBossUnlocked ? 1 : 0);

        // Relics
        PlayerPrefs.SetInt("BestiarySkeletonRelicUnlocked", PlayerConfig.bestiarySkeletonRelicUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryBatRelicUnlocked", PlayerConfig.bestiaryBatRelicUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryWolfRelicUnlocked", PlayerConfig.bestiaryWolfRelicUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryZombieRelicUnlocked", PlayerConfig.bestiaryZombieRelicUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryDeadTreeRelicUnlocked", PlayerConfig.bestiaryDeadTreeRelicUnlocked ? 1 : 0);

        // Spells
        PlayerPrefs.SetInt("BestiaryShurikenUnlocked", PlayerConfig.bestiaryShurikenUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryArrowUnlocked", PlayerConfig.bestiaryArrowUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryFireballUnlocked", PlayerConfig.bestiaryFireballUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryExplosionUnlocked", PlayerConfig.bestiaryExplosionUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryIcicleUnlocked", PlayerConfig.bestiaryIcicleUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryThunderUnlocked", PlayerConfig.bestiaryThunderUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryAxeThrowUnlocked", PlayerConfig.bestiaryAxeThrowUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryPierceDaggerUnlocked", PlayerConfig.bestiaryPierceDaggerUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryGauntletUnlocked", PlayerConfig.bestiaryGauntletUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryClockUnlocked", PlayerConfig.bestiaryClockUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryBootsUnlocked", PlayerConfig.bestiaryBootsUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryHandUnlocked", PlayerConfig.bestiaryHandUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryHeartUnlocked", PlayerConfig.bestiaryHeartUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryRerolUnlocked", PlayerConfig.bestiaryRerolUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryCorteCircularUnlocked", PlayerConfig.bestiaryCorteCircularUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryThunderPulseUnlocked", PlayerConfig.bestiaryThunderPulseUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryFireElementalUnlocked", PlayerConfig.bestiaryFireElementalUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryTornadoFuryUnlocked", PlayerConfig.bestiaryTornadoFuryUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryMeteorUnlocked", PlayerConfig.bestiaryMeteorUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryIgnisArrowUnlocked", PlayerConfig.bestiaryIgnisArrowUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryRainOfArrowUnlocked", PlayerConfig.bestiaryRainOfArrowUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryTheEightKunaisUnlocked", PlayerConfig.bestiaryTheEightKunaisUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryMultipleShotUnlocked", PlayerConfig.bestiaryMultipleShotUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryPoisonKunaiUnlocked", PlayerConfig.bestiaryPoisonKunaiUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryTerremotoUnlocked", PlayerConfig.bestiaryTerremotoUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryShieldThrowUnlocked", PlayerConfig.bestiaryShieldThrowUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BestiaryCycloneUnlocked", PlayerConfig.bestiaryCycloneUnlocked ? 1 : 0);

        // Salva os PlayerPrefs
        PlayerPrefs.Save();
    }

    public static void LoadGame()
    {
        if (GameConfig._debugMode)
            return;

        // Dados do Jogo.
        GameConfig.volumeMusica = PlayerPrefs.GetFloat("VolumeMusica", 1f);
        GameConfig.volumeSoundEffects = PlayerPrefs.GetFloat("VolumeSoundEffects", 0.75f);
        GameConfig.volumeChuva = PlayerPrefs.GetFloat("VolumeChuva", 1f);
        GameConfig.volumeTrovoes = PlayerPrefs.GetFloat("VolumeTrovoes", 1f);

        // Player Currency
        PlayerConfig.playerMoney = PlayerPrefs.GetInt("PlayerMoney", 0);
        PlayerConfig.playerBlueGem = PlayerPrefs.GetInt("PlayerBlueGem", 0);
        PlayerConfig.playerRedGem = PlayerPrefs.GetInt("PlayerRedGem", 0);
        PlayerConfig.playerOrangeGem = PlayerPrefs.GetInt("PlayerOrangeGem", 0);
        PlayerConfig.playerGreenGem = PlayerPrefs.GetInt("PlayerGreenGem", 0);

        // Upgrades
        PlayerConfig.skeletonRelicUpgradeLevel = PlayerPrefs.GetInt("SkeletonRelicUpgradeLevel", 0);
        PlayerConfig.batRelicUpgradeLevel = PlayerPrefs.GetInt("BatRelicUpgradeLevel", 0);

        // Relíquias Adquiridas
        PlayerConfig.SkeletonRelicAdquired = PlayerPrefs.GetInt("ReliquiaSkeletonActive", 0);
        PlayerConfig.BatRelicAdquired = PlayerPrefs.GetInt("ReliquiaMorcegoActive", 0);
        PlayerConfig.WolfRelicAdquired = PlayerPrefs.GetInt("ReliquiaLoboActive", 0);
        PlayerConfig.ZombieRelicAdquired = PlayerPrefs.GetInt("ReliquiaZumbiActive", 0);
        PlayerConfig.DeadTreeRelicAdquired = PlayerPrefs.GetInt("ReliquiaArvoreActive", 0);

        // Personagens desbloqueados
        PlayerConfig.zephyrUnlocked = PlayerPrefs.GetInt("MageUnlocked", 1);
        PlayerConfig.kaelUnlocked = PlayerPrefs.GetInt("RogueUnlocked", 0);
        PlayerConfig.brogharUnlocked = PlayerPrefs.GetInt("DwarfUnlocked", 0);

        // Heroes Cards
        PlayerConfig.zephyrCards = PlayerPrefs.GetInt("ZephyrCards", 0);
        PlayerConfig.kaelCards = PlayerPrefs.GetInt("KaelCards", 0);
        PlayerConfig.brogharCards = PlayerPrefs.GetInt("BrogharCards", 0);

        // Heroes Level
        PlayerConfig.zephyrLevel = PlayerPrefs.GetInt("ZephyrLevel", 1);
        PlayerConfig.kaelLevel = PlayerPrefs.GetInt("KaelLevel", 1);
        PlayerConfig.brogharLevel = PlayerPrefs.GetInt("BrogharLevel", 1);

        // Fases Desbloqueadas
        PlayerConfig.desertoVentosoUnlocked = PlayerPrefs.GetInt("DesertoVentosoUnlocked", 0) == 1;

        // Potions
        PlayerConfig.potionExplosions = PlayerPrefs.GetInt("PotionExplosion", 1);
        PlayerConfig.potionHealing = PlayerPrefs.GetInt("PotionHealing", 1);

        // Bestiário
        // Kills
        PlayerConfig.bestiarySkeletonKilled = PlayerPrefs.GetInt("BestiarySkeletonKilled", 0);
        PlayerConfig.bestiaryBatKilled = PlayerPrefs.GetInt("BestiaryBatKilled", 0);
        PlayerConfig.bestiaryWolfKilled = PlayerPrefs.GetInt("BestiaryWolfKilled", 0);
        PlayerConfig.bestiaryZombieKilled = PlayerPrefs.GetInt("BestiaryZombieKilled", 0);
        PlayerConfig.bestiaryDeadTreeKilled = PlayerPrefs.GetInt("BestiaryDeadTreeKilled", 0);
        PlayerConfig.bestiarySpiderKilled = PlayerPrefs.GetInt("BestiarySpiderKilled", 0);
        PlayerConfig.bestiarySkeletonBossKilled = PlayerPrefs.GetInt("BestiarySkeletonBossKilled", 0);
        PlayerConfig.bestiaryBatBossKilled = PlayerPrefs.GetInt("BestiaryBatBossKilled", 0);
        PlayerConfig.bestiaryWolfBossKilled = PlayerPrefs.GetInt("BestiaryWolfBossKilled", 0);
        PlayerConfig.bestiaryZombieBossKilled = PlayerPrefs.GetInt("BestiaryZombieBossKilled", 0);
        PlayerConfig.bestiaryDeadTreeBossKilled = PlayerPrefs.GetInt("BestiaryDeadTreeBossKilled", 0);
        PlayerConfig.bestiarySnakeKilled = PlayerPrefs.GetInt("BestiarySnakeKilled", 0);
        PlayerConfig.bestiaryMummyKilled = PlayerPrefs.GetInt("BestiaryMummyKilled", 0);
        PlayerConfig.bestiaryCameloKilled = PlayerPrefs.GetInt("BestiaryCameloKilled", 0);
        PlayerConfig.bestiaryCaixaoKilled = PlayerPrefs.GetInt("BestiaryCaixaoKilled", 0);
        PlayerConfig.bestiaryDjinnKilled = PlayerPrefs.GetInt("BestiaryDjinnKilled", 0);
        PlayerConfig.bestiarySnakeBossKilled = PlayerPrefs.GetInt("BestiarySnakeBossKilled", 0);
        PlayerConfig.bestiaryMummyBossKilled = PlayerPrefs.GetInt("BestiaryMummyBossKilled", 0);
        PlayerConfig.bestiaryCameloBossKilled = PlayerPrefs.GetInt("BestiaryCameloBossKilled", 0);
        PlayerConfig.bestiaryCaixaoBossKilled = PlayerPrefs.GetInt("BestiaryCaixaoBossKilled", 0);
        PlayerConfig.bestiaryDjinnBossKilled = PlayerPrefs.GetInt("BestiaryDjinnBossKilled", 0);

        // Monster
        PlayerConfig.bestiarySkeletonUnlocked = PlayerPrefs.GetInt("BestiarySkeletonUnlocked", 0) == 1;
        PlayerConfig.bestiaryBatUnlocked = PlayerPrefs.GetInt("BestiaryBatUnlocked", 0) == 1;
        PlayerConfig.bestiaryWolfUnlocked = PlayerPrefs.GetInt("BestiaryWolfUnlocked", 0) == 1;
        PlayerConfig.bestiaryZombieUnlocked = PlayerPrefs.GetInt("BestiaryZombieUnlocked", 0) == 1;
        PlayerConfig.bestiaryDeadTreeUnlocked = PlayerPrefs.GetInt("BestiaryDeadTreeUnlocked", 0) == 1;
        PlayerConfig.bestiarySpiderUnlocked = PlayerPrefs.GetInt("BestiarySpiderUnlocked", 0) == 1;
        PlayerConfig.bestiarySkeletonBossUnlocked = PlayerPrefs.GetInt("BestiarySkeletonBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryBatBossUnlocked = PlayerPrefs.GetInt("BestiaryBatBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryWolfBossUnlocked = PlayerPrefs.GetInt("BestiaryWolfBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryZombieBossUnlocked = PlayerPrefs.GetInt("BestiaryZombieBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryDeadTreeBossUnlocked = PlayerPrefs.GetInt("BestiaryDeadTreeBossUnlocked", 0) == 1;
        PlayerConfig.bestiarySnakeUnlocked = PlayerPrefs.GetInt("BestiarySnakeUnlocked", 0) == 1;
        PlayerConfig.bestiaryMummyUnlocked = PlayerPrefs.GetInt("BestiaryMummyUnlocked", 0) == 1;
        PlayerConfig.bestiaryCameloUnlocked = PlayerPrefs.GetInt("BestiaryCameloUnlocked", 0) == 1;
        PlayerConfig.bestiaryCaixaoUnlocked = PlayerPrefs.GetInt("BestiaryCaixaoUnlocked", 0) == 1;
        PlayerConfig.bestiaryDjinnUnlocked = PlayerPrefs.GetInt("BestiaryDjinnUnlocked", 0) == 1;
        PlayerConfig.bestiarySnakeBossUnlocked = PlayerPrefs.GetInt("BestiarySnakeBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryMummyBossUnlocked = PlayerPrefs.GetInt("BestiaryMummyBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryCameloBossUnlocked = PlayerPrefs.GetInt("BestiaryCameloBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryCaixaoBossUnlocked = PlayerPrefs.GetInt("BestiaryCaixaoBossUnlocked", 0) == 1;
        PlayerConfig.bestiaryDjinnBossUnlocked = PlayerPrefs.GetInt("BestiaryDjinnBossUnlocked", 0) == 1;

        // Relics
        PlayerConfig.bestiarySkeletonRelicUnlocked = PlayerPrefs.GetInt("BestiarySkeletonRelicUnlocked", 0) == 1;
        PlayerConfig.bestiaryBatRelicUnlocked = PlayerPrefs.GetInt("BestiaryBatRelicUnlocked", 0) == 1;
        PlayerConfig.bestiaryWolfRelicUnlocked = PlayerPrefs.GetInt("BestiaryWolfRelicUnlocked", 0) == 1;
        PlayerConfig.bestiaryZombieRelicUnlocked = PlayerPrefs.GetInt("BestiaryZombieRelicUnlocked", 0) == 1;
        PlayerConfig.bestiaryDeadTreeRelicUnlocked = PlayerPrefs.GetInt("BestiaryDeadTreeRelicUnlocked", 0) == 1;

        // Spells
        PlayerConfig.bestiaryShurikenUnlocked = PlayerPrefs.GetInt("BestiaryShurikenUnlocked", 0) == 1;
        PlayerConfig.bestiaryArrowUnlocked = PlayerPrefs.GetInt("BestiaryArrowUnlocked", 0) == 1;
        PlayerConfig.bestiaryFireballUnlocked = PlayerPrefs.GetInt("BestiaryFireballUnlocked", 0) == 1;
        PlayerConfig.bestiaryExplosionUnlocked = PlayerPrefs.GetInt("BestiaryExplosionUnlocked", 0) == 1;
        PlayerConfig.bestiaryIcicleUnlocked = PlayerPrefs.GetInt("BestiaryIcicleUnlocked", 0) == 1;
        PlayerConfig.bestiaryThunderUnlocked = PlayerPrefs.GetInt("BestiaryThunderUnlocked", 0) == 1;
        PlayerConfig.bestiaryAxeThrowUnlocked = PlayerPrefs.GetInt("BestiaryAxeThrowUnlocked", 0) == 1;
        PlayerConfig.bestiaryPierceDaggerUnlocked = PlayerPrefs.GetInt("BestiaryPierceDaggerUnlocked", 0) == 1;
        PlayerConfig.bestiaryGauntletUnlocked = PlayerPrefs.GetInt("BestiaryGauntletUnlocked", 0) == 1;
        PlayerConfig.bestiaryClockUnlocked = PlayerPrefs.GetInt("BestiaryClockUnlocked", 0) == 1;
        PlayerConfig.bestiaryBootsUnlocked = PlayerPrefs.GetInt("BestiaryBootsUnlocked", 0) == 1;
        PlayerConfig.bestiaryHandUnlocked = PlayerPrefs.GetInt("BestiaryHandUnlocked", 0) == 1;
        PlayerConfig.bestiaryHeartUnlocked = PlayerPrefs.GetInt("BestiaryHeartUnlocked", 0) == 1;
        PlayerConfig.bestiaryRerolUnlocked = PlayerPrefs.GetInt("BestiaryRerolUnlocked", 0) == 1;
        PlayerConfig.bestiaryCorteCircularUnlocked = PlayerPrefs.GetInt("BestiaryCorteCircularUnlocked", 0) == 1;
        PlayerConfig.bestiaryThunderPulseUnlocked = PlayerPrefs.GetInt("BestiaryThunderPulseUnlocked", 0) == 1;
        PlayerConfig.bestiaryFireElementalUnlocked = PlayerPrefs.GetInt("BestiaryFireElementalUnlocked", 0) == 1;
        PlayerConfig.bestiaryTornadoFuryUnlocked = PlayerPrefs.GetInt("BestiaryTornadoFuryUnlocked", 0) == 1;
        PlayerConfig.bestiaryMeteorUnlocked = PlayerPrefs.GetInt("BestiaryMeteorUnlocked", 0) == 1;
        PlayerConfig.bestiaryIgnisArrowUnlocked = PlayerPrefs.GetInt("BestiaryIgnisArrowUnlocked", 0) == 1;
        PlayerConfig.bestiaryRainOfArrowUnlocked = PlayerPrefs.GetInt("BestiaryRainOfArrowUnlocked", 0) == 1;
        PlayerConfig.bestiaryTheEightKunaisUnlocked = PlayerPrefs.GetInt("BestiaryTheEightKunaisUnlocked", 0) == 1;
        PlayerConfig.bestiaryMultipleShotUnlocked = PlayerPrefs.GetInt("BestiaryMultipleShotUnlocked", 0) == 1;
        PlayerConfig.bestiaryPoisonKunaiUnlocked = PlayerPrefs.GetInt("BestiaryPoisonKunaiUnlocked", 0) == 1;
        PlayerConfig.bestiaryTerremotoUnlocked = PlayerPrefs.GetInt("BestiaryTerremotoUnlocked", 0) == 1;
        PlayerConfig.bestiaryShieldThrowUnlocked = PlayerPrefs.GetInt("BestiaryShieldThrowUnlocked", 0) == 1;
        PlayerConfig.bestiaryCycloneUnlocked = PlayerPrefs.GetInt("BestiaryCycloneUnlocked", 0) == 1;
    }
}
