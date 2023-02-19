using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    public GameObject MessagePanel;

    // Start is called before the first frame update
    void Start()
    {
        inventory.itemAdded += InventoryScript_ItemAdded;
        inventory.itemRemoved += InventoryScript_ItemRemoved;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InventoryScript_ItemAdded(object sender, IventoryEventArgs e)
    {

        foreach(Transform slot in transform)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();


            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.image;

                itemDragHandler.item = e.Item;

                break;
            }
        }
    }

    private void InventoryScript_ItemRemoved(object sender, IventoryEventArgs e)
    {
        foreach (Transform slot in transform)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if (itemDragHandler.item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.item = null;

                break;

            }
        }
    }

    public void OpenMessagePanel(string text = null)
    {
        MessagePanel.SetActive(true);

        // TODO: set text when we will use it for other message
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
