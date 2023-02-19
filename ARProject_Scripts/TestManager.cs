using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;
using TMPro;

public class TestManager : MonoBehaviour
{
    public GameObject wordPanel;
    public GameObject wordSlot;

    public AudioSource correctAudio;
    public AudioSource wrongAudio;
    public GameObject correctMark;
    public GameObject congradsPanel;

    public GameObject explodeEffect;


    bool curIsTest = false;
    bool hasSetList = false;
    string hitObjectName;

    List<string> testItems = new List<string>();
    string curTestItem = "";
    List<GameObject> currentTrackedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // find current tracked items for test
        // condition: 1. current mode is test && 2. test list has not been set!
        if (curIsTest && (this.hasSetList == false))
        {
            this.testItems.Clear();
            IEnumerable<ObserverBehaviour> activeTrackables = VuforiaBehaviour.Instance.World.GetTrackedObserverBehaviours();
            
            foreach (ObserverBehaviour behaviour in activeTrackables)
            {
                // if current behavior is ARCamera, just continue
                if (behaviour.name == "ARCamera")
                {
                    continue;
                }
                
                currentTrackedObjects.Add(behaviour.gameObject);
                int index = behaviour.name.IndexOf("Target");
                string objectName = behaviour.name.Substring(0, index);
                this.testItems.Add(objectName);

            }

            this.hasSetList = true;

            CleanAllCaption();
            Shuffle(testItems);
            updateTestWord();
        }

        // test touch item
        // condition: 1. current mode is test && 2. test list is set && 3. touch begin!
        if (curIsTest && hasSetList && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                hitObjectName = hit.transform.name;

                if (hitObjectName == curTestItem)
                {
                    ClickOnRightItem(hitObject);
                } else
                {
                    ClickOnWrongItem(hitObject);
                    
                }
            }
        }
    }

    public void OnClickTestMode()
    {
        curIsTest = true;
        hasSetList = false;
        wordPanel.SetActive(true);

        CleanAllCaption();
    }

    public void OnClickLearnMode()
    {
        curIsTest = false;
        hasSetList = false;
        wordPanel.SetActive(false);

        RecoverAllCaption();

    }

    void CleanAllCaption()
    { 
        foreach (GameObject trackedObject in currentTrackedObjects)
        {
            Transform[] childrenObjects = trackedObject.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (Transform child in childrenObjects)
            {
                if (child.gameObject.tag == "caption_ch")
                {
                    child.gameObject.SetActive(false);
                }
                if (child.gameObject.tag == "caption_en")
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

    }

    void RecoverAllCaption()
    {
        foreach(GameObject trackedObject in currentTrackedObjects)
        {
            Transform[] childrenObjects = trackedObject.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (Transform child in childrenObjects)
            {
                if (child.gameObject.tag == "caption_en")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    void ClickOnRightItem(GameObject model)
    {
        correctMark.SetActive(true);
        correctAudio.Play();
        Instantiate(explodeEffect, model.transform.position, Quaternion.identity);

        StartCoroutine(SelectRight());
    }

    void ClickOnWrongItem(GameObject model)
    {
        wrongAudio.Play();
        model.GetComponent<Animator>().SetTrigger("wrong");
    }

    IEnumerator SelectRight()
    {
        yield return new WaitForSeconds(1.5f);
        updateTestWord();
        correctMark.SetActive(false);

    }

    void updateTestWord()
    {
        // check if testItems list is empty
        if(testItems.Count == 0)
        {
            wordPanel.SetActive(false);
            congradsPanel.SetActive(true);
            curIsTest = false;
            hasSetList = false;
            StartCoroutine(CongradsProcess());
            return;
        }
       
        // After shuffle string array, we can directly use the last word as our test word
        curTestItem = testItems[testItems.Count - 1];
        wordSlot.GetComponent<TMP_Text>().text = curTestItem;
        testItems.RemoveAt(testItems.Count - 1);
    }

    IEnumerator CongradsProcess()
    {
        yield return new WaitForSeconds(2f);

        // After congrats, enter back to learn mode
        congradsPanel.SetActive(false);
        OnClickLearnMode();
    }

    void Shuffle(List<string> list)
    {
        System.Random rnd = new System.Random();
        int n = list.Count;

        while(n > 1)
        {
            --n;
            int k = rnd.Next(n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
