using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : InventoryItemBase
{
    public override string name
    {
        get
        {
            return "Crystal";
        }
    }

    public override void OnUse()
    {
        // TODO: do sth. with the object!
        base.OnUse();
    }
}
