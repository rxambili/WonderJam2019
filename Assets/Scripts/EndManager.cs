using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{

    [SerializeField] private GameObject player1Win;
    [SerializeField] private GameObject player2Win;
    [SerializeField] private GameObject draw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinPlayer1()
    {
        player1Win.SetActive(true);
    }

    public void WinPlayer2()
    {
        player2Win.SetActive(true);
    }

    public void Draw()
    {
        draw.SetActive(true);
    }
}
