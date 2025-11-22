using System.Collections.Generic;
using UnityEngine;

public class Projectile_Shuriken : Projectile
{
    // Static lista de todas as shurikens orbitando o mesmo caster
    public static Dictionary<Creature, List<Projectile_Shuriken>> shurikenOrbiters = new Dictionary<Creature, List<Projectile_Shuriken>>();

    private float orbitRadius = 2f;
    private float orbitSpeed = 90f; // graus por segundo
    private float angleOffset;      // ângulo específico dessa shuriken na órbita
    private Creature caster;

    public override void InitializeProjectile(Spell spell, Creature target = null)
    {
        base.InitializeProjectile(spell, target);

        // No caso da shuriken, o target será o próprio caster
        caster = this.spell.Caster;

        // Adiciona na lista de shurikens do caster
        if (!shurikenOrbiters.ContainsKey(caster))
            shurikenOrbiters[caster] = new List<Projectile_Shuriken>();

        shurikenOrbiters[caster].Add(this);

        RecalculateAngles();
    }

    private void RecalculateAngles()
    {
        List<Projectile_Shuriken> list = shurikenOrbiters[caster];
        int count = list.Count;

        for (int i = 0; i < count; i++)
        {
            list[i].angleOffset = 360f / count * i;
        }
    }

    protected override void Update()
    {
        if (caster == null) return;

        // Calcula o ângulo atual da órbita
        float orbitAngle = angleOffset + orbitSpeed * Time.time;

        float rad = orbitAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;
        transform.position = caster.transform.position + offset;
    }

    private void OnDestroy()
    {
        // Remove da lista e recalcula os ângulos restantes
        if (caster != null && shurikenOrbiters.ContainsKey(caster))
        {
            shurikenOrbiters[caster].Remove(this);
            if (shurikenOrbiters[caster].Count > 0)
            {
                foreach (var s in shurikenOrbiters[caster])
                    s.RecalculateAngles();
            }
        }
    }
}
