using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private RoundManager roundManager;
    [SerializeField] private PlayerReadyText player1ReadyText;
    [SerializeField] private PlayerReadyText player2ReadyText;
    [SerializeField] private GameObject player1Canvas;
    [SerializeField] private GameObject player2Canvas;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject title;


    [SerializeField] private PanelsTutorial TutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        roundManager = GetComponent<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1ReadyText.ready && player2ReadyText.ready)
        {
            StartRounds();
        }
    }

    public void StartRounds()
    {
        player1Canvas.SetActive(true);
        player2Canvas.SetActive(true);
        timer.SetActive(true);
        title.SetActive(false);
        player1ReadyText.gameObject.SetActive(false);
        player2ReadyText.gameObject.SetActive(false);
        roundManager.enabled = true;
    }

    public void MainMenu()
    {
        player1Canvas.SetActive(false);
        player2Canvas.SetActive(false);
        timer.SetActive(false);

        roundManager.enabled = false;

        title.SetActive(true);
        player1ReadyText.gameObject.SetActive(true);
        player2ReadyText.gameObject.SetActive(true);
        

    }
}
