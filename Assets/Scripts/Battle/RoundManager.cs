using System;
using System.Collections;
using UnityEngine;

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

    [Header("Debug")] [SerializeField] private int round = 1;
    [SerializeField] private PhaseName phase;
    [SerializeField] private int timer = 5;

    public delegate void OnPhase(PhaseName phase);

    public static OnPhase onPhase;

    private void Start()
    {
        onPhase += process;
        phase = PhaseName.SELECT_OPTION;

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
        if (phase == PhaseName.END_PHASE)
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
        phase = PhaseName.SELECT_OPTION;
        round++;
    }

    private void process(PhaseName phase)
    {
        switch (phase)
        {
            case PhaseName.SELECT_OPTION:
                timer = optionTime;
                break;

            case PhaseName.SELECT_ACTION:
                timer = actionTime;
                break;

            case PhaseName.END_PHASE:
                timer = endPhaseTime;
                break;

            default:
                throw new ArgumentOutOfRangeException("phase", phase, null);
        }
    }
}