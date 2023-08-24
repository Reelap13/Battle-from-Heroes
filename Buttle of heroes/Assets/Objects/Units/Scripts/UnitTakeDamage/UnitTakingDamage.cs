using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitTakingDamage: MonoBehaviour
{
    public UnityEvent onDieing = new UnityEvent();
    public UnityEvent<float> onDamageTaken = new UnityEvent<float>();
    public UnityEvent<float> onHealthTaken= new UnityEvent<float>();

    [SerializeField] protected Unit _unit;
    [SerializeField] protected int _healthOfOneUnit;
    protected int NumberOfUnit => _unit.NumberOfUnits;

    protected float _health;

    private void Awake()
    {
        void SetPreset() { _health = NumberOfUnit * _healthOfOneUnit; }
        _unit.onCreating.AddListener(SetPreset);
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
