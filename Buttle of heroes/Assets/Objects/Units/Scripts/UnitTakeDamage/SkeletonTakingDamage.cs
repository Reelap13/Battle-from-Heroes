using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTakingDamage : UnitTakingDamage
{
    [SerializeField] private GameObject _lowerSkeletonPref;
    [SerializeField] private int _startingPenalty;
    [SerializeField] private int _amountOfReducing;
    [SerializeField] private int _maxNumberOfCreating;
    protected int TeamId => _unit.TeamId;
    protected Field Field => _unit.Field;
    protected int _penalty;
    protected int _numberOfCreating;

    public override void SetPreset()
    {
        base.SetPreset();
        onUnitDeaded.AddListener(CreateSkeleton);
        _penalty = _startingPenalty;
        _numberOfCreating = 0;
    }

    private void CreateSkeleton(int numberOfDeadedUnits)
    {
        if (_numberOfCreating >= _maxNumberOfCreating) return;

        LinkedList<Field> fields = GameController.Instance.Board.GetTheNearestFreeFields(Field.Indexes);
        Unit unit = GameController.Instance.Units.CreateUnitOnTheBoard(_lowerSkeletonPref, numberOfDeadedUnits, TeamId, fields);
        unit.AddEffects(new CharacteristicsPenalty(unit, _penalty));

        _penalty += _amountOfReducing;
        _numberOfCreating++;
    }

}
