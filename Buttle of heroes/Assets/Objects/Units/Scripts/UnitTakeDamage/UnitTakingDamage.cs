using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitTakingDamage: MonoBehaviour
{
    public UnityEvent onDieing = new UnityEvent();
    public UnityEvent<float> onDamageTaken = new UnityEvent<float>();
    public UnityEvent<int> onUnitDeaded = new UnityEvent<int>();
    public UnityEvent<float> onHealthTaken= new UnityEvent<float>();

    [SerializeField] protected Unit _unit;
    [SerializeField] protected int _healthOfOneUnit;
    protected int NumberOfUnit => _unit.NumberOfUnits;

    protected float _health;

    private void Awake()
    {
        SetPreset();
    }

    public virtual void SetPreset()
    {
        void SetHealth() { _health = NumberOfUnit * _healthOfOneUnit; }
        _unit.onCreating.AddListener(SetHealth);
    }

    public virtual void TakeDamage(Damage damage)
    {
        TakeFinalDamage(damage.GetFinalDamage(), damage.Owner);
    }

    protected void TakeFinalDamage(float finalDamage, Unit damageDiller)
    {
        _health -= finalDamage;
        int numberOfDeadedUnits = Mathf.Min(NumberOfUnit - (int)Mathf.Ceil(_health / _healthOfOneUnit), NumberOfUnit);
        GameController.Instance.PlayerUI.ShowMessage($"{damageDiller.Name} dealt {(int)finalDamage} damage to {_unit.Name} " +
            $"and kill {numberOfDeadedUnits} units");
        if (_health <= 0)
        {
            _health = 0;
            onDieing.Invoke();
        }
        _unit.RemoveDeadUnit(numberOfDeadedUnits);

        onDamageTaken.Invoke(finalDamage);
        onUnitDeaded.Invoke(numberOfDeadedUnits);
    }
}
