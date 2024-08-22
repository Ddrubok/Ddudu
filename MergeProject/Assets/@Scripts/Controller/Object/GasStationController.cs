using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GasStationController : CookingAreaController
{

    public override bool Init()
    {
        if (!base.Init())
            return false;

        FoodIcon = transform.GetChild(0).GetComponent<SpriteRenderer>();

        return true;
    }
    protected FoodType FoodType { get; set; }

    protected SpriteRenderer FoodIcon { get; set; }

    
    protected override void CreateFood(Vector3 _pos)
    {
        Managers.Object.Spawn<DeliverableStuffController>(_pos, (int)FoodType);
    }
}
