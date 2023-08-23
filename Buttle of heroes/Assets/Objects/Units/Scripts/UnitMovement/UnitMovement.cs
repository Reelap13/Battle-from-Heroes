using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class UnitMovement
{
    public UnityEvent onBegginingOfMoving = new UnityEvent();
    public UnityEvent onEndOfMoving = new UnityEvent();

    protected Unit _unit;
    protected int _movement;
    protected int _initiative;
    protected Transform _transform;

    public UnitMovement(Unit unit, int movement, int initiative, Transform transform)
    {
        _unit = unit;
        _movement = movement;
        _initiative = initiative;
        _transform = transform;
        _unit.onBegginingOfMove.AddListener(ShowAvailableFieldForMoving);
        _unit.onEndOfMove.AddListener(HideAvailableFieldForMoving);
    }

    public abstract void ShowAvailableFieldForMoving();
    public abstract void HideAvailableFieldForMoving();
    public abstract void Move(Field targetField);
}
