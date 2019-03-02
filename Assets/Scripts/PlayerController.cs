using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int maxPressure = 100;
    public static int minPressure = 0;
    public static int maxFlow = 100;
    public static int minFlow = 0;

    public static int regenFlow = 10;

    public int pressure { get; set; }
    public int flow { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        pressure = minPressure;
        flow = maxFlow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPressure(int amount)
    {
        pressure += amount;

        if (pressure > maxPressure)
        {
            pressure = maxPressure;
        } else
        {
            if (pressure < minPressure)
            {
                pressure = minPressure;
            }
        }
    }

    public void AddFlow(int amount)
    {
        flow += amount;

        if (flow > maxFlow)
        {
            flow = maxFlow;
        }
        else
        {
            if (flow < minFlow)
            {
                flow = minFlow;
            }
        }
    }

    public bool EndRound()
    {
        AddFlow(regenFlow);
        return pressure == maxPressure;
    }
}
