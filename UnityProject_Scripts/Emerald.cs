using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : InventoryItemBase
{

    public override string name
    {
        get
        {
            return "Emerald";
        }
    }

    public override void OnUse()
    {
        // TODO: do sth. with the object!
        base.OnUse();
    }


}
