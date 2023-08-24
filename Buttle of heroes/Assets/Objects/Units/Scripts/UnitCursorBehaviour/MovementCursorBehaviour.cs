using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCursorBehaviour : CursorBehaviour
{
    [SerializeField] private Sprite _cursor;
    public override void Enable()
    {
        Cursor.SetCursor(_cursor);
    }
    public override void Click()
    {
        Unit.MoveToField(Field);
        GameController.Instance.PlayersMoves.FinishMove();
    }
}
