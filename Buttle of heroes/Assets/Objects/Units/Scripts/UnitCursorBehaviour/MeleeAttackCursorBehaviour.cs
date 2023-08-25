using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeAttackCursorBehaviour : CursorBehaviour
{
    [SerializeField] private Sprite _right;
    [SerializeField] private Sprite _rightUp;
    [SerializeField] private Sprite _leftUp;
    [SerializeField] private Sprite _left;
    [SerializeField] private Sprite _leftDown;
    [SerializeField] private Sprite _rightDown;

    private bool _isEnable = false;
    private float _angle;

    public override void Enable()
    {
        _isEnable = true;
    }

    public override void Disable()
    {
        _isEnable = false;
    }

    private void FixedUpdate()
    {
        if (!_isEnable) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fieldPosition = Field.Transform.position;
        Vector3 difference = (mousePosition - fieldPosition);
        Vector2 vector = new Vector3(difference.x, difference.y).normalized;
        float angle = Vector2.Angle(vector, Vector2.right);
        if (vector.y < 0) angle = 360 - angle;
        _angle = angle;
        ResetCursor(angle);
    }

    private void ResetCursor(float angle)
    {
        angle = (angle + 30) % 360;
        switch ((int)(angle / 60))
        {
            case 0:
                Cursor.SetCursor(_right);
                break;
            case 1:
                Cursor.SetCursor(_rightUp);
                break;
            case 2:
                Cursor.SetCursor(_leftUp);
                break;
            case 3:
                Cursor.SetCursor(_left);
                break;
            case 4:
                Cursor.SetCursor(_leftDown);
                break;
            case 5:
                Cursor.SetCursor(_rightDown);
                break;
        }
    }

    public override void Click()
    {
        Field movementField = GetMovementField(_angle);
        if (movementField != null && 
            ((movementField.IsFree && movementField.FieldType == FieldTypes.MOVEMENT) || 
            movementField == Unit.Field))
        {
            Unit.MoveToField(movementField);
            Unit.AttackUnit(Field.Unit);
            GameController.Instance.PlayersMoves.FinishMove();
        }
    }

    private Field GetMovementField(float angle)
    {
        angle = (angle + 30) % 360;
        switch ((int)(angle / 60))
        {
            case 0: return GameController.Instance.Board.GetField(new KeyValuePair<int, int>(Field.Indexes.Key + 1, Field.Indexes.Value));
            case 1: return GameController.Instance.Board.GetField(new KeyValuePair<int, int>(Field.Indexes.Key + 1, Field.Indexes.Value - 1));
            case 2: return GameController.Instance.Board.GetField(new KeyValuePair<int, int>(Field.Indexes.Key, Field.Indexes.Value - 1));
            case 3: return GameController.Instance.Board.GetField(new KeyValuePair<int, int>(Field.Indexes.Key - 1, Field.Indexes.Value));
            case 4: return GameController.Instance.Board.GetField(new KeyValuePair<int, int>(Field.Indexes.Key - 1, Field.Indexes.Value + 1));
            case 5: return GameController.Instance.Board.GetField(new KeyValuePair<int, int>(Field.Indexes.Key, Field.Indexes.Value + 1));
            default: return null;
        }
    }
}
