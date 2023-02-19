using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTrigger : MonoBehaviour
{
    public GameObject player;
    public Transform targetPoint;

    private bool enter;


    // Start is called before the first frame update
    void Start()
    {
        enter = false;
        player.GetComponent<CharacterController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enter)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPoint.position, Time.deltaTime * 2);
            Debug.Log("move!");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collide");
            //other.transform.Translate(Vector3.up * 5 * Time.deltaTime);
            enter = true;
            player.GetComponent<CharacterController>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        enter = false;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
