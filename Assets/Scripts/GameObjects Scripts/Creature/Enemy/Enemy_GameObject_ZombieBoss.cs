using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GameObject_ZombieBoss : Enemy_GameObject
{
    private const int SUMMON_QUANTITY = 10;
    private const float SUMMON_INTERVAL = 12f;

    // Interval Summon
    private float summonCooldown = 5f;

    // Bools Summon
    private bool canSummon => summonCooldown <= 0;
    private bool isSummoning = false;

    protected override void Update()
    {
        base.Update();

        summonCooldown -= Time.deltaTime;
    }

    protected override void EnemyBehaviour()
    {
        if (canSummon && !isSummoning)
        {
            StartCoroutine(SummonZombies());
        }
        else if(!canSummon && !isSummoning)
        {
            SeguirJogador();
        }
    }

    private IEnumerator SummonZombies()
    {
        isSummoning = true;

        // Para o zumbi
        direcao = Vector2.zero;
        _enemyRigidbody.velocity = Vector2.zero;    

        // Ativa Animação
        Animator animator = GetComponent<Animator>();
        animator.SetBool("Summoning", true);

        float radius = 5f;

        for (int i = 0; i < 10; i++)
        {
            // Gera uma posição aleatória dentro de um círculo de raio 5 ao redor do transform
            Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * radius;

            // Spawna um zumbi summon.
            SpawnController.Instance.SpawnEnemyInPosition(SpawnController.Creatures.ZombieBossSummon, monster.Nivel / 10, randomPos);

            // Aguarda 0.25s antes de sumonar novamente
            yield return new WaitForSeconds(0.25f);
        }

        animator.SetBool("Summoning", false);
        summonCooldown = SUMMON_INTERVAL;
        isSummoning = false;
    }
}
