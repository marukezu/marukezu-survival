using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // AudioSources - responsáveis por "tocar" as AudioClip
    public AudioSource soundEffectButtonsSource, soundEffectsOrbsEItensSource, soundEffectsPlayerDamagedSource, soundEffectsPlayerStepsSource;
    public AudioSource musicSource, chuvaSource, efeitosTrovaoSource;

    // CLipes de Audio.
    public AudioClip[] soundEffectsButtons, soundEffectsExpOrbsEItens, soundEffectsPlayerDamaged, soundEffectsPlayerSteps;
    public AudioClip[] musicTracks, chuvaSom, efeitosTrovao;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundEffectButtonsSource = gameObject.AddComponent<AudioSource>();
        soundEffectsOrbsEItensSource = gameObject.AddComponent<AudioSource>();
        soundEffectsPlayerDamagedSource = gameObject.AddComponent<AudioSource>();
        soundEffectsPlayerStepsSource = gameObject.GetComponent<AudioSource>();

        musicSource = gameObject.AddComponent<AudioSource>();
        chuvaSource = gameObject.AddComponent<AudioSource>();
        efeitosTrovaoSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        AtualizaVolumes();
    }

    // ===========================================================
    // ============= ATUALIZA VOLUMES EM TEMPO REAL ==============
    // ===========================================================
    private void AtualizaVolumes()
    {
        // Musicas.
        musicSource.volume = GameConfig.volumeMusica;

        // Chuva.
        chuvaSource.volume = GameConfig.volumeChuva;

        // Trovão.
        efeitosTrovaoSource.volume = GameConfig.volumeTrovoes;

        // Efeitos Sonoros.
        soundEffectButtonsSource.volume = GameConfig.volumeSoundEffects;
        soundEffectsOrbsEItensSource.volume = GameConfig.volumeSoundEffects;
        soundEffectsPlayerDamagedSource.volume = GameConfig.volumeSoundEffects;
        soundEffectsPlayerStepsSource.volume = GameConfig.volumeSoundEffects;

    }

    public float GetMusicVolume()
    {
        return GameConfig.volumeMusica;
    }
    public float GetSoundEffectVolume()
    {
        return GameConfig.volumeSoundEffects;
    }
    public float GetChuvaVolume()
    {
        return GameConfig.volumeChuva;
    }
    public float GetTrovaoVolume()
    {
        return GameConfig.volumeTrovoes;
    }

    // ===========================================================
    // ==================== PLAYER DA MÚSICA =====================
    // ===========================================================
    public void PlayMusic(int index)
    {
        if (index < 0 || index >= musicTracks.Length)
        {
            return;
        }

        musicSource.clip = musicTracks[index];
        musicSource.loop = true;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // ===========================================================
    // =============== CONTROLE DA CHUVA E TROVÃO ================
    // ===========================================================
    public void PlayChuva(int index)
    {
        if (index < 0 || index >= chuvaSom.Length)
        {
            return;
        }

        chuvaSource.clip = chuvaSom[index];
        chuvaSource.loop = true;
        chuvaSource.Play();
    }
    public void PlayTrovao(int index)
    {
        if (index < 0 || index >= efeitosTrovao.Length)
        {
            return;
        }

        efeitosTrovaoSource.clip = efeitosTrovao[index];
        efeitosTrovaoSource.Play();
    }
    public void StopChuva()
    {
        chuvaSource.Stop();
    }
    public void StopTrovao()
    {
        efeitosTrovaoSource.Stop();
    }

    // ===========================================================
    // ================ CONTROLE DE SOUND EFFECTS ================
    // ===========================================================
    
    // Efeitos de cliques aos botões.
    public void PlaySoundEffectButtons(int index)
    {
        if (index < 0 || index >= soundEffectsButtons.Length)
        {
            return;
        }

        soundEffectButtonsSource.clip = soundEffectsButtons[index];
        soundEffectButtonsSource.Play();
    }

    // Efeitos de Coleta de ExpOrbs e Itens.
    public void PlaySoundEffectOrbsItens(int index)
    {
        if (index < 0 || index >= soundEffectsExpOrbsEItens.Length)
        {
            return;
        }

        soundEffectsOrbsEItensSource.clip = soundEffectsExpOrbsEItens[index];
        soundEffectsOrbsEItensSource.Play();
    }

    // Efeitos de Recebimento de dano (Jogador).
    public void PlaySoundEffectPlayerDamaged(int index)
    {
        if (index < 0 || index >= soundEffectsPlayerDamaged.Length)
        {
            return;
        }

        soundEffectsPlayerDamagedSource.clip = soundEffectsPlayerDamaged[index];
        soundEffectsPlayerDamagedSource.Play();
    }

    // Efeitos de Passos do (Jogador).
    public void PlaySoundEffectPlayerSteps(int index)
    {
        if (index < 0 || index >= soundEffectsPlayerSteps.Length)
        {
            return;
        }

        soundEffectsPlayerStepsSource.clip = soundEffectsPlayerSteps[index];
        soundEffectsPlayerStepsSource.Play();
    }
}
