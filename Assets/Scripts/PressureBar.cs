using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PressureBar : MonoBehaviour
{
    private Image pressureBar;
    // public TextMeshProUGUI pourcentageText;
    public PlayerController player; 

    // Start is called before the first frame update
    void Start()
    {
        pressureBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        pressureBar.fillAmount = (float)player.pressure/100;
        // pourcentageText.text = "" + player.pressure + "/100";
    }
}
