using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Field : MonoBehaviour
{
    [SerializeField] private int _movementCost;

    public UnityEvent<UnitsPack> onEnter = new UnityEvent<UnitsPack>();
    public UnityEvent<UnitsPack> onLeave = new UnityEvent<UnitsPack>();

    private KeyValuePair<int, int> _indexes;
    private UnitsPack _pack = null;

    public void setPreset(KeyValuePair<int, int> indexes) { _indexes = indexes; }

    private void OnMouseDown()
    {
        Debug.Log(_indexes);
    }

    public void Enter(UnitsPack pack)
    {
        _pack = pack;
        onEnter.Invoke(pack);
    }

    public void Leave()
    {
        onLeave.Invoke(_pack); 
        _pack = null;
    }

    public UnitsPack Pack { get { return _pack; } }
    public bool IsFree { get { return _pack == null; } }
    public int MovementCost { get { return _movementCost; } }
    public KeyValuePair<int, int> Indexes { get { return _indexes; } }
}
