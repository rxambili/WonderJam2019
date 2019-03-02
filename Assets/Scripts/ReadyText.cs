using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyText : MonoBehaviour
{

    public TextMeshProUGUI text;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.enabled = player.selectedButton != ButtonName.NONE;
    }
}
