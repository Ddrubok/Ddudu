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

        return true;
    }

    public override void UpdateController()
    {
        CreateFood(Vector3.zero);
    }


    protected override void CreateFood(Vector3 _pos)
    {
        // Managers.Object.Spawn<DeliverableStuffController>(_pos, (int)FoodType);

        Managers.Game.changeFood(FoodType.Hotdog);
    }
}
