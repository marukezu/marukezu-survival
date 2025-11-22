using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortingSpriteOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int baseOrder = 1000; // evita valores negativos
    private float offsetY;        // opcional: útil se o pivô do sprite não é no pé

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null )
            spriteRenderer = GetComponentsInChildren<SpriteRenderer>(true)
    .FirstOrDefault(s => s.gameObject.name == "sprite enemy");

        offsetY = transform.position.y;
    }

    private void LateUpdate()
    {
        // Quanto mais alto (Y maior), menor a order in layer
        spriteRenderer.sortingOrder = baseOrder - Mathf.RoundToInt((transform.position.y - offsetY) * 100);
    }
}
