using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class StuffController : BaseController
{
    protected void CreateFood(FoodType _food, Vector3 _pos)
    {
        Managers.Object.Spawn<DeliverableStuffController>(_pos,(int)_food);
    }
}
