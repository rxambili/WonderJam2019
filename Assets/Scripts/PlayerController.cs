using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Panel")] 
    public GameObject player1Panel;
    
    
    
    public static int maxPressure = 100;
    public static int minPressure = 0;
    public static int maxFlow = 100;
    public static int minFlow = 0;

    public static int regenFlow = 10;

    public int pressure { get; set; }
    public int flow { get; set; }

    void Start()
    {
        pressure = minPressure;
        flow = maxFlow;
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
