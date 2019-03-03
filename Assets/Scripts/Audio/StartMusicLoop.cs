using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StartMusicLoop : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    private AudioSource audio;

    private bool hasPlayedOnce;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audio.isPlaying || hasPlayedOnce) return;
        
        audio.clip = clip;
        audio.loop = true;
        hasPlayedOnce = true;
        audio.Play();
    }
}
