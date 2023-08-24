using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueOfMovesUI : MonoBehaviour
{
    [SerializeField] private UnitIcon[] _icons;

    private LinkedList<Unit> _currentMove;
    private LinkedList<Unit> _followingMoves;
    private void Awake()
    {
        void SetCurrentMove(LinkedList<Unit> currentMove)
        {
            _currentMove = currentMove;
            ResetQueue();
        }
        void SetFollowingMoves(LinkedList<Unit> followingMoves)
        {
            _followingMoves = followingMoves;
            ResetQueue();
        }

        GameController.Instance.PlayersMoves.OnChangingCurrentMove.AddListener(SetCurrentMove);
        GameController.Instance.PlayersMoves.OnChangingFollowingMoves.AddListener(SetFollowingMoves);
    }

    public void ResetQueue()
    {
        if (_currentMove == null || _followingMoves == null)
            return;

        int index = 0;
        foreach (var unit in _currentMove)
        {
            if (index >= _icons.Length) return;

            _icons[index].SetUnitIcon(unit.Icon);
            index++;
        }

        while (true)
        {
            foreach (var unit in _followingMoves)
            {
                if (index >= _icons.Length) return;

                _icons[index].SetUnitIcon(unit.Icon);
                index++;
            }
        }
    }
}
