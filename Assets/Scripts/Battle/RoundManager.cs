using System;
using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public enum Phase
    {
        SELECT_OPTION, // Options : insultes, repos, public, ???
        SELECT_ACTION, // Actions : insulte_1, insulte_2,...
        END_PHASE // Calcul des dégâts
    }
     
    [Header("Timer")] [SerializeField] private int optionTime;
    [SerializeField] private int actionTime;
    [SerializeField] private int endPhaseTime;

    [Header("Debug")] [SerializeField] private int round = 1;
    [SerializeField] private Phase phase;
    [SerializeField] private int timer = 5;

    public delegate void OnPhase(Phase phase);

    public static OnPhase onPhase;

    private void Start()
    {
        onPhase += process;
        phase = Phase.SELECT_OPTION;

        StartCoroutine("countdown");
    }

    private IEnumerator countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer--;

            // TODO: gérer aussi les deux joueurs qui font une action avant le timer
            if (timer == 0)
            {
                nextPhase();
            }
        }
    }

    public void nextPhase()
    {
        if (phase == Phase.END_PHASE)
        {
            nextRound();
        }
        else
        {
            phase++;
        }

        onPhase(phase);
    }

    private void nextRound()
    {
        phase = Phase.SELECT_OPTION;
        round++;
    }

    private void process(Phase phase)
    {
        switch (phase)
        {
            case Phase.SELECT_OPTION:
                timer = optionTime;
                break;

            case Phase.SELECT_ACTION:
                timer = actionTime;
                break;

            case Phase.END_PHASE:
                timer = endPhaseTime;
                break;

            default:
                throw new ArgumentOutOfRangeException("phase", phase, null);
        }
    }
}