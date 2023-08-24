using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentMove : MonoBehaviour
{
    [SerializeField] private PlayersMoves PlayersMoves;

    private Unit _currentUnit;

    public void StartGame()
    {
        StartNextMove();
    }

    public void StartNextMove()
    {
        _currentUnit = PlayersMoves.Queue.GetNextUnit();
        _currentUnit.StartUnitMove();
    }

    public void FinishMove()
    {
        if (_currentUnit == null) return;

        _currentUnit.FinishUnitMove();
        StartNextMove();
    }


}
