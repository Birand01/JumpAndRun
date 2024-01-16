using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    protected virtual void OnEnable()
    {
        GameEvents.OnStartGameEvent += ObstacleMovement;
        GameEvents.OnGameLostEventsHandler += OnStopObstacleMovement;
      
    }
    private void OnDisable()
    {
        GameEvents.OnGameLostEventsHandler -= OnStopObstacleMovement;
        GameEvents.OnStartGameEvent -= ObstacleMovement;
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
}
