using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingoDeChuva : MonoBehaviour
{
    public float tempoDeVida;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
