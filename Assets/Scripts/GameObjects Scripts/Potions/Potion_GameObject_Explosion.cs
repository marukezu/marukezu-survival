using UnityEngine;

public class Potion_GameObject_Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    protected virtual void ColisaoComTarget(Collider2D collisor)
    {
        Combat.DoPotionCombat(PotionsList.Potion_Explosion, collisor.gameObject.GetComponent<Enemy_GameObject>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ColisaoComTarget(collision);
        }
    }
}
