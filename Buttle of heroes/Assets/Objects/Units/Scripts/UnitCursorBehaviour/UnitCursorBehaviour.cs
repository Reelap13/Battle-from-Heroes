using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class UnitCursorBehaviour : MonoBehaviour
{
    [field: SerializeField]
    public Unit Unit { get; private set; }
    [SerializeField] private CursorBehaviour _movement;
    [SerializeField] private CursorBehaviour _attack;

    private MouseCursorController _mouseCursorController;
    private Field _field;
    private CursorBehaviour _activeCursorBehaviour;

    private void Awake()
    {
        Unit.onBegginingOfMove.AddListener(Enable);
        Unit.onEndOfMove.AddListener(Disable);
    }

    public void SetField(Field field)
    {
        _field = field;
        switch (_field.FieldType)
        {
            case FieldTypes.MOVEMENT:
                ActivateCursorBehaviour(_movement);
                break;
            case FieldTypes.ATTACKED:
                ActivateCursorBehaviour(_attack);
                break;
            default:
                DisactivateCursorBehaviour();
                break;
        }
    }
    public void Enable()
    {
        _mouseCursorController = GameController.Instance.Cursor;
        _mouseCursorController.onEnterToField.AddListener(SetField);
        _mouseCursorController.onClickToField.AddListener(Click);
        _mouseCursorController.onLeaveFromField.AddListener(SetField);
    }

    public void Disable()
    {
        DisactivateCursorBehaviour();
        _mouseCursorController.onEnterToField.RemoveListener(SetField);
        _mouseCursorController.onClickToField.RemoveListener(Click);
        _mouseCursorController.onLeaveFromField.RemoveListener(SetField);
    }

    public void Click(Field field)
    {
        SetField(field);
        if (_activeCursorBehaviour != null) { _activeCursorBehaviour.Click(); }
    }

    private void ActivateCursorBehaviour(CursorBehaviour cursorBehaviour)
    {
        DisactivateCursorBehaviour();
        _activeCursorBehaviour = cursorBehaviour;
        _activeCursorBehaviour.Enable();
    }

    private void DisactivateCursorBehaviour()
    {
        if (_activeCursorBehaviour != null)
        {
            _activeCursorBehaviour.Disable();
            _activeCursorBehaviour = null;
        }
    }
    public MouseCursorController Cursor { get { return _mouseCursorController; } }
    public Field Field { get { return _field; } }
}
