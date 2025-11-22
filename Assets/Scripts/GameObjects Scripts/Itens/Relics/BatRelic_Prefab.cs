using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatRelic_Prefab : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AtivaReliquia();
            UnlockBestiary();
            Destroy(gameObject);
        }
    }

    private void AtivaReliquia()
    {
        PlayerConfig.BatRelicAdquired = 1;
    }
    private void UnlockBestiary()
    {
        if (!PlayerConfig.bestiaryBatRelicUnlocked)
        {
            PlayerConfig.bestiaryBatRelicUnlocked = true;
        }
    }
}
