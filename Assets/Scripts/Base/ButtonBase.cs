using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class ButtonBase : MonoBehaviour
{
    [Inject] protected GroundInteraction groundInteraction;
    [Inject] protected GameEvents gameEvents;
    private CompositeDisposable subscriptions = new CompositeDisposable();
    private Button button;
    protected int motionSign = 1;


    private void Awake()
    {
        button = GetComponent<Button>();
    }


    private void Start()
    {
        button.onClick.AddListener(OnButtonClickEvent);
    }

    private void OnButtonClickEvent()
    {
        OnButtonEventHandler();

    }

    protected abstract void OnButtonEventHandler();
    protected virtual void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void OnDisable()
    {
        subscriptions.Clear();
    }


    protected virtual IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
            ButtonInteractability();
            OnMustButtonDisableEvents();


        })
            .AddTo(subscriptions);
    }

    protected virtual void ButtonInteractability() { }
    protected void IsButtonInteractable(bool state)
    {
        button.interactable = state;
    }

    private void OnMustButtonDisableEvents()
    {
        if (gameEvents.gameLost.Value || gameEvents.gameWon.Value)
        {
            IsButtonInteractable(false);
        }
    }
}
