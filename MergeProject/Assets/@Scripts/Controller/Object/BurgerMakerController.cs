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
       

        return true;
    }

    public override void UpdateController()
    {
        CreateFood(Vector3.zero);
    }

    protected override void CreateFood(Vector3 _pos)
    {
        // Managers.Object.Spawn<DeliverableStuffController>(_pos, (int)FoodType);

        Managers.Game.changeFood(FoodType.Burger);
    }
}
