using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;

public class StuffLockController : StuffController
{
    CookingAreaType Type { get; set; } = CookingAreaType.None;

    private int _lockMoney;

    int LockMoney
    {
        get { return _lockMoney; }
        set
        {
            _lockMoney = value;
            if (_lockMoney > 0)
                text.text = _lockMoney.ToString();
            else
            {
                CreateCookingArea();
                Debug.Log("boooooooom");
            }
              
        }
    }

    [SerializeField]
    TextMeshProUGUI text;

    public override bool Init()
    {
        if (!base.Init())
            return false;

        LockMoney = 100;

        Type = CookingAreaType.HotdogStove;

        return true;
    }

    public override void UpdateController()
    {
        LockMoney--;
    }

    void CreateCookingArea()
    {
        Managers.Object.Spawn<CookingAreaController>(transform.position, (int)Type);

        Destroy(gameObject);
    }

}
