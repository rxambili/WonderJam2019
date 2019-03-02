using UnityEngine;
using UnityEngine.UI;
public enum ActionMode
{
    CLASH,
    FLOW,
    PUBLIC,
    NOACTION
}
public class PlayerController : MonoBehaviour
{
    [Header("UI")] 
    public PlayerCanvasManager playerPanel;

    public static int maxPressure = 100;
    public static int minPressure = 0;
    public static int maxFlow = 100;
    public static int minFlow = 0;

    public static int regenFlow = 10;

    public int pressure { get; set; }
    public int flow { get; set; }

    public ButtonName selectedButton { get; set; }
    public Punchline[] playerPunchlines = new Punchline[3];
    private ActionMode currentActionMode;

    void Start()
    {
        pressure = minPressure;
        flow = maxFlow;
        selectedButton = ButtonName.NONE;

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
        playerPanel.DisplayButtons(false);
        return pressure == maxPressure;
    }


    public void OptionMode()
    {
        playerPanel.DisplayButtons(true);
        playerPanel.OptionMode();       
    }

    public void ClashMode()
    {
        playerPanel.DisplayButtons(true);
        playerPanel.SetButtonText(ButtonName.X, playerPunchlines[0].title);
        playerPanel.SetButtonText(ButtonName.Y, playerPunchlines[1].title);
        playerPanel.SetButtonText(ButtonName.B, playerPunchlines[2].title);
        playerPanel.SetButtonText(ButtonName.A, "Répartie");
        currentActionMode = ActionMode.CLASH;

    }

    public void RecupFlowMode()
    {
        playerPanel.DisplayButtons(false);
        currentActionMode = ActionMode.FLOW;
    }

    public void PublicMode()
    {
        playerPanel.DisplayButtons(false);
        currentActionMode = ActionMode.PUBLIC;
    }

    public void NoActionMode()
    {
        playerPanel.DisplayButtons(false);
        currentActionMode = ActionMode.NOACTION;
    }

    public ActionMode GetActionMode()
    {
        return currentActionMode;
    }

    public void ResetSelectedButton()
    {
        selectedButton = ButtonName.NONE;
    }
}
