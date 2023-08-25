using UnityEngine;

public class KnightTakingDamage : UnitTakingDamage
{
    [SerializeField] private int _startingReducingPercent;
    [SerializeField] private int _amountOfReducing;

    private int _reducingPercent;

    public override void SetPreset()
    {
        base.SetPreset();
        _reducingPercent = _startingReducingPercent;
    }

    public override void TakeDamage(Damage damage)
    {
        float finalDamage = damage.GetFinalDamage();
        finalDamage *= 1 - _reducingPercent / 100;

        _reducingPercent -= _amountOfReducing;
        if (_reducingPercent < 0) _reducingPercent = 0;
        TakeFinalDamage(finalDamage, damage.Owner);
    }
}
