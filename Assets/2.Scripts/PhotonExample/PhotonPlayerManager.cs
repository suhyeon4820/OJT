using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PhotonPlayerManager : MonoBehaviourPunCallbacks
{
    

    [SerializeField] GameObject beams;
    public float health = 1f;
    bool isFiring;

    private void Awake()
    {
        if(beams != null)
        {
            beams.SetActive(false);
        }
    }


    private void Update()
    {
        ProcessInputs();
        // activeInHierarchy : 스크립트를 적용한 오브젝트의 부모 오브젝트에 영향을 받음
        if ((beams!=null) &&(isFiring!=beams.activeInHierarchy))
        {
            beams.SetActive(isFiring);
        }

        if(photonView.IsMine)
        {
            ProcessInputs();
            if(health<=0f)
            {
                PhotonGameManager.Instance.LeaveRoom();
            }
        }

    }

    void ProcessInputs()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(!isFiring)
            {
                isFiring = true;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (isFiring)
            {
                isFiring = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine)
        {
            return;
        }
        if(other.name.Contains("Beam"))
        {
            return;
        }
        health -= 0.1f;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!photonView.IsMine)
        {
            return;
        }
        if (other.name.Contains("Beam"))
        {
            return;
        }
        health -= 0.1f*Time.deltaTime;
    }
}
