using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitTakingDamage
{
    public UnityEvent onDieing = new UnityEvent();
    public UnityEvent<float> onDamageTaken = new UnityEvent<float>();
    public UnityEvent<float> onHealthTaken = new UnityEvent<float>();

    protected int _healthOfOneUnit;

    protected float _health;
    protected Unit _unit;

    public UnitTakingDamage(Unit unit, int healthOfOneUnit)
    {
        _unit = unit;
        _healthOfOneUnit = healthOfOneUnit;
        _health = healthOfOneUnit * unit.NumberOfUnits;
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
            onDieing.Invoke();
        }
    }
}
