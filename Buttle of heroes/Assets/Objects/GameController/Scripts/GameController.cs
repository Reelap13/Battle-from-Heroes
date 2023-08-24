using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [field: SerializeField]
    public GameBoardController Board;
    [field: SerializeField]
    public Units Units;
    [field: SerializeField]
    public PlayerUI PlayerUI;
    [field: SerializeField]
    public PlayersMoves PlayersMoves;
    [field: SerializeField]
    public MouseCursorController Cursor;

    private void Awake()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        PlayerUI.ShowMessage("The game has started");
        PlayersMoves.StartNextMove();
    }
}
