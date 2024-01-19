using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using Unity.VisualScripting;

public class GameEvents : MonoBehaviour
{
    private CompositeDisposable subscriptions = new CompositeDisposable();


    // ------------------------ GAME START EVENTS ----------------------------------------
    public BoolReactiveProperty gameStarted { get; set; } = new BoolReactiveProperty(false);
    public static event Action<bool> OnStartGameEvent; 
    public static event Action<CanvasType> OnSwitchGameUI;
    // ------------------------------------------------------------------
  


    /// -------------------  GAME FAIL EVENTS ---------------------------
    public BoolReactiveProperty gameLost { get; set; } = new BoolReactiveProperty(false);
    public static event Action OnGameLostEventsHandler;
    public static event Action<CanvasType> OnSwitchFailUI;
    //--------------------------------------------------------------------------


    // ------------------- GAME SUCCESS EVENTS -------------------------------
    public BoolReactiveProperty gameWon { get; set; } = new BoolReactiveProperty(false);
    private void OnEnable()
    {
        StartCoroutine(Subscribe());
        ObstacleInteraction.OnGameOverEvent += OnGameOverEventTrigger;     
        StartGameButton.OnSpawnObstacle += OnGameStartTrigger;
    }
    private void OnDisable()
    {
        subscriptions.Clear();
        ObstacleInteraction.OnGameOverEvent -= OnGameOverEventTrigger;
        StartGameButton.OnSpawnObstacle -= OnGameStartTrigger;
    }
    private IEnumerator Subscribe()
    {
        yield return null;
        this.UpdateAsObservable().Where(value => gameStarted.Value == true)
           .Subscribe(value =>
           {
              
               OnSwitchGameUI?.Invoke(CanvasType.GameUI);
               OnStartGameEvent?.Invoke(true);
           })
           .AddTo(subscriptions);
        this.UpdateAsObservable().Where(value => gameLost.Value == true)
            .Subscribe(value =>
            {
                OnGameLostEventsHandler?.Invoke();
                OnSwitchFailUI?.Invoke(CanvasType.GameLostUI);
            })
            .AddTo(subscriptions);
        this.UpdateAsObservable().Where(value => gameWon.Value == true)
            .Subscribe(value =>
            {

               
            })
            .AddTo(subscriptions);
        this.UpdateAsObservable().Where(value => gameWon.Value == true || gameLost.Value == true)
           .Subscribe(value =>
           {
               OnStartGameEvent?.Invoke(false);
           })
           .AddTo(subscriptions);
    }
  

    private void OnGameOverEventTrigger(bool state)
    {
        gameLost.Value = state;
      
    }
    private void OnGameStartTrigger(bool state)
    {
        gameStarted.Value = state;
        Debug.Log(gameStarted.Value);
    }
}
