﻿using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StartTitleAnimation : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private RuntimeAnimatorController titleToBattle;

    public GameEvent onTitleAppeared;
    public GameEvent onReadyFight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setReadyFightAnimator()
    {
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Title to battle");
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