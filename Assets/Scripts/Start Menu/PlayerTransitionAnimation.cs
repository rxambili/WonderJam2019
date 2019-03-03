using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerTransitionAnimation : MonoBehaviour
{
    private Animator animator;

    public new AudioSource audio;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setRunningAnimation()
    {
        if (audio != null)
            audio.Play(66150);
        animator.SetTrigger("RunTransition");
    }
}