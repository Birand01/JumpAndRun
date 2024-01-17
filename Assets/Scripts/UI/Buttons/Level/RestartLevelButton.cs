using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelButton : LevelButtonBase
{
    public static event Action OnLevelStartButton;
    protected override void OnButtonClickEvent()
    {
        OnLevelStartButton?.Invoke();
    }
}
