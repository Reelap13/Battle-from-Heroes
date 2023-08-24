using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class Field : MonoBehaviour
{
    [SerializeField] private int _movementCost;

    public UnityEvent<Unit> onEnter = new UnityEvent<Unit>();
    public UnityEvent<Unit> onLeave = new UnityEvent<Unit>();

    private KeyValuePair<int, int> _indexes;
    private Unit _unit = null;
    private FieldTypes _fieldTypes = FieldTypes.COMMON;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = FieldTypesMethods.GetColorByType(_fieldTypes);
    }

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

    public Unit Unit { get { return _unit; } }
    public bool IsFree { get { return _unit == null; } }
    public int MovementCost { get { return _movementCost; } }
    public KeyValuePair<int, int> Indexes { get { return _indexes; } }
    public FieldTypes FieldType
    {
        get { return _fieldTypes; }
        set
        {
            if (value == FieldTypes.ATTACKED || _fieldTypes == FieldTypes.ATTACKED)
                Debug.Log(_fieldTypes + " " + value);
            _fieldTypes = value;
            _spriteRenderer.color = FieldTypesMethods.GetColorByType(value);
        }
    }
}
