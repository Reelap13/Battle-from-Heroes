using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [field: SerializeField]
    public string TeamName;
    [field: SerializeField]
    public Sprite HeroSprite;
    [field: SerializeField]
    public UnitPack[] UnitPacks;


    private void ShowTeamInfo()
    {
        
    }
}
