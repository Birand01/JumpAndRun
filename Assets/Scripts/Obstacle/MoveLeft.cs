using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float moveSpeed;
    private void Awake()
    {
        moveSpeed = 15f;
    }
    protected virtual void OnEnable()
    {
        GameEvents.OnStartGameEvent += ObstacleMovement;
        GameEvents.OnGameLostEventsHandler += OnStopObstacleMovement;
        DistanceManager.OnIncreaseGeneralGameSpeed += IncreaseObstacleSpeedEvent;
    }
    private void OnDisable()
    {
        GameEvents.OnGameLostEventsHandler -= OnStopObstacleMovement;
        GameEvents.OnStartGameEvent -= ObstacleMovement;
        DistanceManager.OnIncreaseGeneralGameSpeed -= IncreaseObstacleSpeedEvent;

    }

    private void ObstacleMovement(bool state)
    {
        if (state)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else
        {
            return;
        }
    }
    private void OnStopObstacleMovement()
    {
        moveSpeed = 0;  
    }
    private void IncreaseObstacleSpeedEvent(float coefficient)
    {
        moveSpeed += coefficient;
    }
}
