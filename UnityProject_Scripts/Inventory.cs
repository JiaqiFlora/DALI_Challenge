using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 4;

    private List<IIventoryItem> mItems = new List<IIventoryItem>();

    public event EventHandler<IventoryEventArgs> itemAdded;

    public event EventHandler<IventoryEventArgs> itemRemoved;

    public void AddItem(IIventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            // TODO: maybe change to click!!
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickUp();
            }

            if (itemAdded != null)
            {
                itemAdded(this, new IventoryEventArgs(item));
            }
        }
    }

    public int GetCurrentThingsCount()
    {
        Debug.Log("current thing: " + mItems.Count);
        return mItems.Count;
    }

    public void RemoveItem(IIventoryItem item)
    {
        if (mItems.Contains(item))
        {

            mItems.Remove(item);

            item.OnDrop();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider != null)
            {
                collider.enabled = true;
            }

            if (itemRemoved != null)
            {
                itemRemoved(this, new IventoryEventArgs(item));
            }
        }
    }

}
