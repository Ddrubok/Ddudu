using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    public class GameManager
    {
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




        #region Action
        public event Action<Vector2> OnMoveDirChanged;
        #endregion
    }
    #endregion
}

