using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Units : MonoBehaviour
{
    public UnityEvent<Unit> onCreatingUnit = new UnityEvent<Unit>();
    public UnityEvent<Unit> onDieingUnit = new UnityEvent<Unit>();

    private LinkedList<Unit> _units;
    private void Awake()
    {
        _units = new LinkedList<Unit>();
        onDieingUnit.AddListener((Unit unit) =>
        {
            Debug.Log($"{unit.Name} is die");
        });
    }

    public void CreateUnitsOnTheBoard(UnitPack[] unitPacks, int teamId, LinkedList<Field> fields)
    {
        if (fields.Count < unitPacks.Length)
        {
            Debug.Log($"Not enough fields for creating {teamId} team's units");
            return;
        }
        Field[] shuffledField = ShuffleField(fields);

        for (int i = 0; i < unitPacks.Length; i++)
        {
            UnitPack unitPack = unitPacks[i];
            Field field = shuffledField[i];

            Unit unit = CreateUnit(unitPack, teamId, field);
            _units.AddLast(unit);
            onCreatingUnit.Invoke(unit);
        }

    }

    public Unit CreateUnitOnTheBoard(GameObject unitPref, int numberOfUnit, int teamId, LinkedList<Field> fields)
    {
        if (fields.Count < 1)
        {
            Debug.Log($"Not enough fields for creating {teamId} team's unit");
            return null;
        }

        Field[] shuffledField = ShuffleField(fields);

        Field field = shuffledField[0];

        Unit unit = CreateUnit(unitPref, numberOfUnit, teamId, field);
        _units.AddLast(unit);
        onCreatingUnit.Invoke(unit);
        return unit;
    }
    private Unit CreateUnit(UnitPack pack, int teamId, Field field)
    {
        return CreateUnit(pack.UnitPref, pack.NumberOfUnit, teamId, field);
    }
    private Unit CreateUnit(GameObject unitPref, int numberOfUnit, int teamId, Field field)
    {
        void RemoveUnit(Unit unit)
        {
            _units.Remove(unit);
            onDieingUnit.Invoke(unit);
        }

        GameObject unitObject = Instantiate(unitPref) as GameObject;
        Unit unit = unitObject.GetComponent<Unit>();
        unit.SetPreset(numberOfUnit, teamId, field);
        unit.onDieing.AddListener(RemoveUnit);
        return unit;
    }

    private Field[] ShuffleField(LinkedList<Field> fields)
    {
        Field[] shuffledField = new Field[fields.Count];
        {
            int i = 0;
            foreach (Field field in fields)
            {
                shuffledField[i] = field;
                i++;
            }
        }

        System.Random random = new System.Random();
        for (int i = shuffledField.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            Field temp = shuffledField[j];
            shuffledField[j] = shuffledField[i];
            shuffledField[i] = temp;
        }

        return shuffledField;
    }
}
