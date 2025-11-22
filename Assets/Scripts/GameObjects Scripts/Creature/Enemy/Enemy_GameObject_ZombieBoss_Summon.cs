using System.Collections;
using UnityEngine;

public class Enemy_GameObject_ZombieBoss_Summon : Enemy_GameObject
{
    // Delay inicial antes de começar a se mover
    private float startTime = 3f;
    private bool hasStarted => startTime <= 0f;
    private bool iniciouMovimento = false;

    protected override void Update()
    {
        base.Update();
        startTime -= Time.deltaTime;
    }

    protected override void EnemyBehaviour()
    {
        if (!hasStarted)
            return;

        if (!iniciouMovimento)
        {
            // Calcula a direção apenas uma vez no início
            Vector2 posJogador2D = _jogadorGameObject.transform.position;
            direcao = (posJogador2D - _enemyRigidbody.position).normalized;

            iniciouMovimento = true;

            StartCoroutine(DestruirAposDelay(10f));
        }

        IrEmDirecaoReta();
    }

    private void IrEmDirecaoReta()
    {
        // Move sempre na direção fixa
        _enemyRigidbody.velocity = direcao * monster.Speed;
    }


    private IEnumerator DestruirAposDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        _enemyRigidbody.velocity = Vector2.zero;
        GetComponent<Animator>().SetBool("Death", true);

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

}
