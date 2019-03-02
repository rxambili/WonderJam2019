using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "Action/Effect", order = 1)]
public class Effect : ScriptableObject
{
    // effects on target player
    public int pressureDamage = 0;
    public int flowDamage = 0;

    // effects on source player
    public int pressureBoost = 0;
    public int flowBoost = 0;

    // effects on audience
    public int hype = 0;
    
}