using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class DrinkMachineController : CookingAreaController
{

    public override bool Init()
    {
        if (!base.Init())
            return false;

        CreateFood(Vector3.zero);

        return true;
    }
    protected override void CreateFood(Vector3 _pos)
    {
        Managers.Object.Spawn<DeliverableStuffController>(_pos, (int)FoodType.Coke);
    }
}
