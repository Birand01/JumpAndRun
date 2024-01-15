using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class JumpButton : ButtonBase
{
    [Inject] GroundInteraction groundInteraction; 
    public static event Action OnPlayerJumpEvent;
    public static Action OnMoveBackGroundEvent;
    protected override void OnButtonEventHandler()
    {
        OnPlayerJumpEvent?.Invoke();
    }

    protected override void ButtonInteractability()
    {
        if(groundInteraction.isGrounded)
        {
            IsButtonInteractable(true);
        }
        else
        {
            IsButtonInteractable(false);
        }
    }
}
