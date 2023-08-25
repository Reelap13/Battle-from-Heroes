using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicsPenalty : Effect
{
    private float _penalty;
    public CharacteristicsPenalty(Unit unit, int penalty) : base(unit)
    {
        _penalty = penalty / 100;
    }
    public override void Disable()
    {
        throw new System.NotImplementedException();
    }

    public override void Enable()
    {
        _unit.Attack.onBegginingAttack.AddListener(ReduceDamage);
    }

    private void ReduceDamage(Damage damage)
    {
        damage.ReduceDamage(_penalty);
    } 
}
