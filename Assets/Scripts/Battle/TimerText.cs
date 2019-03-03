using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TimerText : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private int size = 50;

    [FormerlySerializedAs("count")] public List<AudioClip> countSounds = new List<AudioClip>();
    private AudioSource audio;

    private void Awake()
    {
        timer = GetComponent<TextMeshProUGUI>();
        audio = GetComponent<AudioSource>();
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
        timer.text = time != 0 ? time.ToString() : "";

        if (time > countSounds.Count || time == 0) return;
        
        audio.Stop();
        audio.clip = countSounds[time - 1];
        audio.Play();
    }
}