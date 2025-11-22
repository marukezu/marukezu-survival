using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Relics : MonoBehaviour
{
    private Hero_GameObject hero;

    // Dados da Relíquia Esqueleto.
    private Color color_Invuneravel;
    private float reliquiaSkeletonCooldown, reliquiaSkeletonDuracao;
    [HideInInspector] public bool isRelic_SkeletonActive;

    // Dados da Relíquia Morcego.
    private float reliquiaBatCooldown, reliquiaBatDuracao;
    [HideInInspector] public bool isRelic_BatActive;

    private void Start()
    {
        hero = GetComponent<Hero_GameObject>();
        IniciaValoresReliquias();
    }

    private void Update()
    {
        AtualizaReliquiaSkeleton();
        AtualizaReliquiaBat();
    }

    private void IniciaValoresReliquias()
    {
        color_Invuneravel = hero.heroOriginalColor;
        color_Invuneravel.a = 0.25f;

        // Skeleton Relic
        reliquiaSkeletonCooldown = 1f;
        reliquiaSkeletonDuracao = RelicList.SkeletonRelic.GetRelicDuracaoEfeito();

        // Bat Relic
        reliquiaBatCooldown = 1f;
        reliquiaBatDuracao = RelicList.BatRelic.GetRelicDuracaoEfeito();
    }
    private void AtualizaReliquiaSkeleton()
    {
        // Se o jogador já desbloqueou essa relíquia.
        if (PlayerConfig.SkeletonRelicAdquired == 1)
        {
            reliquiaSkeletonCooldown -= Time.deltaTime;
            if (reliquiaSkeletonCooldown <= 0)
            {
                isRelic_SkeletonActive = true;
                reliquiaSkeletonDuracao -= Time.deltaTime;

                GetComponent<SpriteRenderer>().material.color = color_Invuneravel;

                if (reliquiaSkeletonDuracao <= 0)
                {
                    GetComponent<SpriteRenderer>().material.color = hero.heroOriginalColor;
                    reliquiaSkeletonCooldown = RelicList.SkeletonRelic.Cooldown;
                    reliquiaSkeletonDuracao = RelicList.SkeletonRelic.GetRelicDuracaoEfeito();
                    isRelic_SkeletonActive = false;
                }
            }
        }
    }
    private void AtualizaReliquiaBat()
    {
        // Se o jogador já desbloqueou essa relíquia.
        if (PlayerConfig.BatRelicAdquired == 1)
        {
            reliquiaBatCooldown -= Time.deltaTime;
            if (reliquiaBatCooldown <= 0)
            {
                isRelic_BatActive = true;
                reliquiaBatCooldown = RelicList.BatRelic.Cooldown;
                StartCoroutine(ReliquiaBatCoroutine());
            }
        }
    }
    private IEnumerator ReliquiaBatCoroutine() // Heal over Time
    {
        while (reliquiaBatDuracao > 0)
        {
            ReliquiaBatHeal();
            reliquiaBatDuracao -= 0.5f;
            yield return new WaitForSeconds(0.5f);
        }
        isRelic_BatActive = false;
        reliquiaBatDuracao = RelicList.BatRelic.GetRelicDuracaoEfeito();
    }
    private void ReliquiaBatHeal()
    {
        Debug.Log("Reliquia curando");
        HeroImage.AddHealthNow(2f);
        PrefabManager.Instance.InstantiateEffectPrefab(PrefabManager_Effects.EffectType.Heal, transform);
    }
}
