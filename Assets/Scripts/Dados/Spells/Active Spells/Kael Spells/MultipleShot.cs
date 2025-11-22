using UnityEngine;

public class MultipleShot : Spell
{
    public MultipleShot() : base()
    {
        TypeSpell = SpellType.ACTIVE_MULTIPLESHOT;
        SpellElement = Elemento.DISTANCE;
        TypeTarget = TargetType.MULTIPLE;
        TypeCombat = CombatType.DAMAGE;
        SpriteIcon = SpritesManager.Instance.spellSprites.Spell_MultipleShot;
        Name = LanguageManager.Get("Multiple Shot Name");
        Descricao = LanguageManager.Get("Multiple Shot Description");
        BaseDmg = 90;
        DamagePercentPerLevel = 5;
        BaseCooldown = 3f;
        PoderImpulsao = 0.1f;
        LevelMax = 999;
        MaxRecasts = 8;
    }

    public override void Cast(Creature caster)
    {
        // Armazena o Caster.
        Caster = caster;

        int timesToCast = CalculateTimesToCast();
        float interval = 0.25f;

        Caster.StartCoroutine(SpellsManager.Instance.SpellRepeater(CastSpell, 0f, timesToCast, interval));

        RealCooldown = GetSpellCooldown();
    }

    private void CastSpell()
    {
        Vector3 casterPos = Caster.transform.position;
        Creature target = SpellsManager.Instance.GetRandomTarget(Caster);

        if (target == null)
            return;

        // Direção base (central) do caster para o alvo
        Vector2 dirToTarget = target.transform.position - casterPos;
        float centralAngle = Mathf.Atan2(dirToTarget.y, dirToTarget.x) * Mathf.Rad2Deg;

        // Offsets de angulação para formar o arco
        float[] offsets = { -20f, -10f, 0f, 10f, 20f };

        for (int i = 0; i < offsets.Length; i++)
        {
            float angle = centralAngle + offsets[i];

            GameObject arrowGO = PrefabManager.Instance.InstantiateSpellPrefab(
                PrefabManager_Spells.SpellType.MultipleShot,
                Caster.transform
            );

            Projectile_MultipleShot arrowScript = arrowGO.GetComponent<Projectile_MultipleShot>();
            arrowScript.InitializeProjectile(this, casterPos, angle);
        }
    }
}
