using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPingosChuva : MonoBehaviour
{
    public GameObject prefabPingoDeChuva;
    public float intervaloDeSpawn = 1f;
    public Camera cameraPrincipal;

    private float tempoDesdeUltimoSpawn = 0f;

    private void Update()
    {
        // Atualize o temporizador
        tempoDesdeUltimoSpawn += Time.deltaTime;

        // Verifique se é hora de criar um novo pingo de chuva
        if (tempoDesdeUltimoSpawn >= intervaloDeSpawn)
        {
            // Instancie o pingo de chuva em uma posição aleatória dentro da visão da câmera
            InstanciarPingoDeChuva();

            // Reinicie o temporizador
            tempoDesdeUltimoSpawn = 0f;
        }
    }

    private void InstanciarPingoDeChuva()
    {
        // Obtenha a posição atual da câmera
        Vector3 posicaoCamera = cameraPrincipal.transform.position;

        // Calcule uma posição aleatória dentro da visão da câmera
        Vector3 posicaoAleatoria = new Vector3(
            posicaoCamera.x + Random.Range(-cameraPrincipal.orthographicSize * cameraPrincipal.aspect, cameraPrincipal.orthographicSize * cameraPrincipal.aspect),
            posicaoCamera.y + Random.Range(-cameraPrincipal.orthographicSize, cameraPrincipal.orthographicSize), 0f
        );

        // Instancie o pingo de chuva na posição aleatória
        Instantiate(prefabPingoDeChuva, posicaoAleatoria, Quaternion.identity);
    }
}
