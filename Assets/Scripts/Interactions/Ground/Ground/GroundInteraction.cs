using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInteraction : InteractionBase
{
    [SerializeField] internal bool isGrounded;
    [SerializeField] private ParticleSystem dirtParticle;
    protected override void Awake()
    {
        base.Awake();
        this._collider.isTrigger = false;
    }
    private void OnEnable()
    {
        GameEvents.OnGameLostEventsHandler += OnGameFailEvent;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        GameEvents.OnGameLostEventsHandler -= OnGameFailEvent;

    }

    protected override void OnCollisionEnterAction(Collision collision)
    {

        isGrounded = true;
        dirtParticle.Play();


    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        dirtParticle.Stop();

    }

    private void OnGameFailEvent()
    {
        dirtParticle.Stop();
    }
   
   
}
