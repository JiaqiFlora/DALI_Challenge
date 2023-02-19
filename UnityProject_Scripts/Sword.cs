using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : InventoryItemBase
{

    public override string name
    {
        get
        {
            return "Sword";
        }
    }

    public override void OnUse()
    {
        // TODO: do sth. with the object!
        base.OnUse();
    }


}
