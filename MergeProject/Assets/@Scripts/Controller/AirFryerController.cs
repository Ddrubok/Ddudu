using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AirFryerController : StuffController
{
    private void Start()
    {
        CreateFood(FoodType.Potato, Vector3.zero);
    }
}
