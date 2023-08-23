using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    private readonly float _damage;
    private float _additionalDamage;

    public Damage(float damage)
    {
        _damage = damage;
    }

    public void IncreseDamage(float multiplier)
    {
        _additionalDamage += multiplier * _damage;
    }

    public void ReduceDamage(float multiplier)
    {
        _additionalDamage -= multiplier * _damage;
    }

    public float TakeDamage()
    {
        float resultDamage = _additionalDamage + _damage;
        return resultDamage >= 0 ? resultDamage : 0;
    }
}
