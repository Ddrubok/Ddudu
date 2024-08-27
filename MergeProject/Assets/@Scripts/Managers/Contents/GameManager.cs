using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using static Define;
using static UnityEngine.Rendering.DebugUI;
using Random = UnityEngine.Random;

[Serializable]
public class GameSaveData
{
    public int Wood = 0;
    public int Mineral = 0;
    public int Meat = 0;
    public int Gold = 0;

    public int ItemDbIdGenerator = 1;
    public List<ItemSaveData> Items = new List<ItemSaveData>();

    //[Serializable]
    //public class HeroSaveData
    //{
    //    public int DataId = 0;
    //    public int Level = 1;
    //    public int Exp = 0;
    //    public EHeroOwningState OwningState = EHeroOwningState.Unowned;
    //}


    [Serializable]
    public class ItemSaveData
    {
        public int InstanceId;
        public int DbId;
        public int TemplateId;
        public int Count;
        public int EquipSlot; // 장착 + 인벤 + 창고
        public int EnchantCount;
    }

    public class FoodTableData
    {
        public FoodTableData(int n, FoodType ft)
        {
            type = ft;
            num = n;
        }
        public int num = 0;
        public FoodType type = FoodType.None;
    }

    public class GameManager
    {

        private CameraController _camera;
        public CameraController Camera { get { return _camera; } set { _camera = value; } }

        public PlayerController Player { get { return Managers.Object?.Player; } }
        #region GameData
        GameSaveData _saveData = new GameSaveData();
        public GameSaveData SaveData { get { return _saveData; } set { _saveData = value; } }

        public int GenerateItemDbId()
        {
            int itemDbId = _saveData.ItemDbIdGenerator;
            _saveData.ItemDbIdGenerator++;
            return itemDbId;
        }

        #endregion

        #region Hero
        private Vector2 _moveDir;
        public Vector2 MoveDir
        {
            get { return _moveDir; }
            set
            {
                _moveDir = value;
                OnMoveDirChanged?.Invoke(value);
            }
        }

        //private Define.EJoystickState _joystickState;
        //public Define.EJoystickState JoystickState
        //{
        //    get { return _joystickState; }
        //    set
        //    {
        //        _joystickState = value;
        //        OnJoystickStateChanged?.Invoke(_joystickState);
        //    }
        //}
        //#endregion

        #region FoodChange
        FoodTableData _changeFoodType = new FoodTableData(0, FoodType.None);

        public FoodTableData ChangeFoodType
        {
            get { return _changeFoodType; }
            set
            {
                _changeFoodType = value;
                OnPlusFoodChanged?.Invoke(value);
            }
        }

        public void changeFood(FoodType ft, int num = 1)
        {
            ChangeFoodType = new FoodTableData(num, ft);
        }

        public event Action<FoodTableData> OnPlusFoodChanged;
        #endregion

        #region Action
        public event Action<Vector3> OnMoveDirChanged;
        #endregion


        #region Money

        private int _money;

        public int Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                OnMoneyChanged?.Invoke(_money);
            }
        }

        public event Action<int> OnMoneyChanged;

        #endregion
    }
    #endregion

}

