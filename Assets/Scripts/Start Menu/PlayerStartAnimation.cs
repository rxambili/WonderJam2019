using UnityEngine;

public class PlayerStartAnimation : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    public void setPlayersActive()
    {
        player1.SetActive(true);
        player2.SetActive(true);
    }
}
