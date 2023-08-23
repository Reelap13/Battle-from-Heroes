using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementOfTheGround : UnitMovement
{
    public UnitMovementOfTheGround(Unit unit, int movement, int initiative, Transform transform) : base(unit, movement, initiative, transform)
    {
        
    }

    public override void HideAvailableFieldForMoving()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Field targetField)
    {
        throw new System.NotImplementedException();
    }

    public override void ShowAvailableFieldForMoving()
    {
        throw new System.NotImplementedException();
    }
}
