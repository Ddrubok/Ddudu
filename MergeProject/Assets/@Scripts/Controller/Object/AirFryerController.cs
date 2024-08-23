using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AirFryerController : CookingAreaController
{
    protected override void CreateFood( Vector3 _pos )
    {
        //Managers.Object.Spawn<DeliverableStuffController>(_pos, (int)FoodType.Potato);
        //SetOutLine();

        Managers.Game.changeFood(1, FoodType.Potato);
        
    }


    public override void UpdateController()
    {
        CreateFood(Vector3.zero);
    }
}
