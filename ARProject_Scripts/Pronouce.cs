using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Vuforia;

public class Pronouce : MonoBehaviour
{
    public GameObject englishText;
    public AudioSource audio_ch;
    public AudioSource audio_en;
    public VirtualButtonBehaviour pronounceButton;

    // Start is called before the first frame update
    void Start()
    {
        pronounceButton.RegisterOnButtonPressed(OnButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (this.GetComponent<translateBtn>().isEnglish)
        {
            Debug.Log("ganjiaqi:----- english play!");
            audio_en.Play();
        }
        else
        {
            Debug.Log("ganjiaqi:----- chinese play!");
            audio_ch.Play();
        }

    }
}
