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
    [Header("Debug")] [SerializeField] private int round = 1;


    [SerializeField] private PhaseName currentPhase;
    [SerializeField] private int timer = 5;

    private PlayerController player1;
    private PlayerController player2;

    private void Start()
    {
        currentPhase = PhaseName.SELECT_OPTION;
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>() ;
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
        InitializePhase();
    }

    public IEnumerator StartCountdown(int countdownValue)
    {
        timer = countdownValue;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
    }

    public void nextPhase()
    {
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
        if (timer <= 0)
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
                break;

            case PhaseName.SELECT_ACTION:
                SelectAvailablePunchlines();
                LaunchChosenAction(player1);
                LaunchChosenAction(player2);
                StartCoroutine(StartCountdown(actionTime));
                break;

            case PhaseName.END_PHASE:
                player1.EndRound();
                player2.EndRound();
                StartCoroutine(StartCountdown(endPhaseTime));
                break;

            default:
                throw new ArgumentOutOfRangeException("phase", currentPhase, null);
        }
        player1.ResetSelectedButton();
        player2.ResetSelectedButton();
    }

    private void GetInputPlayer1()
    {
        if (Input.GetButtonDown("Player1 Button A"))
        {
            player1.selectedButton = ButtonName.A;
        }
        if (Input.GetButtonDown("Player1 Button B"))
        {
            player1.selectedButton = ButtonName.B;
        }
        if (Input.GetButtonDown("Player1 Button X"))
        {
            player1.selectedButton = ButtonName.X;
        }
        if (Input.GetButtonDown("Player1 Button Y"))
        {
            player1.selectedButton = ButtonName.Y;
        }
    }

    private void GetInputPlayer2()
    {
        if (Input.GetButtonDown("Player2 Button A"))
        {
            player2.selectedButton = ButtonName.A;
        }
        if (Input.GetButtonDown("Player2 Button B"))
        {
            player2.selectedButton = ButtonName.B;
        }
        if (Input.GetButtonDown("Player2 Button X"))
        {
            player2.selectedButton = ButtonName.X;
        }
        if (Input.GetButtonDown("Player2 Button Y"))
        {
            player2.selectedButton = ButtonName.Y;
        }
    }

    private void LaunchChosenAction(PlayerController player)
    {
        Debug.Log(player.selectedButton);
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
}