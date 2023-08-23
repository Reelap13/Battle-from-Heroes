using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit
{
    public UnityEvent onBegginingOfMove = new UnityEvent();
    public UnityEvent onEndOfMove = new UnityEvent();

    private string _name;
    public int NumberOfUnits { get; set; }
    public UnitAttack Attack { get; set; }
    public UnitTakingDamage TakeDamage { get; set; }
    public UnitMovement Movement { get; set; }

    public Unit(string name, int numberOfUnits)
    {
        _name = name;
        NumberOfUnits = numberOfUnits;
    }

    public void StartUnitMove()
    {
        onBegginingOfMove.Invoke();
    }

    public void FinishUnitMove()
    {
        onEndOfMove.Invoke();
    }
}
