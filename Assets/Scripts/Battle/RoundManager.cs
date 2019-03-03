using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour
{
    
    public enum PhaseName
    {
        SELECT_OPTION, // Options : insultes, repos, public, ???
        SELECT_ACTION, // Actions : insulte_1, insulte_2,...
        END_PHASE // Calcul des dégâts
    }

    public OptionPhase phaseOption;
     
    [Header("Timer")] [SerializeField] private int optionTime;
    [SerializeField] private int actionTime;
    [SerializeField] private int endPhaseTime;

    [Header("Punchline")]
    [SerializeField] private Punchline[] punchlines;
    [SerializeField] private Punchline noActionPunchline;
    [SerializeField] private Punchline publicPunchline;
    [SerializeField] private Punchline reposPunchline;
    [SerializeField] private Punchline failedCounter;

    [Header("Debug")] [SerializeField] private int round = 1;


    [SerializeField] private PhaseName currentPhase;
    [SerializeField] private int timer = 5;

    public delegate void OnTimer(int time);

    public static OnTimer onTimer;

    private PlayerController player1;
    private PlayerController player2;
    private PlayerController firstTalker;
    private PlayerController secondTalker;
    

    private void Start()
    {
        currentPhase = PhaseName.SELECT_OPTION;
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
        InitializePhase();
    }

    public IEnumerator StartCountdown(int countdownValue)
    {
        timer = countdownValue;
        while (timer >= 0)
        {
            yield return new WaitForSeconds(1.0f);
            onTimer(timer);
            timer--;
        }
    }

    public void nextPhase()
    {
        EndPhase();
        if (currentPhase == PhaseName.END_PHASE)
        {
            nextRound();
        }
        else
        {
            currentPhase++;
        }
        InitializePhase();

    }

   

    private void nextRound()
    {
        currentPhase = PhaseName.SELECT_OPTION;
        round++;
    }

    private void Update()
    {
        GetInputPlayer1();
        GetInputPlayer2();

        if (currentPhase == PhaseName.END_PHASE)
        {

            if (!firstTalker.IsTalking() && !firstTalker.HasTalked())
            {
                firstTalker.SayPunchline();
            }

            if (!secondTalker.IsTalking() && !secondTalker.HasTalked() && firstTalker.HasTalked())
            {
                secondTalker.SayPunchline();
            }

            if (firstTalker.HasTalked() && secondTalker.HasTalked())
            {
                ApplyEffects(player1.selectedLine, player1, player2);
                ApplyEffects(player2.selectedLine, player2, player1);
                player1.ResetDialogues();
                player2.ResetDialogues();
               
                nextPhase();
            }
        }
        if (timer < 0 && currentPhase != PhaseName.END_PHASE)
        {
            nextPhase();
        }
    }

    private void InitializePhase()
    {
        switch (currentPhase)
        {
            case PhaseName.SELECT_OPTION:
                player1.OptionMode();
                player2.OptionMode();
                StartCoroutine(StartCountdown(optionTime));

                player1.ResetSelectedButton();
                player2.ResetSelectedButton();
                break;

            case PhaseName.SELECT_ACTION:
                SelectAvailablePunchlines();
                LaunchChosenAction(player1);
                LaunchChosenAction(player2);
                if (player1.GetActionMode() != ActionMode.CLASH && player2.GetActionMode() != ActionMode.CLASH)
                {
                    nextPhase();
                } else
                {
                    StartCoroutine(StartCountdown(actionTime));
                }
                player1.ResetSelectedButton();
                player2.ResetSelectedButton();
                break;

            case PhaseName.END_PHASE:
                ChooseLines();
                player1.EndingPhase();
                player2.EndingPhase();
                // StartCoroutine(StartCountdown(endPhaseTime));
                
                break;

            default:
                throw new ArgumentOutOfRangeException("phase", currentPhase, null);
        }
    }

    private void EndPhase()
    {
        switch (currentPhase)
        {
            case PhaseName.SELECT_OPTION:
                break;

            case PhaseName.SELECT_ACTION:
                break;

            case PhaseName.END_PHASE:
                player1.EndRound();
                player2.EndRound();
                break;

            default:
                throw new ArgumentOutOfRangeException("phase", currentPhase, null);
        }
        
    }

    private void GetInputPlayer1()
    {
        if (Input.GetButtonDown("Player1 Button A") && !player1.IsButtonDisabled(ButtonName.A))
        {
            player1.selectedButton = ButtonName.A;
        }
        if (Input.GetButtonDown("Player1 Button B") && !player1.IsButtonDisabled(ButtonName.B))
        {
            player1.selectedButton = ButtonName.B;
        }
        if (Input.GetButtonDown("Player1 Button X") && !player1.IsButtonDisabled(ButtonName.X))
        {
            player1.selectedButton = ButtonName.X;
        }
        if (Input.GetButtonDown("Player1 Button Y") && !player1.IsButtonDisabled(ButtonName.Y))
        {
            player1.selectedButton = ButtonName.Y;
        }
    }

    private void GetInputPlayer2()
    {
        if (Input.GetButtonDown("Player2 Button A") && !player2.IsButtonDisabled(ButtonName.A))
        {
            player2.selectedButton = ButtonName.A;
        }
        if (Input.GetButtonDown("Player2 Button B") && !player2.IsButtonDisabled(ButtonName.B))
        {
            player2.selectedButton = ButtonName.B;
        }
        if (Input.GetButtonDown("Player2 Button X") && !player2.IsButtonDisabled(ButtonName.X))
        {
            player2.selectedButton = ButtonName.X;
        }
        if (Input.GetButtonDown("Player2 Button Y") && !player2.IsButtonDisabled(ButtonName.Y))
        {
            player2.selectedButton = ButtonName.Y;
        }
    }

    private void LaunchChosenAction(PlayerController player)
    {
        switch (player.selectedButton)
        {
            case ButtonName.X:
                player.RecupFlowMode();
                break;
            case ButtonName.Y:
                player.PublicMode();
                break;
            case ButtonName.B:
                player.ClashMode();
                break;
            default:
                player.NoActionMode();
                break;
        }
    }

    private void ChooseLines()
    {
        
        switch (player1.GetActionMode())
        {
            case ActionMode.CLASH:
                SelectClashLine(player1);
                break;
            case ActionMode.FLOW:
                player1.selectedLine = reposPunchline;
                break;
            case ActionMode.PUBLIC:
                player1.selectedLine = publicPunchline;
                break;
            case ActionMode.NOACTION:
                player1.selectedLine = noActionPunchline;
                break;
            default:
                break;
        }

        switch (player2.GetActionMode())
        {
            case ActionMode.CLASH:
                SelectClashLine(player2);
                break;
            case ActionMode.FLOW:
                player2.selectedLine = reposPunchline;
                break;
            case ActionMode.PUBLIC:
                player2.selectedLine = publicPunchline;
                break;
            case ActionMode.NOACTION:
                player2.selectedLine = noActionPunchline;
                break;
            default:
                break;
        }

        float rand = Random.Range(0, 1);
        if (rand >= 0.5)
        {
            firstTalker = player1;
            secondTalker = player2;
        }
        else
        {
            firstTalker = player2;
            secondTalker = player1;
        }

        if (player1.selectedLine == failedCounter && player2.selectedLine != failedCounter)
        {
            firstTalker = player2;
            secondTalker = player1;
            if (player2.selectedLine.hasCounter)
            {
                player1.selectedLine = player2.selectedLine.counter;
                player2.selectedLine = Instantiate(player2.selectedLine);
                player2.selectedLine.effects = new List<Effect>();
            }
        }

        if (player2.selectedLine == failedCounter && player1.selectedLine != failedCounter)
        {
            firstTalker = player1;
            secondTalker = player2;
            if (player1.selectedLine.hasCounter)
            {
                player2.selectedLine = player1.selectedLine.counter;
                player1.selectedLine = Instantiate(player1.selectedLine);
                player1.selectedLine.effects = new List<Effect>();
            }
        }


    }

    private void SelectAvailablePunchlines()
    {
        List<Punchline> listPunchlines = new List<Punchline>(punchlines);

        // joueur 1
        for (int i=0; i<3; i++)
        {
            int chosenIndex = Random.Range(0, listPunchlines.Count);
            player1.playerPunchlines[i] = listPunchlines[chosenIndex];
            listPunchlines.RemoveAt(chosenIndex);
        }

        // joueur 2
        for (int i = 0; i < 3; i++)
        {
            int chosenIndex = Random.Range(0, listPunchlines.Count);
            player2.playerPunchlines[i] = listPunchlines[chosenIndex];
            listPunchlines.RemoveAt(chosenIndex);
        }
    }

    private void ApplyEffects(Punchline line, PlayerController source, PlayerController target)
    {
        source.AddFlow(-line.flowCost);
        foreach (Effect e in line.effects)
        {
            target.AddPressure(e.pressureDamage);
            target.AddFlow(-e.flowDamage);
            source.AddPressure(e.pressureBoost);
            source.AddFlow(e.flowBoost);
            // TODO: public/hype
        }
    }

    private void SelectClashLine(PlayerController player)
    {
        player.selectedLine = noActionPunchline;
        switch (player.selectedButton)
        {
            case ButtonName.X:
                player.selectedLine = player.playerPunchlines[0];
                break;
            case ButtonName.Y:
                player.selectedLine = player.playerPunchlines[1];
                break;
            case ButtonName.B:
                player.selectedLine = player.playerPunchlines[2];
                break;
            case ButtonName.A:
                player.selectedLine = failedCounter;
                break;
            default:
                player.selectedLine = noActionPunchline;
                break;
        }
    }
}