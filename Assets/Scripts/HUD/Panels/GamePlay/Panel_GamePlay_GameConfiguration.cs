using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GamePlay_GameConfiguration : Panel
{
    [Header("====== Painel Pai ======")]
    public Panel_GamePlay_Pause Panel_Pause;

    [Header("====== Texts ======")]
    public Text TXT_GameOptions;
    public Text TXT_MusicVolume;
    public Text TXT_SoundEffectsVolume;
    public Text TXT_ChuvaVolume;
    public Text TXT_TrovaoVolume;
    public Text TXT_BtnBack;

    [Header("====== Sliders ======")]
    public Slider Slider_Musica;
    public Slider Slider_EfeitosSonoros;
    public Slider Slider_Chuva;
    public Slider Slider_Trovao;

    [Header("====== Buttons ======")]
    public Button BTN_Voltar;

    public override void Initialize(object param1 = null, object param2 = null, object param3 = null)
    {
        base.Initialize(param1, param2, param3);

        BTN_Voltar.onClick.AddListener(delegate { BTN_Voltar_Action(); });

        IniciaSlidersVolumes();
        SetaVolumes();

        TXT_GameOptions.text = LanguageManager.Get("Game Options");
        TXT_MusicVolume.text = LanguageManager.Get("Music Volume");
        TXT_SoundEffectsVolume.text = LanguageManager.Get("Sound Effect Volume");
        TXT_BtnBack.text = LanguageManager.Get("Back");
        TXT_ChuvaVolume.text = LanguageManager.Get("Sound Chuva Volume");
        TXT_TrovaoVolume.text = LanguageManager.Get("Sound Trovão Volume");
    }

    private void IniciaSlidersVolumes()
    {
        Slider_Musica.value = GameConfig.volumeMusica;
        Slider_EfeitosSonoros.value = GameConfig.volumeSoundEffects;
        Slider_Chuva.value = GameConfig.volumeChuva;
        Slider_Trovao.value = GameConfig.volumeTrovoes;
    }
    private void SetaVolumes()
    {
        GameConfig.volumeMusica = Slider_Musica.value;
        GameConfig.volumeSoundEffects = Slider_EfeitosSonoros.value;
        GameConfig.volumeChuva = Slider_Chuva.value;
        GameConfig.volumeTrovoes = Slider_Trovao.value;
    }
    public void BTN_Voltar_Action()
    {
        SaveManager.SaveGame();
        SaveManager.SalvaOpcoesResolucao();

        AudioManager.Instance.PlaySoundEffectButtons(1);

        OcultarPainel();
    }

}
