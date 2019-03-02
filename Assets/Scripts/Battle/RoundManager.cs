using System;
using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public enum Phase
    {
        SELECT_OPTION,
        SELECT_ACTION,
        END_PHASE
    }

    private Phase phase;

    [Header("Timer")] [SerializeField] private int optionTime;
    [SerializeField] private int actionTime;
    [SerializeField] private int endPhaseTime;

    [Header("Debug")] [SerializeField] private int round = 1;
    [SerializeField] private int timer = 5;

    public delegate void OnPhase(Phase phase);

    public static OnPhase onPhase;

    private void Awake()
    {
        onPhase += process;
    }

    private void Start()
    {
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

            Debug.Log("Time: " + timer);
        }
    }

    public void nextPhase()
    {
        if (phase == Phase.END_PHASE)
        {
            phase = Phase.SELECT_OPTION;
            round++;
        }
        else
        {
            phase++;
        }

        onPhase(phase);
    }

    private void process(Phase phase)
    {
        switch (phase)
        {
            case Phase.SELECT_OPTION:
                timer = optionTime;
                Debug.Log("OPTION");
                break;

            case Phase.SELECT_ACTION:
                timer = actionTime;
                Debug.Log("ACTION");
                break;

            case Phase.END_PHASE:
                timer = endPhaseTime;
                Debug.Log("END");
                break;

            default:
                throw new ArgumentOutOfRangeException("phase", phase, null);
        }
    }
}