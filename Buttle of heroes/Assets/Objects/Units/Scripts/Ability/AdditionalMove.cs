using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalMove : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField, Range(0, 100)] private int probability;

    private void Awake()
    {
        _unit.onEndOfMove.AddListener(AddAdditionalMove);
    }

    private void AddAdditionalMove()
    {
        if (UnityEngine.Random.Range(0, 100) > probability) return;

        GameController.Instance.PlayerUI.ShowMessage($"{_unit.Name} move again");
        GameController.Instance.PlayersMoves.AddInNextMove(_unit);
    }
}
