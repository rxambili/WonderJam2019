using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerTransitionAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setRunningAnimation()
    {
        animator.SetTrigger("RunTransition");
    }
}