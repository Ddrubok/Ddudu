using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;

public class FoodForFoodTableController : MonoBehaviour
{
    FoodType foodType = FoodType.None;
    
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI text;

    private void Awake()
    {
        
    }
   

    public void SetFood(FoodType ft)
    {
        if(foodType == FoodType.None)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            text = GetComponent<TextMeshProUGUI>();
            foodType = ft;

            spriteRenderer.sprite = Managers.Object.GetSprite(ft.ToString()+"Icon");

            text.text = "12";
        }
        else
        {
            text.text = text.text + '1';
        }

       
    }

   
}
