using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : HumanController
{
    public override bool Init()
    {
        if (!base.Init())
            return false;

        Clothing.CustomerRandomInit();
        return true;
    }
}
