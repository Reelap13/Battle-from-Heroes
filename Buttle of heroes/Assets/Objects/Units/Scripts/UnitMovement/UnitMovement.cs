using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class UnitMovement : MonoBehaviour
{
    public UnityEvent onBegginingOfMoving = new UnityEvent();
    public UnityEvent onEndOfMoving = new UnityEvent();

    [SerializeField] protected Unit _unit;
    [SerializeField] protected int _movement;

    protected Transform Transform => _unit.transform;

    /*public UnitMovement()
    {
        _unit.onBegginingOfMove.AddListener(ShowAvailableFieldForMoving);
        _unit.onEndOfMove.AddListener(HideAvailableFieldForMoving);
    }*/

    public abstract void ShowAvailableFieldForMoving();
    public abstract void HideAvailableFieldForMoving();
    public abstract void Move(Field targetField);
}