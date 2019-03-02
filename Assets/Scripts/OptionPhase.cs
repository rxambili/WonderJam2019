using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OptionPhase
{


    public void SetUp(PlayerController p1, PlayerController p2)
    {
        p1.OptionMode();
        p2.OptionMode();
    }
}
