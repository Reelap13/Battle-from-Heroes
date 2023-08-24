using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingMoveButton : MonoBehaviour
{
    public void FinishMove()
    {
        GameController.Instance.PlayersMoves.FinishMove();
    }
}
