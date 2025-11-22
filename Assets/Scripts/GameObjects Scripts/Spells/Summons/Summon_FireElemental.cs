using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon_FireElemental : Summon
{
    protected override int SummonLevel => SpellsList.FireElemental.GetSpellLevel();

    protected override void Start()
    {
        base.Start();

        // Aqui nos inscrevemos para ouvir as magias do jogador
        var playerIgnisArrow = SpellsList.IgnisArrow;
        if (playerIgnisArrow != null)
            playerIgnisArrow.OnSpellCast += OnPlayerCastIgnisArrow;

        var playerFireball = SpellsList.Fireball;
        if (playerFireball != null)
            playerFireball.OnSpellCast += OnPlayerCastFireball;

        var playerMeteor = SpellsList.Meteor;
        if (playerMeteor != null)
            playerMeteor.OnSpellCast += OnPlayerCastMeteor;

        var playerExplosion = SpellsList.Explosao;
        if (playerExplosion != null)
            playerExplosion.OnSpellCast += OnPlayerCastExplosion;
    }

    private void OnDestroy()
    {
        var playerIgnisArrow = SpellsList.IgnisArrow;
        if (playerIgnisArrow != null)
            playerIgnisArrow.OnSpellCast -= OnPlayerCastIgnisArrow;

        var playerFireball = SpellsList.Fireball;
        if (playerFireball != null)
            playerFireball.OnSpellCast -= OnPlayerCastFireball;

        var playerMeteor = SpellsList.Meteor;
        if (playerMeteor != null)
            playerMeteor.OnSpellCast -= OnPlayerCastMeteor;

        var playerExplosion = SpellsList.Explosao;
        if (playerExplosion != null)
            playerExplosion.OnSpellCast -= OnPlayerCastExplosion;
    }

    private void OnPlayerCastIgnisArrow()
    {
        SpellsList.FireElemental_FagulhaDeFogo.Cast(this);
    }

    private void OnPlayerCastFireball()
    {
        SpellsList.FireElemental_FireBall.Cast(this);
    }

    private void OnPlayerCastMeteor()
    {
        SpellsList.FireElemental_Meteor.Cast(this);
    }

    private void OnPlayerCastExplosion()
    {
        SpellsList.FireElemental_Explosion.Cast(this);
    }

}
