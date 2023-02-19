using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InventoryItemBase
{
    public override string name
    {
        get
        {
            return "Key";
        }
    }

    public override void OnUse()
    {
        // TODO: do sth. with the object!
        base.OnUse();
    }

}
