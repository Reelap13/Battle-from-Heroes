using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    protected Unit _unit;
    
    public Effect(Unit unit)
    {
        _unit = unit;
    }

    public abstract void Enable();
    public abstract void Disable();

}
