using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerReadyText : MonoBehaviour
{
    [SerializeField]
    private GameEvent onReady;
    
    private TextMeshProUGUI playerSelection;

    public bool ready { get; set; }

    private void Awake()
    {
        playerSelection = GetComponent<TextMeshProUGUI>();
    }

    public void setReady()
    {
        onReady.raise();
        gameObject.SetActive(false);
    }
}
