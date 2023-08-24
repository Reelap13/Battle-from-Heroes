using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{
    [Header("Preset")]
    [SerializeField] private GameObject _fieldPref;
    [SerializeField] private GameBoardVector _vector;
    [SerializeField] private Transform _startingPoint;
    [Header("Board size")]
    [SerializeField] private int length;
    [SerializeField] private int weigth;

    private GameBoard _board;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();

        _board = new GameBoard(this);
        _board.CreateFields();
    }



    public LinkedList<Field> GetLeftSide()
    {
        return ClearFieldsFromOcupated(_board.GetLeftSide());
    }

    public LinkedList<Field> GetRightSide()
    {
        return ClearFieldsFromOcupated(_board.GetRightSide());
    }

    private LinkedList<Field> ClearFieldsFromOcupated(LinkedList<Field> fields)
    {
        LinkedList<Field> freeFields = new LinkedList<Field> ();
        foreach (Field field in fields)
            if (field.IsFree) 
                freeFields.AddLast (field);
        return freeFields;
    }


    public GameObject CreateField() { return Instantiate(_fieldPref) as GameObject;  }
    public int Length { get { return length; } }
    public int Weith { get { return weigth; } }
    public Vector3 BoardStartingPoint { get { return _startingPoint.position; } }
    public GameBoardVector Vector { get { return _vector; } }
    public Transform Transform { get { return _transform; } }
}
