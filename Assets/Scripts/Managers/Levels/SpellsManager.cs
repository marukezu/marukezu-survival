using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsManager : MonoBehaviour
{
    public static SpellsManager Instance;

    // Configurações
    [HideInInspector] public List<Creature> inimigosNoRaio = new List<Creature>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        StartCoroutine(VerificaInimigosNoRaio());
    }

    void Update()
    {
        CastSpells();
    }

    private void CastSpells()
    {
        Creature player = GameManager.Instance.playerHero;

        // Active 1
        if (HeroImage.active1 != null)
        {
            HeroImage.active1.DoCooldown();
            if (HeroImage.active1.isReady && inimigosNoRaio.Count > 0)
                HeroImage.active1.Cast(player);
        }

        // Active 2
        if (HeroImage.active2 != null)
        {
            HeroImage.active2.DoCooldown();
            if (HeroImage.active2.isReady && inimigosNoRaio.Count > 0)
                HeroImage.active2.Cast(player);
        }

        // Active 3

        if (HeroImage.active3 != null)
        {
            HeroImage.active3.DoCooldown();
            if (HeroImage.active3.isReady && inimigosNoRaio.Count > 0)
                HeroImage.active3.Cast(player);
        }        

        // Active 4
        if (HeroImage.active4 != null)
        {
            HeroImage.active4.DoCooldown();
            if (HeroImage.active4.isReady && inimigosNoRaio.Count > 0)
                HeroImage.active4.Cast(player);
        }

        // Active 5
        if (HeroImage.active5 != null)
        {
            HeroImage.active5.DoCooldown();
            if (HeroImage.active5.isReady && inimigosNoRaio.Count > 0)
                HeroImage.active5.Cast(player);
        }        
    }

    private IEnumerator VerificaInimigosNoRaio()
    {
        while (HeroImage.healthNow > 0)
        {
            inimigosNoRaio.Clear();

            // Verificar colisões usando OverlapCircleAll
            Collider2D[] colisores = Physics2D.OverlapCircleAll(GameManager.Instance.playerHero.transform.position, 5f);

            foreach (Collider2D colisor in colisores)
            {
                if (colisor.CompareTag("Enemy"))
                {
                    inimigosNoRaio.Add(colisor.GetComponent<Creature>());
                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    public Creature GetClosestTarget(Creature target)
    {
        Creature inimigoMaisProximo = null;
        float distanciaMaisProxima = Mathf.Infinity;

        foreach (Creature inimigo in inimigosNoRaio)
        {
            float distanciaAtual = Vector2.Distance(GameManager.Instance.playerHero.transform.position, inimigo.transform.position);

            if (distanciaAtual < distanciaMaisProxima && !inimigo.isDead)
            {
                distanciaMaisProxima = distanciaAtual;
                inimigoMaisProximo = inimigo;
            }
        }

        return inimigoMaisProximo;
    }

    public Creature GetRandomTarget(Creature target)
    {
        // Cria uma lista filtrada com alvos diferentes do target atual
        List<Creature> validTargets = new List<Creature>();

        foreach (Creature inimigo in inimigosNoRaio)
        {
            if (inimigo != null && inimigo != target && !inimigo.isDead)
            {
                validTargets.Add(inimigo);
            }
        }

        // Se houver pelo menos um alvo válido, sorteia
        if (validTargets.Count > 0)
        {
            Creature targetSorteado = validTargets[UnityEngine.Random.Range(0, validTargets.Count)];
            target = targetSorteado;

            return targetSorteado;
        }

        return null;
    }

    // Repete as spells (Por ex: a spell está level 2, ela invoca 2x).
    public IEnumerator SpellRepeater(Action callback, float delay, int repeatCount, float interval)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < repeatCount; i++)
        {
            callback?.Invoke();
            if (i < repeatCount - 1)
                yield return new WaitForSeconds(interval);
        }
    }
}
