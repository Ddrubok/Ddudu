using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public  class StuffController : BaseController
{
    public override bool Init()
    {
        if (!base.Init())
            return false;

        gameObject.tag = "ActionAble";
        return true;
    }

    private void OnTriggerExit(Collider other)
    {
        Managers.Game.ActionButton = false;
    }
}
