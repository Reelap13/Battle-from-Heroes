using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [field: SerializeField]
    public GameBoardController Board;
    [field: SerializeField]
    public Units Units;
}
