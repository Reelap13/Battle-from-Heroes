using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public UnityEvent onCreating = new UnityEvent();
    public UnityEvent onBegginingOfMove = new UnityEvent();
    public UnityEvent onEndOfMove = new UnityEvent();

    [field: SerializeField]
    public UnitAttack c { get; private set; }
    [field: SerializeField]
    public UnitTakingDamage TakingDamage { get; private set; }
    [field: SerializeField]
    public UnitMovement Movement { get; private set; }
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public int Initiative { get; private set; }

    public int NumberOfUnits { get; private set; }
    public int TeamId { get; private set; }
    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    public void SetPreset(int numberOfUnit, int teamId)
    {
        NumberOfUnits = numberOfUnit;
        TeamId = teamId;
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
