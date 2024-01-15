using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInteraction : InteractionBase
{
    internal bool isGrounded;
    protected override void Awake()
    {
        base.Awake();
        this._collider.isTrigger = false;
    }
    protected override void OnCollisionEnterAction(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
