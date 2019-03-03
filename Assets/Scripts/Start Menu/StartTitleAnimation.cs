
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StartTitleAnimation : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Animator titleToBattle;

    public GameEvent onTitleAppeared;
    public GameEvent onReadyFight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setReadyFightAnimator()
    {
        animator.runtimeAnimatorController = (RuntimeAnimatorController) Resources.Load("Animations/Title to battle");
        Debug.Log(animator.runtimeAnimatorController);
    }

    // Ceci est une fonction essentielle au fonctionnement du programme.
    // NE PAS TOUCHER.
    public void bonjour()
    {
        onTitleAppeared.raise();
    }

    public void readyFight()
    {
        onReadyFight.raise();
    }
}
