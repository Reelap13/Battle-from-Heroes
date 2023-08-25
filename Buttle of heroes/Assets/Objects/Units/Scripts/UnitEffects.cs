using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffects : MonoBehaviour
{
    private HashSet<Effect> _effects = new HashSet<Effect>();

    public void AddEffect(Effect effect)
    {
        effect.Enable();
        _effects.Add(effect);
    }

    public void DeleteEffect(Effect effect)
    {
        effect.Disable();
        _effects.Remove(effect);
    }
}
