using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [SerializeField] private WorldManager worldManager = null;
    [SerializeField] private PlayerManager playerManager = null;

    private FollowCamera followCamera = null;

    private void Awake()
    {
        Debug.Assert(playerManager, "PlayerManager is Null !!");
        Debug.Assert(worldManager, "WorldManager is Null !!");

        if(!followCamera)
            followCamera = Camera.main.GetComponent<FollowCamera>();

        Debug.Assert(followCamera, "FollowCamera is Null !!");
    }

    private void Start()
    {
        followCamera.StartFollow(playerManager.transform);
    }
}
