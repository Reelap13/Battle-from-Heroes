using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class GameBoard
{
    private GameBoardController _controller;
    private Dictionary<KeyValuePair<int, int>, Field> _board;
    public GameBoard(GameBoardController controller)
    {
        _controller = controller;
        _board = new Dictionary<KeyValuePair<int, int>, Field>();
    }

    public void CreateFields()
    {
        for (int line = 0; line < _controller.Weith; line++)
        {
            int tiltSide = - line / 2; 
            for (int row = tiltSide; row < _controller.Length + tiltSide; row++)
            {
                GameObject fieldObject = _controller.CreateField();
                var indexes = new KeyValuePair<int, int>(row, line);
                Debug.Log(_controller.Vector.Right + " " +
                    _controller.Vector.RightDown);
                fieldObject.transform.position = _controller.BoardStartingPoint +
                    _controller.Vector.Right * row +
                    _controller.Vector.RightDown * line;
                fieldObject.transform.parent = _controller.Transform;

                Field field = fieldObject.GetComponent<Field>();
                field.setPreset(indexes);
                _board.Add(indexes, field);
            }
        }
    }


}
