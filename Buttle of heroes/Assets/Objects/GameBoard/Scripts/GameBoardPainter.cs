using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardPainter
{
    private LinkedList<Field> _attackedField = new LinkedList<Field>();
    private LinkedList<Field> _movementField = new LinkedList<Field>();

    public void PaintAttackedFields(LinkedList<Field> fields)
    { 
        PaintField(_attackedField, FieldTypes.COMMON);

        _attackedField = fields;
        PaintField(_attackedField, FieldTypes.ATTACKED);
    }
    public void PaintMovementFields(LinkedList<Field> fields)
    {
        PaintField(_movementField, FieldTypes.COMMON);

        _movementField = fields;
        PaintField(_movementField, FieldTypes.MOVEMENT);
    }

    public void ClearAttackedField()
    {
        PaintField(_attackedField, FieldTypes.COMMON);
        _attackedField.Clear();
    }
    public void ClearMovementField()
    {
        PaintField(_movementField, FieldTypes.COMMON);
        _movementField.Clear();
    }

    private void PaintField(LinkedList<Field> fields, FieldTypes type)
    {
        foreach (Field field in fields)
        {
            field.FieldType = type;
        }
    }
}
