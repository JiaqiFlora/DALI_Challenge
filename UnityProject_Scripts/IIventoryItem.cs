using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IIventoryItem
{
    string name { get; }

    Sprite image { get; }

    void OnPickUp();

    void OnDrop();
    void OnUse();
}

public class IventoryEventArgs : EventArgs
{

    public IIventoryItem Item;

    public IventoryEventArgs(IIventoryItem item)
    {
        Item = item;
    }
}
