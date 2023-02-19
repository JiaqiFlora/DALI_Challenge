using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpStairsCheck : MonoBehaviour
{

    public GameObject player;
    public Animator animator;
    public int needToReach = 4;
    public GameObject enemies;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("trigger check collider");
            if (player.GetComponent<PlayerController>().inventory.GetCurrentThingsCount() >= needToReach)
            {
                // TODO: here to go upstairs, or change camera, light up!!!
                Debug.Log("REACH 4!!");
                enemies.SetActive(false);
                Destroy(this);
                this.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                // TODO: here to deny user to go upstairs
                animator.SetTrigger("TipCollect");

            }
        }
    }
}
