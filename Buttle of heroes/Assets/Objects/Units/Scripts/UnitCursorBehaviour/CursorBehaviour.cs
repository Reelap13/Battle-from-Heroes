using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CursorBehaviour : MonoBehaviour
{
    [SerializeField] protected UnitCursorBehaviour _unitCursorBehaviour;

    protected MouseCursorController Cursor => _unitCursorBehaviour.Cursor;
    protected Field Field => _unitCursorBehaviour.Field;
    protected Unit Unit => _unitCursorBehaviour.Unit;
    public virtual void Enable() { }

    public virtual void Disable() { Cursor.SetDefaultCursor(); }

    public abstract void Click();
}
