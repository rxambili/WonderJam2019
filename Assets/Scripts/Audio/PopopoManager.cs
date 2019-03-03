using System.Collections.Generic;
using UnityEngine;

public class PopopoManager : MonoBehaviour
{
    private new AudioSource audio;
    
    public List<AudioClip> shortPopopos = new List<AudioClip>();
    public List<AudioClip> longPopopos = new List<AudioClip>();
    public AudioClip superPopopo;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playShortPopopo()
    {
        audio.Stop();
        audio.clip = shortPopopos[Random.Range(0, shortPopopos.Count)];
        audio.Play();
    }
    
    public void playLongPopopo()
    {
        audio.Stop();
        audio.clip = longPopopos[Random.Range(0, longPopopos.Count)];
        audio.Play();
    }

    public void playSuperPopopo()
    {
        audio.Stop();
        audio.clip = superPopopo;
        audio.Play();
    }
}
