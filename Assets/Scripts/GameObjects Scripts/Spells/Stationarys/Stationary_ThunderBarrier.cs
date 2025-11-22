using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_ThunderBarrier : Stationary
{
    protected override void Update()
    {
        base.Update();

        Hero_GameObject hero = GameManager.Instance.playerHero;

        if (hero != null)
        {
            transform.position = hero.transform.position;
        }
    }

    private void Start()
    {
        duracao = spell.BaseDmg;
        selfTarget = true;

        Destroy(gameObject, duracao);
    }
}
