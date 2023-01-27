using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.LookAt = playerTransform;
        vcam.Follow = playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTransform)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
            vcam = GetComponent<CinemachineVirtualCamera>();
            vcam.LookAt = playerTransform;
            vcam.Follow = playerTransform;
        }
    }
}
