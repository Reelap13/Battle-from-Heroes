using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMeleeAttack : UnitAttack
{
    [SerializeField] private float _minAttackDamageOfOneUnit;
    [SerializeField] private float _maxAttackDamageOfOneUnit;
    [SerializeField] private int _attackDistance;
    public override void Attack(Unit unti)
    {
        throw new System.NotImplementedException();
    }

    public override void ShowAvailableUnitForAttacking()
    {
        LinkedList<Field> fields = GameController.Instance.Board.GetAllAvailableFieldsToMeleeAttack(
            Field, _unit.Movement.Movement, 
            _attackDistance, _unit.TeamId);
        foreach(Field field in fields)
        {
            Debug.Log(field.Indexes);
        }
        GameController.Instance.Board.PaintAttackedFields(fields);
    }

    public override void HideAvailableUnitForAttacking()
    {
        GameController.Instance.Board.ClearAttackedField();
    }
}
