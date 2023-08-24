using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public UnityEvent onCreating = new UnityEvent();
    public UnityEvent<Unit> onDieing = new UnityEvent<Unit>();
    public UnityEvent onBegginingOfMove = new UnityEvent();
    public UnityEvent onEndOfMove = new UnityEvent();

    [field: SerializeField]
    public UnitAttack Attack { get; private set; }
    [field: SerializeField]
    public UnitTakingDamage TakingDamage { get; private set; }
    [field: SerializeField]
    public UnitMovement Movement { get; private set; }
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public Sprite Icon { get; private set; }
    [field: SerializeField]
    public int Initiative { get; private set; }

    public int NumberOfUnits { get; private set; }
    public int TeamId { get; private set; }
    public Field Field { get; private set; }    
    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;

        void Die()
        {
            onDieing.Invoke(this);
            Destroy(gameObject);
        }
        TakingDamage.onDieing.AddListener(Die);
    }

    public void SetPreset(int numberOfUnit, int teamId, Field field)
    {
        NumberOfUnits = numberOfUnit;
        TeamId = teamId;
        Field = field;
        field.Enter(this);
        onCreating.Invoke();
    }

    public void StartUnitMove()
    {
        onBegginingOfMove.Invoke();
    }

    public void FinishUnitMove()
    {
        onEndOfMove.Invoke();
    }
}
