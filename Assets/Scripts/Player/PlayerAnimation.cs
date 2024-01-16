using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private void OnEnable()
    {
        GameEvents.OnGameLostEventsHandler += DieAnimation;
        JumpButton.OnPlayerJumpEvent += JumpAnimation;
        GameEvents.OnStartGameEvent += StartRunAnimation;
    }
    private void OnDisable()
    {
        GameEvents.OnStartGameEvent -= StartRunAnimation;
        JumpButton.OnPlayerJumpEvent -= JumpAnimation;
        GameEvents.OnGameLostEventsHandler -= DieAnimation;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void StartRunAnimation(bool state)
    {
        if(state)
        {
            animator.SetFloat("Speed_f", 1f);
        }
        else
            animator.SetFloat("Speed_f", 0f);
    }

    private void JumpAnimation()
    {
        animator.SetTrigger("Jump_trig");
    }
    private void DieAnimation()
    {
        animator.SetBool("Death_b", true);
        animator.SetInteger("DeathType_int", 1);
    }
}
