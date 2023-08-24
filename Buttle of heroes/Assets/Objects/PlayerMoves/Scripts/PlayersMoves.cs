using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayersMoves : MonoBehaviour
{
    [field: SerializeField]
    public QueueOfMoves Queue { get; private set; }
    [field: SerializeField]
    public CurrentMove CurrentMove { get; private set; }

    public void StartNextMove()
    {
        CurrentMove.StartGame();
    }

    public void FinishMove()
    {
        CurrentMove.FinishMove();
    }

    public LinkedList<Unit> GetCurrentMove()
    {
        return Queue.GetCurrentMove();
    } 
    public LinkedList<Unit> GetFollowingMoves()
    {
        return Queue.GetFollowingMoves();
    } 

    public UnityEvent<LinkedList<Unit>> OnChangingCurrentMove { get {  return Queue.onChangingCurrentMove; } }
    public UnityEvent<LinkedList<Unit>> OnChangingFollowingMoves { get {  return Queue.onChangingFollowingMoves; } }
}
