using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSelect : MonoBehaviour
{
    public TriggerGameOver triggerGameOver;
    public DialogManager dialogManager;

    public void SelectYes()
    {
        // TODO: animation for it disappear
        dialogManager.EndDialogue();
        triggerGameOver.GameOver();
    }

    // TODO for no
    public void SelectNo()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SelectYes();
        } else if (Input.GetKeyDown(KeyCode.N))
        {
            SelectNo();
        }
    }
}
