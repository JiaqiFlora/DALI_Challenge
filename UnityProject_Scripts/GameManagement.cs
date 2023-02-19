using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{

    public static GameManagement instance { get; private set; }

    public Animator animator;
    public float transitionTime = 2f;

    [Header("canvas control")]
    public Canvas miniMapCanvas;
    public Canvas inventoryCanvas;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        disableScreenCanvas();
        StartCoroutine(CanvasAppear());
    }

    IEnumerator CanvasAppear()
    {
        yield return new WaitForSeconds(transitionTime);
        enableScreenCanvas();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restartGame()
    {
        
        Debug.Log("restart game!");
        StartCoroutine(restartGameAnimation());
    }

    IEnumerator restartGameAnimation()
    {
        animator.SetTrigger("recwipe");
        disableScreenCanvas();

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    void enableScreenCanvas()
    {
        Debug.Log("enable canvas!");
        miniMapCanvas.enabled = true;
        inventoryCanvas.enabled = true;
    }

    void disableScreenCanvas()
    {
        miniMapCanvas.enabled = false;
        inventoryCanvas.enabled = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }


}
