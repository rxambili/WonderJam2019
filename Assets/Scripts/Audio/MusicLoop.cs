using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicLoop : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenu;
    [SerializeField] private AudioClip phase1;
    [SerializeField] private AudioClip phase2;
    [SerializeField] private AudioClip phase3;

    [SerializeField] [Range(0, 100)] private int pressureLevelOne = 33;
    [SerializeField] [Range(0, 100)] private int pressureLevelTwo = 66;

    private AudioSource currentAudio;

    private bool hasPlayedOnce;

    private void Awake()
    {
        currentAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        RoundManager.onNextPhase += checkPlayersPressure;
    }

    private void Update()
    {
        startMusicLoop();
    }

    private void OnDisable()
    {
        RoundManager.onNextPhase -= checkPlayersPressure;
    }

    private void startMusicLoop()
    {
        if (currentAudio.isPlaying || hasPlayedOnce) return;

        currentAudio.clip = mainMenu;
        currentAudio.loop = true;
        hasPlayedOnce = true;
        currentAudio.Play();
    }

    private void checkPlayersPressure(PlayerController p1, PlayerController p2)
    {
        if (p1.pressure > pressureLevelOne || p2.pressure > pressureLevelOne)
        {
            if (p1.pressure > pressureLevelTwo || p2.pressure > pressureLevelTwo)
            {
                playTrack(phase3);
                return;
            }

            playTrack(phase2);
        }
        else
        {
            playTrack(phase1);
        }
    }

    private void playTrack(AudioClip clip)
    {
        if (currentAudio.clip == clip) return;

        currentAudio.Stop();
        currentAudio.clip = clip;
        currentAudio.Play();
    }

    public void startBattleMusic()
    {
        currentAudio.clip = phase1;
        currentAudio.Play();
    }
}