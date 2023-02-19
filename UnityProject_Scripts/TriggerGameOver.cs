using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerGameOver : MonoBehaviour
{
    public GameObject player;
    public Transform targetPosition;
    public Transform endPosition;

    private Animator animator;
    private bool gameover = false;
    private bool canIntoCoffin = false;
    private bool hasEnd = false;

    public Animator coffinAnimator;
    public DialogueTrigger dialogueTrigger;
    public GameObject gameoverPage;

    public AudioSource audioSource;
    public CinemachineVirtualCamera cinemachineVirtualCamera;


    private void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    private void Update()
    {

        if (gameover && canIntoCoffin)
        {
            Debug.Log("begin into move update");
            player.transform.position = Vector3.MoveTowards(player.transform.position, endPosition.position, Time.deltaTime * 10);
            return;
        }


        if (gameover)
        {
            animator.SetBool("FreeFall", false);
            animator.SetTrigger("gameover");

            player.GetComponent<Rigidbody>().useGravity = false;
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition.position, Time.deltaTime * 8);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), 0.1f);

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasEnd)
        {
            Debug.Log("game over trigger!");
            StartCoroutine(ChangeCameraAndDialog());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // FIXME: maybe will trigger some bug! or spand the collider 
        Debug.Log("exit!");

        //gameover = false;
        //player.GetComponent<CharacterController>().enabled = true;
    }

    public void GameOver()
    {
        StartCoroutine(coffinAnimation());
    }

    IEnumerator coffinAnimation()
    {
        coffinAnimator.SetTrigger("open");
        yield return new WaitForSeconds(3f);

        audioSource.Play();
        gameover = true;
        animator.SetBool("FreeFall", false);
        animator.SetTrigger("gameover");
        player.GetComponent<CharacterController>().enabled = false;

        Debug.Log("into wait!");
        yield return new WaitForSeconds(2f);
        Debug.Log("Begin into coffin!");
        canIntoCoffin = true;

        yield return new WaitForSeconds(1f);
        coffinAnimator.SetTrigger("close");

        // wait then game over page
        yield return new WaitForSeconds(2.5f);
        gameoverPage.SetActive(true);

    }

    IEnumerator ChangeCameraAndDialog()
    {
        CameraSwithcer.switchCamera(cinemachineVirtualCamera);

        yield return new WaitForSeconds(2.5f);
        dialogueTrigger.TriggerDialogue();
        hasEnd = true;
    }

}
