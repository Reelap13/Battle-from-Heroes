using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class QueueOfMoves : MonoBehaviour
{
    public UnityEvent<LinkedList<Unit>> onChangingCurrentMove = new UnityEvent<LinkedList<Unit>>();
    public UnityEvent<LinkedList<Unit>> onChangingFollowingMoves = new UnityEvent<LinkedList<Unit>>();

    private LinkedList<Unit> _currentMove;
    private SortedDictionary<int, LinkedList<Unit>> _followingMoves;

    private void Awake()
    {
        _currentMove = new LinkedList<Unit>();
        _followingMoves = new SortedDictionary<int, LinkedList<Unit>>();
        GameController.Instance.Units.onCreatingUnit.AddListener(AddUnit);
    }

    public void StartNextMove()
    {
        _currentMove = GetFollowingMoves();
        onChangingCurrentMove.Invoke(GetCurrentMove());
    }

    public void AddUnit(Unit unit)
    {
        LinkedList<Unit> units;
        if (_followingMoves.TryGetValue(unit.Initiative, out units))
        {
            units.AddLast(unit);
        }
        else
        {
            units = new LinkedList<Unit> ();
            units.AddLast(unit);
            _followingMoves.Add(unit.Initiative, units);
        }

        onChangingFollowingMoves.Invoke(GetFollowingMoves());
    }

    public void DeleteUnit(Unit unit)
    {
        _currentMove.Remove(unit);
        _followingMoves[unit.Initiative].Remove(unit);

        onChangingCurrentMove.Invoke(GetCurrentMove());
        onChangingFollowingMoves.Invoke(GetFollowingMoves());
    }

    public LinkedList<Unit> GetCurrentMove()
    {
        LinkedList<Unit> currentMove = new LinkedList<Unit>();
        foreach (Unit unit in _currentMove)
        {
            currentMove.AddLast(unit);
        }
        return currentMove;
    }

    public LinkedList<Unit> GetFollowingMoves()
    {

        LinkedList<Unit> followingMoves = new LinkedList<Unit>();
        foreach (var units in _followingMoves)
        {
            LinkedList<Unit> unitWithSameInitiative = new LinkedList<Unit>(); 
            foreach (var unit in units.Value) //reverse  the linkedlist so that the earlier the units were added, the faster they moved
            {
                unitWithSameInitiative.AddFirst(unit);
            }
            foreach (var unit in unitWithSameInitiative)
            {
                followingMoves.AddFirst(unit);
            }
        }
        return followingMoves;
    }
}