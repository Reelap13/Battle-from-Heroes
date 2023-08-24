using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour
{
    [SerializeField] protected Unit _unit;

    protected int NumberOfUnit => _unit.NumberOfUnits;
    protected Field Field => _unit.Field;

    private void Awake()
    {
        _unit.onBegginingOfMove.AddListener(ShowAvailableUnitForAttacking);
        _unit.onEndOfMove.AddListener(HideAvailableUnitForAttacking);
    }

    public abstract void Attack(Unit unti);
    public abstract void ShowAvailableUnitForAttacking();
    public abstract void HideAvailableUnitForAttacking();
}
