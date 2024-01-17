using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleInteraction : InteractionBase
{
    public static event Action<bool> OnGameOverEvent;
    protected override void OnTriggerEnterAction(Collider other)
    {
        OnGameOverEvent?.Invoke(true);
    }
}
