using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleInteraction : InteractionBase
{
    [Inject] GameEvents gameEvents;
    protected override void OnTriggerEnterAction(Collider other)
    {
       gameEvents.gameLost.SetValueAndForceNotify(true);
    }
}
