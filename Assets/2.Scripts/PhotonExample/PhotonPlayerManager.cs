using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonPlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{

    [SerializeField] GameObject beams;
    public float health = 1f;
    public static GameObject LocalPlayerInstance;
    bool isFiring;

    private void Awake()
    {
        if(beams != null)
        {
            beams.SetActive(false);
        }

        if(photonView.IsMine)
        {
            PhotonPlayerManager.LocalPlayerInstance = this.gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        Photon.Pun.Demo.PunBasics.CameraWork cameraWork = this.gameObject.GetComponent<Photon.Pun.Demo.PunBasics.CameraWork>();
        
        if(cameraWork != null)
        {
            if(photonView.IsMine)
            {
                cameraWork.OnStartFollowing();
            }
        }

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += (scene, loadingMode) =>
        {
            this.CalledOnLevelWasLoaded(scene.buildIndex);
        };

    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            ProcessInputs();
        }
        
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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(isFiring);
            stream.SendNext(health);
        }
        else
        {
            this.isFiring = (bool)stream.ReceiveNext();
            this.health = (float)stream.ReceiveNext();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        this.CalledOnLevelWasLoaded(level);
    }


    void CalledOnLevelWasLoaded(int level)
    {
        // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
        if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
        {
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }
}
