using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public TextMeshProUGUI damage;
    public float destroyTime;

    void Start()
    {
        Destroy (gameObject, destroyTime);
    }

    public void ConfigureText(CombatResult result)
    {
        damage.text = result.finalDamage.ToString("F1");
        damage.color = SetTextColor(result);

        if (result.isCritical)
        {
            damage.text.ToUpper();
            damage.text = damage.text + "!!!";
            damage.color = Color.yellow;
            damage.fontSize = damage.fontSize * 1.2f;
        }
    }

    private Color SetTextColor(CombatResult result)
    {
        switch (result.element)
        {
            case Spell.Elemento.PHYSICAL:
                return Color.red;

            case Spell.Elemento.FIRE:
                return new Color(1f, 0.5f, 0f); // Laranja

            case Spell.Elemento.ICE:
                return Color.cyan;

            case Spell.Elemento.THUNDER:
                return Color.blue;

            case Spell.Elemento.POISON:
                return Color.green;

            default:
                return Color.red;
        }
    }
}
