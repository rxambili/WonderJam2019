using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;


public enum ButtonName
{
    X,
    Y,
    A,
    B,
    NONE
}

public class PlayerCanvasManager : MonoBehaviour
{
    [Header("buttons")]
    public GameObject m_buttonsContainer;

    public TextMeshProUGUI m_XbuttonText;
    public TextMeshProUGUI m_YbuttonText;
    public TextMeshProUGUI m_AbuttonText;
    public TextMeshProUGUI m_BbuttonText;

    [Header("speech")]
    public GameObject m_SpeechContainer;
    public TextMeshProUGUI m_Speech;

    public void OptionMode()
    {
        SetButtonText(ButtonName.X, "Recup ton Flow");
        SetButtonText(ButtonName.Y, "Chauffer le Publique");
        SetButtonText(ButtonName.B, "Clasher");
        SetButtonText(ButtonName.A, "...");

    }
    public void SetButtonText(ButtonName button, string description)
    {
        switch (button)
        {
            case ButtonName.X:
                m_XbuttonText.text = description;
                break;
            case ButtonName.Y:
                m_YbuttonText.text = description;
                break;
            case ButtonName.B:
                m_BbuttonText.text = description;
                break;
            case ButtonName.A:
                m_AbuttonText.text = description;
                break;
        }
    }
    public void DisplayButtons(bool display)
    {
        m_buttonsContainer.SetActive(display);
    }
}
