using System;
using System.Collections;
using TMPro;
using UnityEngine;

public enum ActionMode
{
    CLASH,
    FLOW,
    PUBLIC,
    NOACTION
}

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("UI")] public PlayerCanvasManager playerPanel;

    private Animator animator;

    public bool isDoingSomething = false;

    public static int maxPressure = 100;
    public static int minPressure = 0;
    public static int maxFlow = 100;
    public static int minFlow = 0;

    public static int regenFlow = 10;

    public int pressure { get; set; }
    public int flow { get; set; }

    public ButtonName selectedButton { get; set; }

   

    [HideInInspector] public Punchline[] playerPunchlines = new Punchline[3];
    [HideInInspector] public Punchline selectedLine;

    private DialogueManager dialogueManager;
    private ActionMode currentActionMode;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        
        Initialize();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            pressure = 100;
        }
    }

    public void Initialize()
    {
        
        pressure = minPressure;
        flow = maxFlow;
        selectedButton = ButtonName.NONE;

        playerPanel.enabled = true;

        selectedLine = null;
        isDoingSomething = false;
    }

    public void AddPressure(int amount)
    {
        pressure += amount;

        if (pressure > maxPressure)
        {
            pressure = maxPressure;
        }
        else
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
        animator.SetBool("Clashing", false);

        playerPanel.HideFlowPourcentageText();
        playerPanel.HideCounterImages();
        playerPanel.DisplayButtons(true);
        playerPanel.OptionMode();
    }

    public void ClashMode()
    {
        animator.SetBool("Clashing", true);

        playerPanel.DisplayButtons(true);
        playerPanel.SetButtonText(ButtonName.X, playerPunchlines[0].title, chooseTextColor(playerPunchlines[0]));
        playerPanel.SetButtonText(ButtonName.Y, playerPunchlines[1].title, chooseTextColor(playerPunchlines[1]));
        playerPanel.SetButtonText(ButtonName.B, playerPunchlines[2].title, chooseTextColor(playerPunchlines[2]));
        playerPanel.SetButtonText(ButtonName.A, "Répartie", ButtonTextColor.WHITE);
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

    public void SayPunchline()
    {
        ResetSelectedButton();
        
        dialogueManager.StartDialogue(selectedLine);
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
        switch (punchline.category)
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

    public void takeHit()
    {
        isDoingSomething = true;
        
        StartCoroutine(playAnimation("Hit", 1.5f));
        animator.SetInteger("Pressure", pressure);
        

        // TODO: sfx
    }

    private IEnumerator playAnimation(string animParam, float time)
    {
        float currentTime = 0;
        animator.SetBool(animParam, true);
        
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        
        animator.SetBool(animParam, false);
        isDoingSomething = false;
    }


    public void finishGame()
    {
        Debug.Log("hey");
        playerPanel.DisplayButtons(false);
    }

}