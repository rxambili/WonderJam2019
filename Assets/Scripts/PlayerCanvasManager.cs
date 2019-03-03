using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public Color disabledColor;
    public Color enabledColor;

    public void OptionMode()
    {
        SetButtonText(ButtonName.X, "Recup ton Flow");
        SetButtonText(ButtonName.Y, "Chauffer le Publique");
        SetButtonText(ButtonName.B, "Clasher");
        SetButtonText(ButtonName.A, "...");

        DisableButton(ButtonName.A);
        
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
        if (display)
        {
            EnableButtons();
        }
        m_buttonsContainer.SetActive(display);
    }

    public void DisableButton(ButtonName button)
    {
       
        switch (button)
        {
            case ButtonName.X:
                m_XbuttonText.transform.parent.GetComponent<Image>().color = disabledColor;
                m_XbuttonText.color = disabledColor;
                break;
            case ButtonName.Y:
                m_YbuttonText.transform.parent.GetComponent<Image>().color = disabledColor;
                m_YbuttonText.color = disabledColor;
                break;
            case ButtonName.B:
                m_BbuttonText.transform.parent.GetComponent<Image>().color = disabledColor;
                m_BbuttonText.color = disabledColor;
                break;
            case ButtonName.A:
                m_AbuttonText.transform.parent.GetComponent<Image>().color = disabledColor;
                m_AbuttonText.color = disabledColor;
                break;
        }
    }

    private void EnableButtons()
    {
        m_XbuttonText.transform.parent.GetComponent<Image>().color = enabledColor;
        m_XbuttonText.color = enabledColor;
        m_YbuttonText.transform.parent.GetComponent<Image>().color = enabledColor;
        m_YbuttonText.color = enabledColor;
        m_BbuttonText.transform.parent.GetComponent<Image>().color = enabledColor;
        m_BbuttonText.color = enabledColor;
        m_AbuttonText.transform.parent.GetComponent<Image>().color = enabledColor;
        m_AbuttonText.color = enabledColor;
    }

    public bool IsButtonDisabled(ButtonName button)
    {
        switch (button)
        {
            case ButtonName.X:
                return m_XbuttonText.transform.parent.GetComponent<Image>().color == disabledColor;
            case ButtonName.Y:
                return m_YbuttonText.transform.parent.GetComponent<Image>().color == disabledColor;
            case ButtonName.B:
                return m_BbuttonText.transform.parent.GetComponent<Image>().color == disabledColor;
            case ButtonName.A:
                return m_AbuttonText.transform.parent.GetComponent<Image>().color == disabledColor;
            default:
                return true;
        }
    }
} 
