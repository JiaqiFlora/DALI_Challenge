using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAppearControl : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModelAppear()
    {
        Debug.Log("ganjiaqi:------- model appear!");
        animator.SetTrigger("appear");
    }

    public void ModelDisappear()
    {
        Debug.Log("ganjaiqi:----- model disappear");
        animator.SetTrigger("return");
    }
}
