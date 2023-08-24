using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Field : MonoBehaviour
{
    [SerializeField] private int _movementCost;

    public UnityEvent<Unit> onEnter = new UnityEvent<Unit>();
    public UnityEvent<Unit> onLeave = new UnityEvent<Unit>();

    private KeyValuePair<int, int> _indexes;
    private Unit _unit = null;

    public void setPreset(KeyValuePair<int, int> indexes) { _indexes = indexes; }

    private void OnMouseDown()
    {
        Debug.Log(Indexes);
    }

    public void Enter(Unit unit)
    {
        _unit = unit;
        onEnter.Invoke(unit);
    }

    public void Leave()
    {
        onLeave.Invoke(_unit);
        _unit = null;
    }

    public Unit Pack { get { return _unit; } }
    public bool IsFree { get { return _unit == null; } }
    public int MovementCost { get { return _movementCost; } }
    public KeyValuePair<int, int> Indexes { get { return _indexes; } }
}
