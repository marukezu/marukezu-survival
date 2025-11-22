using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Animation : MonoBehaviour
{
    private Hero_GameObject hero;

    private void Start()
    {
        hero = GetComponent<Hero_GameObject>();
    }

    private void Update()
    {
        WalkingAnimation();
        DeathAnimation();
    }

    private void WalkingAnimation()
    {
        if (!InputsManager.Instance.PodeControlar)
            return;

        Vector2 velocity = hero.heroRigidBody2D.velocity;

        // Define se está andando
        bool isWalking = velocity.sqrMagnitude > 0.01f;
        hero.heroAnimator.SetBool("Walking", isWalking);

        // Define a direção do sprite apenas se estiver se movendo
        if (Mathf.Abs(velocity.x) > 0.01f)
            hero.heroSpriteRenderer.flipX = velocity.x < 0;
    }

    private void DeathAnimation()
    {
        if (HeroImage.healthNow <= 0)
        {
            GetComponent<Animator>().SetBool("Death", true);
        }
    }
}
