using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // initialize offset based on starting position of player and camera
        offset = this.transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // convert offset position of camera to world space
        transform.position = player.TransformPoint(offset);

        // set the camera rotation to orient toward player
        transform.LookAt(player);
        //transform.Rotate(new Vector3(-27f, 0, 0));
    }
}

