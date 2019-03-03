using System.Collections;
using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    private TextMeshProUGUI text;

    [Header("Fading options")] [Tooltip("Loop the fading animation")]
    public bool repeat;

    [Tooltip("The text will be initially set as transparent")]
    public bool startAsInvisible;

    [Header("Fading time")] [Tooltip("Seconds before starting the fading animation")]
    public float startTime;

    public float fadeInTime;
    public float screenTime;
    public float fadeOutTime;

    private bool isFinishedStartWait;
    private bool onScreen;
    private bool fading;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (startAsInvisible)
        {
            text.CrossFadeAlpha(0f, 0f, false);
        }

        StartCoroutine(waitStart(startTime, true));
    }

    private void Update()
    {
        if (fading || !isFinishedStartWait) return;

        if (onScreen)
        {
            fadeOut();
        }
        else if (repeat)
        {
            fadeIn();
        }
    }

    private void fadeIn()
    {
        if (onScreen) return;
        onScreen = true;
        fading = true;

        text.CrossFadeAlpha(1f, fadeInTime, false);
        waitOnScreen(fadeInTime, true);
    }

    private void fadeOut()
    {
        if (!onScreen) return;
        onScreen = false;
        fading = true;

        text.CrossFadeAlpha(0f, fadeOutTime, false);
        waitOnScreen(fadeOutTime, false);
    }

    private void waitOnScreen(float time, bool fadeIn)
    {
        StartCoroutine(wait(screenTime + time, fadeIn));
    }

    private IEnumerator waitStart(float seconds, bool isFadeIn)
    {
        var t = 0;
        while (t++ < seconds)
        {
            yield return new WaitForSeconds(1f);
        }

        if (isFadeIn) fadeIn();
        else fadeOut();

        isFinishedStartWait = true;
    }

    private IEnumerator wait(float seconds, bool isFadeIn)
    {
        var t = 0;
        while (t++ < seconds)
        {
            yield return new WaitForSeconds(1f);
        }

        onScreen = isFadeIn;
        fading = false;
    }
}