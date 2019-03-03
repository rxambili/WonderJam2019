using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsTutorial : MonoBehaviour
{
    [SerializeField] Image[] panels;
    [SerializeField] GameObject m_nextButton;
    int currentImage;


    public bool isDoingTuto;
    
        // Start is called before the first frame update
    void Start()
    {
        currentImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoingTuto)
        {
            var p1Tuto = Input.GetAxis("Player1 Button Y");
            var p2Tuto = Input.GetAxis("Player2 Button Y");
            if (Math.Abs(p1Tuto) > 0.1f || Math.Abs(p2Tuto) > 0.1)
            {
                nextTutoPanel();
            }
        }
    }

    public void StartTuto()
    {
        currentImage = 0;
        m_nextButton.SetActive(true);
        isDoingTuto = true;

    }



    void nextTutoPanel()
    {
        currentImage++;
    }
}
