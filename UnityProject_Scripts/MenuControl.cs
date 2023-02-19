using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public Animator animator;


    public void PlayGame()
    {
        Debug.Log("play!!");
        animator.SetTrigger("play");
        StartCoroutine(StartPlay());
       
    }

    IEnumerator StartPlay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("AllScene_v0", LoadSceneMode.Single);
    }
}
