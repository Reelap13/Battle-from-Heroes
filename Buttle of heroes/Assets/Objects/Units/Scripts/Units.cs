using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Units : MonoBehaviour
{
    private LinkedList<Unit> units;
    private void Awake()
    {
        units = new LinkedList<Unit>();
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
            units.AddLast(unit);
        }

    }

    private Unit CreateUnit(UnitPack pack, int teamId, Field field)
    {
        GameObject unitObject = Instantiate(pack.UnitPref) as GameObject;
        Unit unit = unitObject.GetComponent<Unit>();
        unit.SetPreset(pack.NumberOfUnit, teamId, field);
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
