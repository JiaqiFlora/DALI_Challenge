using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwithcer
{
    static List<CinemachineVirtualCameraBase> cameras = new List<CinemachineVirtualCameraBase>();

    public static CinemachineVirtualCameraBase activeCamera = null;

    public static bool isActiveCamera(CinemachineVirtualCameraBase camera)
    {
        return camera == activeCamera;
    }

    public static void switchCamera(CinemachineVirtualCameraBase camera)
    {
        camera.Priority = 10;
        activeCamera = camera;

        foreach(CinemachineVirtualCameraBase cameraBase in cameras)
        {
            if (cameraBase != camera && camera.Priority != 0)
            {
                Debug.Log("set to 0!!");
                cameraBase.Priority = 0;
            }

        }
    }

    public static void RegisterCamera(CinemachineVirtualCameraBase camera)
    {
        cameras.Add(camera);
        Debug.Log("register camera" + camera);
    }

    public static void UnRegisterCamera(CinemachineVirtualCameraBase camera)
    {
        cameras.Remove(camera);
        Debug.Log("unregister camera" + camera);
    }


}
