using System;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private GameEvent onPlayer1Selected;
    [SerializeField] private GameEvent onPlayer2Selected;

    private bool player1Ready;
    private bool player2Ready;

    private delegate void onReady();

    private static onReady onPlayerReady;

    private void Update()
    {
        var playerInput1 = Input.GetAxis("Player1 Button A");
        if (Math.Abs(playerInput1) > 0.1f) onPlayer1Selected.raise();

        var playerInput2 = Input.GetAxis("Player2 Button A");
        if (Math.Abs(playerInput2) > 0.1f) onPlayer2Selected.raise();
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