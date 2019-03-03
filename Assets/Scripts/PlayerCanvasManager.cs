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

public enum ButtonTextColor
{
    WHITE,
    RED,
    ORANGE,
    REDORANGE
}

public class PlayerCanvasManager : MonoBehaviour
{
    [Header("buttons")]
    public GameObject m_buttonsContainer;

    [Header("buttonsTexts")]
    public TextMeshProUGUI m_XbuttonText;
    public TextMeshProUGUI m_YbuttonText;
    public TextMeshProUGUI m_AbuttonText;
    public TextMeshProUGUI m_BbuttonText;
    [Header("buttonsFlowPourcentage")]
    public TextMeshProUGUI m_XbuttonFlowPourcentageText;
    public TextMeshProUGUI m_YbuttonFlowPourcentageText;
    public TextMeshProUGUI m_BbuttonFlowPourcentageText;
    [Header("buttonsCounterImage")]
    public Image m_XbuttonCounterImage;
    public Image m_YbuttonCounterImage;
    public Image m_BbuttonCounterImage;

    public Color disabledColor;
    public Color enabledColor;

    public void OptionMode()
    {
        SetButtonText(ButtonName.X, "Flow", ButtonTextColor.WHITE);
        SetButtonText(ButtonName.Y, "Public", ButtonTextColor.WHITE);
        SetButtonText(ButtonName.B, "Clash", ButtonTextColor.WHITE);
        SetButtonText(ButtonName.A, "...", ButtonTextColor.WHITE);

        DisableButton(ButtonName.A);
        
    }

    public void SetButtonText(ButtonName button, string description, ButtonTextColor textColor)
    {
        switch (button)
        {
            case ButtonName.X:
                m_XbuttonText.text = description;
                SetTextColor(m_XbuttonText,textColor);
                break;
            case ButtonName.Y:
                m_YbuttonText.text = description;
                SetTextColor(m_YbuttonText, textColor);
                break;
            case ButtonName.B:
                m_BbuttonText.text = description;
                SetTextColor(m_BbuttonText, textColor);
                break;
            case ButtonName.A:
                m_AbuttonText.text = description;
                break;
        }
    }

    public void SetPunchLinePourcentage(ButtonName button, int pourcentage)
    {
        switch (button)
        {
            case ButtonName.X:
                m_XbuttonFlowPourcentageText.text = ""+pourcentage+"%";
                break;
            case ButtonName.Y:
                m_YbuttonFlowPourcentageText.text = "" + pourcentage + "%";
                break;
            case ButtonName.B:
                m_BbuttonFlowPourcentageText.text = "" + pourcentage + "%";
                break;
            case ButtonName.A:
                break;
        }
    }

    public void HideFlowPourcentageText()
    {
        m_XbuttonFlowPourcentageText.enabled = false;
        m_YbuttonFlowPourcentageText.enabled = false;
        m_BbuttonFlowPourcentageText.enabled = false;
    }

    public void ShowFlowPourcentageText()
    {
        m_XbuttonFlowPourcentageText.enabled = true;
        m_YbuttonFlowPourcentageText.enabled = true;
        m_BbuttonFlowPourcentageText.enabled = true;
    }

    public void HideCounterImages()
    {
        m_XbuttonCounterImage.enabled = false;
        m_YbuttonCounterImage.enabled = false;
        m_BbuttonCounterImage.enabled = false;
    }

    public void ShowCounterImage(ButtonName button)
    {
        switch (button)
        {
            case ButtonName.X:
                m_XbuttonCounterImage.enabled = true;
                break;
            case ButtonName.Y:
                m_YbuttonCounterImage.enabled = true;
                break;
            case ButtonName.B:
                m_BbuttonCounterImage.enabled = true;
                break;
            case ButtonName.A:
                break;
        }
    }


    public void SetTextColor(TextMeshProUGUI text,ButtonTextColor textColor)
    {
        switch(textColor)
        {
            case ButtonTextColor.WHITE:
                text.color = Color.white;
                break;
            case ButtonTextColor.RED:
                text.color = Color.red;
                break;
            case ButtonTextColor.ORANGE:
                text.color = Color.yellow;
                break;
            case ButtonTextColor.REDORANGE:
                text.color = new Color(1.0f, 0.64f, 0.0f);
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
