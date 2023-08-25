using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMeleeAttack : UnitAttack
{
    [SerializeField] private float _minAttackDamageOfOneUnit;
    [SerializeField] private float _maxAttackDamageOfOneUnit;
    [SerializeField] private int _attackDistance;
    public override void Attack(Unit unit)
    {
        float damageNumber = UnityEngine.Random.Range(_minAttackDamageOfOneUnit * NumberOfUnit, _maxAttackDamageOfOneUnit * NumberOfUnit);
        Damage damage = new Damage(_unit, damageNumber);
        onBegginingAttack.Invoke(damage);
        unit.TakeDamage(damage);
    }

    public override void ShowAvailableUnitForAttacking()
    {
        LinkedList<Field> fields = GameController.Instance.Board.GetAllAvailableFieldsToMeleeAttack(
            Field, _unit.Movement.Movement, 
            _attackDistance, _unit.TeamId);
        GameController.Instance.Board.PaintAttackedFields(fields);
    }

    public override void HideAvailableUnitForAttacking()
    {
        GameController.Instance.Board.ClearAttackedField();
    }
}
