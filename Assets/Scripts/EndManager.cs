using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private StartGame restartController;

    [SerializeField] private GameObject player1Win;
    [SerializeField] private GameObject player2Win;
    [SerializeField] private GameObject draw;


    [SerializeField] private GameObject endPanel;

    bool endGameModeActivated = false;

    // Update is called once per frame
    void Update()
    {
        if (endGameModeActivated)
        {
            var p1Rematch = Input.GetAxis("Player1 Button A");
            var p2Rematch = Input.GetAxis("Player2 Button A");
            var p1Quit = Input.GetAxis("Player1 Button B");
            var p2Quit = Input.GetAxis("Player2 Button B");
            if (Input.GetButtonDown("Player1 Button A") || Input.GetButtonDown("Player2 Button A"))
            {
                //restartGame();
                SceneManager.LoadScene(0);
            }
            else if(Input.GetButtonDown("Player1 Button B") || Input.GetButtonDown("Player2 Button B"))
            {
                Application.Quit();
            }
            
        }
    }

    void restartGame()
    {
        endPanel.SetActive(false);
        restartController.MainMenu();
        endGameModeActivated = false;
    }

    public void setEndGameMode()
    {
        endPanel.SetActive(true);
        endGameModeActivated = true;
    }

    public void WinPlayer1()
    {
        player1Win.SetActive(true);
        player2Win.SetActive(false);
        draw.SetActive(false);
    }

    public void WinPlayer2()
    {
        player1Win.SetActive(false);
        player2Win.SetActive(true);
        draw.SetActive(false);
    }

    public void Draw()
    {
        player1Win.SetActive(false);
        player2Win.SetActive(false);
        draw.SetActive(true);
    }
}
