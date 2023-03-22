using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerAnimatorManager : MonoBehaviourPun
{
    Animator animator;
    [SerializeField] private float directionDampTime = 0.25f;
    private void Start()
    {
        animator = GetComponent<Animator>();

        if(!animator)
        {
            Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
        }
    
    }

    private void Update()
    {
        if(photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if(!animator)
        {
            return;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("Base Layer.Run"))
        {
            if(Input.GetButton("Fire2"))
            {
                animator.SetTrigger("Jump");
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log(h + " : " + v);
        if(v<0)
        {
            v = 0;
        }

        animator.SetFloat("Speed", h * h + v * v);
        animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
    }
}
