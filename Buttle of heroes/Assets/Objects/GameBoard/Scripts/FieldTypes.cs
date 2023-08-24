using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FieldTypes
{
    COMMON,
    ATTACKED,
    MOVEMENT
}

public static class FieldTypesMethods
{
    private static Color common = new Color(255, 255, 255, 128) / 256;
    private static Color attacked = new Color(255, 0, 0, 255) / 256;
    private static Color movement = new Color(255, 255, 255, 255) / 256; 
    public static Color GetColorByType(FieldTypes type)
    {
        switch (type)
        {
            case FieldTypes.COMMON: return common;
            case FieldTypes.ATTACKED: return attacked; ;
            case FieldTypes.MOVEMENT: return movement; ;
            default: return common;
        }
    }
}