using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IIventoryItem
{
    public virtual string name
    {
        get
        {
            return "Emerald";
        }
    }

    public Sprite _image = null;

    public Sprite image
    {
        get
        {
            return _image;
        }
    }

    public AudioSource audio;

    public virtual void OnPickUp()
    {
        // TODO: logic or animation to pick up!!
        StartCoroutine(playSoundAndDestroy());

    }

    IEnumerator playSoundAndDestroy()
    {
        audio.Play();

        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        Debug.Log("pick up " + name);
    }


    public virtual void OnDrop()
    {
        // TODO: add logic or animation + base class
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log("drop!");
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }

    public virtual void OnUse()
    {

    }
}
