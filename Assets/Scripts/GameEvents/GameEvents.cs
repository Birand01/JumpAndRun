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
                //StartCoroutine(OnPlayerFailUI?.Invoke(CanvasType.GameFailUI, true, canvasDelayTime));
            })
            .AddTo(subscriptions);
        this.UpdateAsObservable().Where(value => gameWon.Value == true)
            .Subscribe(value =>
            {

                //StartCoroutine(OnPlayerSuccessUI?.Invoke(CanvasType.NextLevelUI, true, canvasDelayTime));
            })
            .AddTo(subscriptions);
        this.UpdateAsObservable().Where(value => gameWon.Value == true || gameLost.Value == true)
           .Subscribe(value =>
           {
               OnStartGameEvent?.Invoke(false);
               //OnInitializePlayerVelocityEvent?.Invoke();
               // OnDisablePlayerEvent?.Invoke();
           })
           .AddTo(subscriptions);
    }
    private void OnDisable()
    {
        subscriptions.Clear();
    }
}
