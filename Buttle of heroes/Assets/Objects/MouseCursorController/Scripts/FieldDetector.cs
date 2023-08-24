using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDetector : MonoBehaviour
{
    [SerializeField] private Field _field;

    private void OnMouseEnter()
    {
        GameController.Instance.Cursor.EnterToField(_field);
    }

    private void OnMouseExit()
    {
        GameController.Instance.Cursor.LeaveFromFild(_field);
    }

    private void OnMouseDown()
    {
        GameController.Instance.Cursor.ClickOnField(_field);
    }
}
