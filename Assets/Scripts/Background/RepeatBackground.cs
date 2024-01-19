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
    private float moveSpeed;
    private void Awake()
    {
        moveSpeed = 15f;
        startPos = transform.position;
        repepatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
    private void OnEnable()
    {
        DistanceManager.OnIncreaseGeneralGameSpeed += BackgroundSpeedIncrementer;
        GameEvents.OnGameLostEventsHandler += BackgroundMovementStopEvent;
        GameEvents.OnStartGameEvent += BackgroundMovementEvent;
       
    }
    private void OnDisable()
    {
        GameEvents.OnStartGameEvent -= BackgroundMovementEvent;
        GameEvents.OnGameLostEventsHandler -= BackgroundMovementStopEvent;
        DistanceManager.OnIncreaseGeneralGameSpeed -= BackgroundSpeedIncrementer;

    }
    private void BackgroundMovementEvent(bool state)
    {
        if (state)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
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
        moveSpeed = 0;
    }

    private void BackgroundSpeedIncrementer(float coefficient)
    {
        moveSpeed += coefficient;
    }
}
