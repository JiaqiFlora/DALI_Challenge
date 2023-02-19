using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ColliderToEndGame : MonoBehaviour
{
    public CinemachineVirtualCamera gameoverCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CameraSwithcer.switchCamera(gameoverCamera);
        }
    }
}
