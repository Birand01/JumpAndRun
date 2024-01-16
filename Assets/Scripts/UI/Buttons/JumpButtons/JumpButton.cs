using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class JumpButton : ButtonBase
{
   
    public static event Action OnPlayerJumpEvent;
    public static Action OnMoveBackGroundEvent;
    protected override void OnButtonEventHandler()
    {
        OnPlayerJumpEvent?.Invoke();
    }

    protected override void ButtonInteractability()
    {
        base.ButtonInteractability();
        if(groundInteraction.isGrounded && gameEvents.gameStarted.Value)
        {
            IsButtonInteractable(true);
        }
        else
        {
            IsButtonInteractable(false);
        }
    }
}
