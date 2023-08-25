using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberOfUnits : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private TextMeshPro _textMeshPro;

    private void Awake()
    {
        _unit.onChangeNumberOfUnits.AddListener(SetNumberOfUnits);
    }

    public void SetNumberOfUnits(int numberOfUnits)
    {
        _textMeshPro.text = numberOfUnits.ToString();
    }
}
