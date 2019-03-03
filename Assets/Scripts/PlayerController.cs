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

    [HideInInspector]
    public Punchline[] playerPunchlines = new Punchline[3];
    [HideInInspector]
    public Punchline selectedLine;

    private DialogueManager dialogueManager;
    private ActionMode currentActionMode;
    

    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
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
        playerPanel.HideFlowPourcentageText();
        playerPanel.HideCounterImages();
        playerPanel.DisplayButtons(true);
        playerPanel.OptionMode();       
    }

    public void ClashMode()
    {
        playerPanel.DisplayButtons(true);
        playerPanel.SetButtonText(ButtonName.X, playerPunchlines[0].title, chooseTextColor(playerPunchlines[0]));
        playerPanel.SetButtonText(ButtonName.Y, playerPunchlines[1].title, chooseTextColor(playerPunchlines[1]));
        playerPanel.SetButtonText(ButtonName.B, playerPunchlines[2].title, chooseTextColor(playerPunchlines[2]));
        playerPanel.SetPunchLinePourcentage(ButtonName.X, playerPunchlines[0].flowCost);
        playerPanel.SetPunchLinePourcentage(ButtonName.Y, playerPunchlines[1].flowCost);
        playerPanel.SetPunchLinePourcentage(ButtonName.B, playerPunchlines[2].flowCost);
        playerPanel.ShowFlowPourcentageText();
        showCounterIconIfCounterExist();
        currentActionMode = ActionMode.CLASH;

        if (playerPunchlines[0].flowCost > flow)
        {
            playerPanel.DisableButton(ButtonName.X);
        }
        if (playerPunchlines[1].flowCost > flow)
        {
            playerPanel.DisableButton(ButtonName.Y);
        }
        if (playerPunchlines[2].flowCost > flow)
        {
            playerPanel.DisableButton(ButtonName.B);
        }


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

    public void EndingPhase()
    {
        playerPanel.HideCounterImages();
        playerPanel.DisplayButtons(false);
    }

    public ActionMode GetActionMode()
    {
        return currentActionMode;
    }

    public void ResetSelectedButton()
    {
        selectedButton = ButtonName.NONE;
    }

    public void SayPunchline(Punchline line)
    {
        ResetSelectedButton();
        dialogueManager.StartDialogue(line);
    }

    public void SayPunchline()
    {
        dialogueManager.StartDialogue(selectedLine);
    }

    public void SayPunchline(string[] line)
    {
        dialogueManager.StartDialogue(line);
    }

    public bool IsTalking()
    {
        return dialogueManager.isTalking;
    }

    

    public bool HasTalked()
    {
        return dialogueManager.hasTalked;
    }

    public void ResetDialogues()
    {
        dialogueManager.hasTalked = false;
        dialogueManager.isTalking = false;
    }

    public ButtonTextColor chooseTextColor(Punchline punchline)
    {
        switch(punchline.category)
        {
            case PunchlineCategory.CLASH:
                return ButtonTextColor.RED;
            case PunchlineCategory.EGO:
                return ButtonTextColor.ORANGE;
            case PunchlineCategory.CLASHEGO:
                return ButtonTextColor.REDORANGE;
            default:
                return ButtonTextColor.WHITE;
        }
    }

    public void showCounterIconIfCounterExist()
    {
        if (playerPunchlines[0].hasCounter)
        {
            Debug.Log("Affichage counter X");
            playerPanel.ShowCounterImage(ButtonName.X);
        }
        if (playerPunchlines[1].hasCounter)
        {
            Debug.Log("Affichage counter Y");
            playerPanel.ShowCounterImage(ButtonName.Y);
        }
        if (playerPunchlines[2].hasCounter)
        {
            Debug.Log("Affichage counter B");
            playerPanel.ShowCounterImage(ButtonName.B);
        }
    }

    public bool IsButtonDisabled(ButtonName button)
    {
        return playerPanel.IsButtonDisabled(button);
    }
}
