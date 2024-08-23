using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public enum ObjectType
    {
        Player,
        Consumer,
        Stuff,
    }

    public enum FoodType
    {
        Potato,
        Burger,
        Hotdog,
        Coke,

        None

    }

    public enum CookingAreaType
    {
        AirFryer,
        DrinkMachine,
        BurgerStove,
        HotdogStove,
        FoodTable,


    }

    public enum HumanState
    {
        Idle,
        Move,
        Talking,
        BackHome,
        Run
    }

    public enum StuffType
    {
        None,
    }

    public enum CustomerSituation
    {
        BreadPick,
        Paying,
        WantTable,
        BackHome,
    }

    public enum PaperBagState
    {
        Appear,
        Close
    }

    public static float CroassantSpeed = 104.0f;
    public static float OvenTime = 1.0f;
    public static int MaxBread = 8;

    public static float StuffHeight = 5.0f;

    public static float StackingHeight = 0.3f;

    public static int minCustomerBreadValue = 2;
    public static int maxCustomerBreadValue = 5;
    public static int MaxCustomerCount = 3;

    public static float sellBreadX = -0.8f;

    public static int BreadValue = 5;

    public static float CustomerLength = 1.5f;
    public static float CustomerWidth = 3.0f;

    public static int TableBreadValue = 2;
    public enum EScene
    {
        TitleScene,
        GameScene,
        Unknown,
    }

    public enum EUIEvent
    {
        Click,
        PointerDown,
        PointerUp,
        Drag,
    }

    public enum ESound
    {
        Bgm,
        Effect,
        Max,
    }

}
