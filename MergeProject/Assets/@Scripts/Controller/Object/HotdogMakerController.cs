using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class HotdogMakerController : GasStationController
{
    public override bool Init()
    {
        if (!base.Init())
            return false;

        FoodType = FoodType.Hotdog;

        FoodIcon.sprite = Managers.Object.GetSprite("HotdogIcon");

        FoodIcon.gameObject.AddComponent<SpriteOutline>();

       

        CreateFood(Vector3.zero);

        return true;
    }

}
