using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SkeletonRelic_Prefab : MonoBehaviour
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
        PlayerConfig.SkeletonRelicAdquired = 1;
    }
    private void UnlockBestiary()
    {
        if (!PlayerConfig.bestiarySkeletonRelicUnlocked)
        {
            PlayerConfig.bestiarySkeletonRelicUnlocked = true;
        }
    }
}
