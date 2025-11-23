public static class GameConfig
{
    // ===========================================================================
    // ======================= Configuração do Programa ==========================
    // ===========================================================================
    public static LanguageManager.GameLanguage _gameIdioma = LanguageManager.GameLanguage.PTBR;
    public static bool _selecionouIdioma = false;
    public static string _gameVersion = "Early Preview Build";
    public static bool _androidMode = false;
    public static bool _debugMode = true;

    // Resolução
    public static bool _fullScreen = true;
    public static string _resolucaoXAtual = "1920", _resolucaoYAtual = "1080";

    // Audio
    public static float volumeMusica = 1f, volumeSoundEffects = 0.75f, volumeChuva = 1f, volumeTrovoes = 1f;
}
