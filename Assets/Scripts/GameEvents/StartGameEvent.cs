using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class StartGameEvent : MonoBehaviour
{
    public static event Action<bool> OnStartGameNotify;
    public void GameStart()
    {
        OnStartGameNotify?.Invoke(true);
        //gameEvents.gameStarted.SetValueAndForceNotify(true);
        //Debug.Log(gameEvents.gameStarted.Value);
    }
}
