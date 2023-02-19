using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{

    public Inventory inventory;

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("drop item");
            //IIventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().item;

            //if(item != null)
            //{
            //    inventory.RemoveItem(item);
            //}
            
        }
    }

}
