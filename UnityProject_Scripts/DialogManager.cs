using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float textSpeed;

    public GameObject dialogBox;
    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject coffinIcon;
    public GameObject coinsIcon;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DispalyNextSentence();

    }

    private void Update()
    {
        if (dialogBox.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            DispalyNextSentence();
        }
    }

    public void DispalyNextSentence()
    {
        if (sentences.Count == 1)
        {
            continueButton.SetActive(false);
            yesButton.SetActive(true);
            noButton.SetActive(true);

            coffinIcon.SetActive(true);
            coinsIcon.SetActive(false);
        }

        if (sentences.Count == 0)
        {
            //EndDialogue();
            return;
        }

        dialogBox.SetActive(true);
        string sentence = sentences.Dequeue();
        Debug.Log("now: " + sentence);

        // TODO: check if the sentence is not complete!
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void EndDialogue()
    {
        Debug.Log("end of conversation!");
        dialogBox.SetActive(false);
    }

}
