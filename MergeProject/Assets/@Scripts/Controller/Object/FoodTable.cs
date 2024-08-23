using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class FoodTable : StuffController
{
    List<FoodForFoodTableController> foods= new List<FoodForFoodTableController>();

    public override bool Init()
    {
        if(!base.Init())
            return false;

        for(FoodType i =0; i< FoodType.None-1;i++)
        {
            FoodForFoodTableController controller = transform.GetChild(0).GetChild((int)i).GetComponent<FoodForFoodTableController>();

            controller.SetFood(i);
            controller.gameObject.SetActive(true);
        }

        return true;
    }

}
