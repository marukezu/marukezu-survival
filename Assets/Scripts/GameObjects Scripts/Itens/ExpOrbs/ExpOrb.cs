using System.Collections;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    private const float SEGUNDOS_PARA_SEGUIR = 2f;

    private float movSpeed = 1f;
    [HideInInspector] public bool seguirPlayer;
    public int _expAdquired;

    private void OnDestroy()
    {
        // Se remove da lista ao ser deletada.
        GameManager.Instance.OrbsInScene.Remove(gameObject);
    }

    private void Awake()
    {
        // Adiciona esse Orb a lista de Orbs em jogo.
        GameManager.Instance.OrbsInScene.Add(gameObject);
    }

    private void Start()
    {

        StartCoroutine(IniciarExpOrb());
    }

    void Update()
    {
        SeguirJogador();
    }

    private IEnumerator IniciarExpOrb()
    {
        yield return new WaitForSeconds(SEGUNDOS_PARA_SEGUIR);

        seguirPlayer = true;
    }

    private void SeguirJogador()
    {
        GameObject player = GameManager.Instance.playerHero.gameObject;

        if (player != null && seguirPlayer)
        {
            Vector2 posicaoAlvo = player.transform.position;
            Vector2 posicaoAtual = transform.position;
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;
            GetComponent<Rigidbody2D>().velocity = (movSpeed * direcao);

            movSpeed += Time.deltaTime;
        }
    }

    private void AdicionarExpAoJogador()
    {
        HeroImage.playerExpTotal += _expAdquired;
        HeroImage.playerExpAtual += _expAdquired;

        if (HeroImage.playerExpAtual > HeroImage.GetExpNextLevel())
            HeroImage.UpLevel();
    }

    private void PlaySoundEffect()
    {
        AudioManager.Instance.PlaySoundEffectOrbsItens(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OrbAttractor"))
        {
            seguirPlayer = true;
        }

        if (collision.CompareTag("Player"))
        {
            PlaySoundEffect();
            AdicionarExpAoJogador();
            Destroy(gameObject);
        }
    }

}
