using UnityEngine;


public class Hero_Inputs : MonoBehaviour
{
    private Hero_GameObject hero;

    private void Start()
    {
        hero = GetComponent<Hero_GameObject>();
    }

    private void Update()
    {
        AudioPlayerSteps();
    }

    public void Movimentacao(Vector2 heroDirection)
    {
        if (heroDirection.sqrMagnitude > 0.01f)
        {
            hero.heroRigidBody2D.velocity = heroDirection * HeroImage.GetHeroSpeed();
        }
        else
        {
            hero.heroRigidBody2D.velocity = Vector2.zero;
        }
    }

    private void AudioPlayerSteps()
    {
        if (!InputsManager.Instance.PodeControlar) return;

        Vector2 velocity = hero.heroRigidBody2D.velocity;

        if (velocity.sqrMagnitude > 0.1f) // movimento real
        {
            HeroImage.stepAudioDelay -= Time.deltaTime;
            if (HeroImage.stepAudioDelay <= 0)
            {
                AudioManager.Instance.PlaySoundEffectPlayerSteps(0);
                HeroImage.stepAudioDelay = 0.3f;
            }
        }
        else
        {
            HeroImage.stepAudioDelay = 0; // reinicia delay parado
        }
    }
}
