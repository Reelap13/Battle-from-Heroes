using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teams : MonoBehaviour
{
    [SerializeField] private Team _leftTeam;
    [SerializeField] private Team _rightTeam;

    private const int LEFT_TEAM_ID = 0;
    private const int RIGHT_TEAM_ID = 1;

    public void CreateUnits()
    {
        LinkedList<Field> leftSide = GameController.Instance.Board.GetLeftSide();
        GameController.Instance.Units.CreateUnitsOnTheBoard(_leftTeam.UnitPacks, LEFT_TEAM_ID, leftSide);
        
        LinkedList<Field> rightSide = GameController.Instance.Board.GetRightSide();
        GameController.Instance.Units.CreateUnitsOnTheBoard(_rightTeam.UnitPacks, RIGHT_TEAM_ID, rightSide);

    }
}
