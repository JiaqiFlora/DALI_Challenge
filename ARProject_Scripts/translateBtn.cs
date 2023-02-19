using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Vuforia;
using Debug = UnityEngine.Debug;

public class translateBtn : MonoBehaviour
{
    public GameObject chineseText;
    public GameObject englishText;
    public VirtualButtonBehaviour translateButton;
    public AudioSource audioSource;

    public bool isEnglish = true;

    // Start is called before the first frame update
    void Start()
    {
        translateButton.RegisterOnButtonPressed(OnButtonPressed);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        audioSource.Play();
        if(!isEnglish)
        {
            chineseText.GetComponent<Animator>().SetTrigger("disappear");
            englishText.GetComponent<Animator>().SetTrigger("appear");

            isEnglish = true;

        } else
        {
            chineseText.GetComponent<Animator>().SetTrigger("appear");
            englishText.GetComponent<Animator>().SetTrigger("disappear");

            isEnglish = false;
        }

    }

    



}
