using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PunchlineCategory{
    CLASH,
    EGO
}

[CreateAssetMenu(fileName = "Punchline", menuName = "Action/Punchline", order = 1)]
public class Punchline : ScriptableObject
{
    public string title = "...";
    public string line = "...";
    public int flowCost = 0;
    public PunchlineCategory category;

    public List<Effect> effects = new List<Effect>();

    public bool hasCounter = false;

    public string counter = "...";
    
}
