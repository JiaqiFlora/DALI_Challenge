using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControllerSwitch : MonoBehaviour
{

    public CinemachineVirtualCamera gameoverCamera;
    public CinemachineFreeLook playerCamera;

    private void OnEnable()
    {
        CameraSwithcer.RegisterCamera(playerCamera);
        CameraSwithcer.RegisterCamera(gameoverCamera);
        CameraSwithcer.switchCamera(playerCamera);
    }

    private void OnDisable()
    {
        CameraSwithcer.UnRegisterCamera(playerCamera);
        CameraSwithcer.UnRegisterCamera(gameoverCamera);
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.O)) {
    //        Debug.Log("key down o!!");
    //        if(CameraSwithcer.isActiveCamera(gameoverCamera))
    //        {
    //            Debug.Log("switch to playerCamera camera");
    //            CameraSwithcer.switchCamera(playerCamera);
    //        } else if (CameraSwithcer.isActiveCamera(playerCamera))
    //        {
    //            Debug.Log("switch to gameoverCamera camera");
    //            CameraSwithcer.switchCamera(gameoverCamera);
    //        }
    //    }
    //}
}
