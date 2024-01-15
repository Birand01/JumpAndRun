using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StartGameEvent : MonoBehaviour
{
    [Inject] GameEvents gameEvents;
    public void GameStart()
    {
        gameEvents.gameStarted.SetValueAndForceNotify(true);
    }
}
