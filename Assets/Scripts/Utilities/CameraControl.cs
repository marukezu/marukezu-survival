using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject _jogador; // Referência ao jogador
    public float suavidade = 5f; // Quão suavemente a câmera segue o jogador

    void Start()
    {
        IniciaValores();
    }

    void LateUpdate()
    {
        if (_jogador != null)
        {
            // Calcula a nova posição da câmera
            Vector3 novaPosicao = new Vector3(_jogador.transform.position.x, _jogador.transform.position.y, transform.position.z);

            // Move suavemente a câmera em direção à nova posição
            transform.position = Vector3.Lerp(transform.position, novaPosicao, suavidade * Time.deltaTime);
        }
    }

    private void IniciaValores()
    {
        _jogador = GameObject.FindWithTag("Player");
    }

}
