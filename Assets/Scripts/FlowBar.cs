using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlowBar : MonoBehaviour
{
    private Image flowBar;
    public TextMeshProUGUI pourcentageText;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        flowBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        flowBar.fillAmount = (float)player.flow / 100;
        pourcentageText.text = "" + player.flow + "/100";
    }
}
