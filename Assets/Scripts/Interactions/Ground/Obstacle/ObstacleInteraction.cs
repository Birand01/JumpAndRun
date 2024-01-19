using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleInteraction : InteractionBase
{
    
    public static event Action<bool> OnGameOverEvent;
    public static event Action<SoundType,bool> OnCrashSound;
    protected override void OnTriggerEnterAction(Collider other)
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        other.gameObject.GetComponentInChildren<ParticleConfig>().GetComponent<ParticleSystem>().Play();
        OnCrashSound?.Invoke(SoundType.HitSound, true);
        OnGameOverEvent?.Invoke(true);
    }
}
