using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public Text damage;
    public float destroyTime;

    void Start()
    {
        Destroy (gameObject, destroyTime);
    }

    public void SetText(string value)
    {
        damage.text = value;
    }

    public void SetTextColor(Color value)
    {
        damage.color = value;
    }
}
