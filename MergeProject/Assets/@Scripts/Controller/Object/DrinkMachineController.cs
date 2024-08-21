using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class DrinkMachineController : CookingAreaController
{
    protected override void CreateFood(Vector3 _pos)
    {
        Managers.Object.Spawn<DeliverableStuffController>(_pos, (int)FoodType.Coke);

        
    }
}
