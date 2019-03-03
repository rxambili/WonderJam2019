using System;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private GameEvent onPlayer1Selected;
    [SerializeField] private GameEvent onPlayer2Selected;

    [SerializeField] private GameObject tutoPanel;
    private bool isDoingTuto;

    private bool player1Ready;
    private bool player2Ready;

    private delegate void onReady();

    private static onReady onPlayerReady;


    private void OnEnable()
    {
        player1Ready = false;
        player2Ready = false;
        StopTuto();
    }

    private void Update()
    {
       
        if (!isDoingTuto)
        {
            var playerInput1 = Input.GetAxis("Player1 Button A");
            if (Math.Abs(playerInput1) > 0.1f)
            {
                onPlayer1Selected.raise();
                player1Ready = true;
            }

            var playerInput2 = Input.GetAxis("Player2 Button A");
            if (Math.Abs(playerInput2) > 0.1f)
            {
                onPlayer2Selected.raise();
                player2Ready = true;
            }

            if (!player1Ready || !player2Ready)
            {
                var p1Tuto = Input.GetAxis("Player1 Button Y");
                var p2Tuto = Input.GetAxis("Player2 Button Y");
                if (Input.GetButtonDown("Player1 Button Y") || Input.GetButtonDown("Player2 Button Y"))
                {
                    StartTuto();
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Player1 Button Y") || Input.GetButtonDown("Player2 Button Y"))
            {
                StopTuto();
            }
        }
        

    }

    private void StartTuto()
    {
        isDoingTuto = true;
        tutoPanel.SetActive(true);        
    }
    private void StopTuto()
    {
        tutoPanel.SetActive(false);
        isDoingTuto = false;
    }

    public void setP1Ready()
    {
        onPlayerReady();
    }
    
    public void setP2Ready()
    {
        onPlayerReady();
    }
}