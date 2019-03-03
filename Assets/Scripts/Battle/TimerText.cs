using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private int size = 50;

    private void Awake()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        RoundManager.onTimer += UpdateTimer;
    }

    private void OnDestroy()
    {
        RoundManager.onTimer -= UpdateTimer;
    }

    private void UpdateTimer(int time)
    {
        timer.text = time.ToString();
    }

}
