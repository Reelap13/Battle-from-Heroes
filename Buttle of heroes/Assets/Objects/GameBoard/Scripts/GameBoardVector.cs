using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardVector : MonoBehaviour
{
    [SerializeField] private Transform _startingPoint;
    [SerializeField] private Transform _rightDownPoint;

    private Vector3 _rightVector;
    private Vector3 _rightDownVector;

    private void Awake()
    {
        _rightDownVector = _rightDownPoint.position - _startingPoint.position;
        _rightVector = _rightDownVector.x * new Vector3(2f, 0f, 0f);
    }

    public Vector3 Right { get { return _rightVector; } }
    public Vector3 RightDown { get { return _rightDownVector; } }

}
