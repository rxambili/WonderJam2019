using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StartTitleAnimation : MonoBehaviour
{
    private Animator animator;

    public GameEvent onTitleAppeared;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void bonjour()
    {
        onTitleAppeared.raise();
    }
}
