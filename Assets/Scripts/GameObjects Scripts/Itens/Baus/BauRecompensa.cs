using System.Collections;
using UnityEngine;

public class BauRecompensa : MonoBehaviour
{
    private const float SEGUNDOS_PARA_SEGUIR = 2f;

    private float movSpeed = 1f;
    [HideInInspector] public bool seguirPlayer;


    private void Start()
    { 
        // Começa seguir o jogador
        StartCoroutine(Prepare_SeguirJogador());
    }

    void Update()
    {
        SeguirJogador();
    }

    private IEnumerator Prepare_SeguirJogador()
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

    private void GiveChestToPlayer()
    {
        GameObject panelGO = PanelManager.Instance.GetPanel(Panel.PanelType.GAMEPLAY_MAININFO);
        Panel_GamePlay_MainInfo panelScript = panelGO.GetComponent<Panel_GamePlay_MainInfo>();
        panelScript.ReceberBau();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GiveChestToPlayer();
            Destroy(gameObject);
        }
    }
}
