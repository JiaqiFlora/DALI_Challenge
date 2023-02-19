using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMiniMapCameraFoll : MonoBehaviour
{
    public NewMiniMapSetting setting;
    //public float cameraHeight;

    public float secondFloorY;
    public float thirdFloorY;
    public GameObject miniMapCamera;

    private void Awake()
    {
        setting = GetComponentInParent<NewMiniMapSetting>();
        //cameraHeight = transform.position.y - setting.targetToFollow.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = setting.targetToFollow.transform.position;

        if (setting.rotateWithTheTarget)
        {
            Quaternion targetRotation = setting.targetToFollow.transform.rotation;

            transform.rotation = Quaternion.Euler(90, targetRotation.eulerAngles.y, 0);
        }

        // second floor
        if (targetPosition.y >= secondFloorY && targetPosition.y < thirdFloorY)
        {
            Debug.Log("on second floor");
            miniMapCamera.transform.position = transform.parent.position + new Vector3(-364.9f, 64.97f, -175.6f);
            GetComponent<Camera>().orthographicSize = 29f;
            GetComponent<Camera>().nearClipPlane = 53f;
            GetComponent<Camera>().farClipPlane = 57.6f;


        }
        else if (targetPosition.y >= thirdFloorY)
        {
            Debug.Log("on third floor");
            miniMapCamera.transform.position = transform.parent.position + new Vector3(-367.2f, 77.1f, -171.8f);
            GetComponent<Camera>().orthographicSize = 6.7f;
            GetComponent<Camera>().nearClipPlane = 43.1f;
            GetComponent<Camera>().farClipPlane = 56.4f;

        }
        else
        {
            miniMapCamera.transform.position = transform.parent.position + new Vector3(-364.9f, 55.6f, -175.6f);
            GetComponent<Camera>().orthographicSize = 29.5f;
            GetComponent<Camera>().nearClipPlane = 49.8f;
            GetComponent<Camera>().farClipPlane = 59.4f;
        }
    }
}
