using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;


public class PlayerController : MonoBehaviour
{
   
    [SerializeField] internal float easeMotionResponse,gravitiyModifier;
    [SerializeField] internal Ease easeType;
    private Rigidbody _rb;
    private void Awake()
    {
       
        _rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        //Physics.gravity *= gravitiyModifier;
    }


    private void OnDisable()
    {
        JumpButton.OnPlayerJumpEvent -= PlayerJumpEvent;

       
    }

    protected virtual void OnEnable()
    {
        JumpButton.OnPlayerJumpEvent += PlayerJumpEvent;
    }
    

    private void PlayerJumpEvent()
    {
        _rb.DOJump(new Vector3(this.transform.position.x,0.6f,this.transform.position.z),1,1, easeMotionResponse).SetEase(easeType);
    }
}
