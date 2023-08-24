using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [field: SerializeField]
    public OutputString OutputString;
    [field: SerializeField]
    public QueueOfMovesUI QueueOfMoves;

    public void ShowMessage(string message)
    {
        OutputString.ShowMessage(message);
    }
}
