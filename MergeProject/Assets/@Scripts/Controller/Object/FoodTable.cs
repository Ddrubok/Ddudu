using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using static GameSaveData;

public class FoodTable : StuffController
{
    List<FoodForFoodTableController> foods= new List<FoodForFoodTableController>();

    public override bool Init()
    {
        if(!base.Init())
            return false;

        Managers.Game.OnPlusFoodChanged += HandleOnFoodChanged;

        for (FoodType i =0; i< FoodType.None-1;i++)
        {
            FoodForFoodTableController controller = transform.GetChild(0).GetChild((int)i).GetComponent<FoodForFoodTableController>();

            controller.SetFood(i,0);
           // controller.gameObject.SetActive(false);
            foods.Add(controller);  
        }

        return true;
    }


    void HandleOnFoodChanged(FoodTableData ftd)
    {
        foods[(int)ftd.type].SetFood(ftd.type, ftd.num);
    }

    private void OnDestroy()
    {
        Managers.Game.OnPlusFoodChanged -= HandleOnFoodChanged;
    }

}
