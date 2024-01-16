using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class GameEvents : MonoBehaviour
{
    private CompositeDisposable subscriptions = new CompositeDisposable();


    // ------------------------ GAME START EVENTS ----------------------------------------
    public BoolReactiveProperty gameStarted { get; set; } = new BoolReactiveProperty(false);
    public static event Action<bool> OnStartGameEvent;
    // ------------------------------------------------------------------
  


    /// -------------------  GAME FAIL EVENTS ---------------------------
    public BoolReactiveProperty gameLost { get; set; } = new BoolReactiveProperty(false);
    public static event Action OnGameLostEventsHandler;
    //--------------------------------------------------------------------------


    // ------------------- GAME SUCCESS EVENTS -------------------------------
    public BoolReactiveProperty gameWon { get; set; } = new BoolReactiveProperty(false);
    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private IEnumerator Subscribe()
    {
        yield return null;
        this.UpdateAsObservable().Where(value => gameStarted.Value == true)
           .Subscribe(value =>
           {
               OnStartGameEvent?.Invoke(true);
           })
           .AddTo(subscriptions);
        this.UpdateAsObservable().Where(value => gameLost.Value == true)
            .Subscribe(value =>
            {
                OnGameLostEventsHandler?.Invoke();
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
              
              
           })
           .AddTo(subscriptions);
    }
    private void OnDisable()
    {
        subscriptions.Clear();
    }
}
