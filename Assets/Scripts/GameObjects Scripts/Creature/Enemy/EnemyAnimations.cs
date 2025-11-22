using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyAnimations
{
    Enemy_GameObject enemy;

    // Controle de efeito de cores do inimigo.
    [HideInInspector] public Color _corOriginal;

    public EnemyAnimations(Enemy_GameObject enemy)
    {
        this.enemy = enemy;

        _corOriginal = enemy._enemySpriteRenderer.material.color;
    }

    public void AtualizarSpriteFlip()
    {
        enemy._enemySpriteRenderer.flipX = (enemy.direcao.x >= 0) ? false : true;
    }

    public void AtualizarCorSprite()
    {
        if (enemy.conditions.isFrozen)
            enemy._enemySpriteRenderer.material.color = Color.cyan;
        else if (enemy.conditions.isBurning)
            enemy._enemySpriteRenderer.material.color = new Color(1f, 0.5f, 0f);
        else if(enemy.conditions.isPoisoned)
            enemy._enemySpriteRenderer.material.color = Color.green;
        else
            enemy._enemySpriteRenderer.material.color = _corOriginal;
    }
    public IEnumerator AtivaAnimacaoDano(Color color)
    {
        enemy._enemySpriteRenderer.material.color = color;

        yield return new WaitForSeconds(0.2f);

        enemy._enemySpriteRenderer.material.color = _corOriginal;
    }

    public void DamageText(float value, Color textColor)
    {
        // Instancia o texto de dano
        var damage = Object.Instantiate(PrefabManager.Instance.damageText, enemy.transform.position, Quaternion.identity);
        damage.SendMessage("SetText", value.ToString("F0"));
        damage.SendMessage("SetTextColor", textColor);
    }

}
