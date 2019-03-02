using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("UI")] 
    public PlayerCanvasManager player1Panel;
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


    bool m_SelectionActive = false;
    ButtonName m_currentSelection;
    void Update()
    {
        if (m_SelectionActive)
        {
                //retenir l'input
        }
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


    public void OptionMode()
    {
        player1Panel.OptionMode();

        player1Panel.DisplayButtons(true);
        m_SelectionActive = true;
    }

    public void ClashMode()
    {
        player1Panel.SetButtonText(ButtonName.X, "Clash1");
        player1Panel.SetButtonText(ButtonName.Y, "Clash2");
        player1Panel.SetButtonText(ButtonName.B, "Clash3");
        player1Panel.SetButtonText(ButtonName.A, "Clash4");

        m_SelectionActive = true;
    }

    public void RecupFlowMode()
    {
        m_SelectionActive = false;
        player1Panel.DisplayButtons(false);
    }

    public void PublicMode()
    {
        m_SelectionActive = false;
        player1Panel.DisplayButtons(false);
    }

}
