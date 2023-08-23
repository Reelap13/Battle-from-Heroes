using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack
{
    protected Unit _unit;
    public UnitAttack(Unit unit)
    {
        _unit = unit;
        _unit.onBegginingOfMove.AddListener(ShowAvailableUnitForAttacking);
        _unit.onEndOfMove.AddListener(HideAvailableUnitForAttacking);
    }

    public abstract void ShowAvailableUnitForAttacking();
    public abstract void HideAvailableUnitForAttacking();
    public abstract void Attack(Unit unti);
}
