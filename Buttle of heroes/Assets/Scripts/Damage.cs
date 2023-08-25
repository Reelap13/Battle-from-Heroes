using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    private readonly Unit _owner;
    private readonly float _damage;
    private float _additionalDamage;

    public Damage(Unit owner, float damage)
    {
        _owner = owner;
        _damage = damage;
        _additionalDamage = 0;
    }

    public void IncreseDamage(float multiplier)
    {
        _additionalDamage += multiplier * _damage;
    }

    public void ReduceDamage(float multiplier)
    {
        _additionalDamage -= multiplier * _damage;
    }

    public float GetFinalDamage()
    {
        float resultDamage = _additionalDamage + _damage;
        return resultDamage >= 0 ? resultDamage : 0;
    }

    public Unit Owner { get { return _owner; } }
}
