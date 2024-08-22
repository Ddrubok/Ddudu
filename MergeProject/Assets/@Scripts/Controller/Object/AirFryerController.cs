using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AirFryerController : CookingAreaController
{
    private void Start()
    {
        CreateFood( Vector3.zero);
    }
    protected override void CreateFood( Vector3 _pos)
    {
        Managers.Object.Spawn<DeliverableStuffController>(_pos, (int)FoodType.Potato);
        SetOutLine();
    }

}
