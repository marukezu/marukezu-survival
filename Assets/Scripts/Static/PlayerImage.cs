using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Essa classe representa os itens, utilizáveis, conquistas do player NA PARTIDA ATUAL.
// Classe usada DURANTE a gameplay.

public static class PlayerImage
{
    // Dados Monetários
    public static int moneyFeito { get; set; } = 0;
    public static int bausRecebidos { get; set; } = 0;

    // Dados de Inimigos
    public static int inimigosDerrotados { get; set; } = 0;

    public static void ResetPlayerImage()
    {
        // Dados Monetários
        moneyFeito = 0;
        bausRecebidos = 0;

        // Dados de Inimigos
        inimigosDerrotados = 0;
    }
}
