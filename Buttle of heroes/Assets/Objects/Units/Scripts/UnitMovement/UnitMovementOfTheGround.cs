using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementOfTheGround : UnitMovement
{


    public override void Move(Field targetField)
    {
        onBegginingOfMoving.Invoke();
        Transform.position = targetField.transform.position;
        onEndOfMoving.Invoke();
    }

    public override void ShowAvailableFieldForMoving()
    {
        LinkedList<Field> fields = GameController.Instance.Board.GetAllAvailableFieldsToMoveByGround(Field, _movement);
        GameController.Instance.Board.PaintMovementFields(fields);
    }
    public override void HideAvailableFieldForMoving()
    {
        GameController.Instance.Board.ClearMovementField();
    }
}
