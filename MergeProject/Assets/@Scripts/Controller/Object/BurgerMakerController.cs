using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class BurgerMakerController : GasStationController
{
    public override bool Init()
    {
        if (!base.Init())
            return false;

        FoodType = FoodType.Burger;

        FoodIcon.sprite = Managers.Object.GetSprite("BurgerIcon");

        CreateFood(Vector3.zero);

        return true;
    }
}
