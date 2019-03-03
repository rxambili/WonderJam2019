using UnityEngine;

public class SoundButton : MonoBehaviour
{
    private new static AudioSource audio;
    
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public static void playOkButtonSound()
    {
        audio.Play();
    }
}
