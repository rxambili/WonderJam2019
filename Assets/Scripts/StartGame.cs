using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Game Events")] [SerializeField] [Tooltip("Triggered when both players are ready to start a game")]
    private GameEvent onPreStartGameP1;

    [SerializeField] private GameEvent onPreStartGameP2;

    private RoundManager roundManager;

    [Header("UI Elements")] [SerializeField]
    private PlayerReadyText player1ReadyText;

    [SerializeField] private PlayerReadyText player2ReadyText;
    [SerializeField] private GameObject player1Canvas;
    [SerializeField] private GameObject player2Canvas;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject title;

    private bool playersAreReady;
    private bool p1Ready;
    private bool p2Ready;

    private void Start()
    {
        roundManager = GetComponent<RoundManager>();
    }

    public void setPlayer1Ready()
    {
        p1Ready = true;
        onPreStartGameP1.raise();
        checkPlayersReady();
    }

    public void setPlayer2Ready()
    {
        p2Ready = true;
        onPreStartGameP2.raise();
        checkPlayersReady();
    }

    private void checkPlayersReady()
    {
        if (!p1Ready || !p2Ready || playersAreReady) return;
        
        playersAreReady = true;
        Debug.Log("launch the game");
        // startRounds();
    }

    private void startRounds()
    {
        player1Canvas.SetActive(true);
        player2Canvas.SetActive(true);
        timer.SetActive(true);
        title.SetActive(false);
        player1ReadyText.gameObject.SetActive(false);
        player2ReadyText.gameObject.SetActive(false);
        roundManager.enabled = true;
    }
}