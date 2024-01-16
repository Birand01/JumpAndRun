using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repepatWidth;
    [SerializeField] private float moveLeftSpeed;
    private void Awake()
    {
        startPos = transform.position;
        repepatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
    private void OnEnable()
    {
        GameEvents.OnGameLostEventsHandler += BackgroundMovementStopEvent;
        GameEvents.OnStartGameEvent += BackgroundMovementEvent;
       
    }
    private void OnDisable()
    {
        GameEvents.OnStartGameEvent -= BackgroundMovementEvent;
        GameEvents.OnGameLostEventsHandler -= BackgroundMovementStopEvent;

    }
    private void BackgroundMovementEvent(bool state)
    {
        if (state)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveLeftSpeed);
            if (transform.position.x < startPos.x - repepatWidth)
            {
                transform.position = startPos;
            }
        }
        else
            return;
       
    }
    private void BackgroundMovementStopEvent()
    {
        moveLeftSpeed = 0;
    }
}
