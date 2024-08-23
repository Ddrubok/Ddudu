using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;

public class FoodForFoodTableController : MonoBehaviour
{
    FoodType foodType = FoodType.None;
    
    private SpriteRenderer spriteRenderer;
    int foodNum;
    private TextMeshProUGUI text;

    public void SetFood(FoodType ft,int num)
    {
        if(foodType == FoodType.None)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            text = GetComponent<TextMeshProUGUI>();
            foodNum = num;
            foodType = ft;
            spriteRenderer.sprite = Managers.Object.GetSprite(ft.ToString()+"Icon");
        }
        else
        {
            foodNum += num;
        }

        if (foodNum <= 0)
        {
            foodNum = 0;
            gameObject.SetActive(false);
        }
        else
            gameObject.SetActive(true);


        text.text = foodNum.ToString();
    }
}
