using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;

public class StuffLockController : StuffController
{
    [field: SerializeField]
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

        return true;
    }

    public void setLockObject(CookingAreaType type)
    {
        Type = type;
        LockMoney = 100;
    }

    public override void UpdateController()
    {
        //PayForUnlock();
    }

    public void PayForUnlock()
    {
        if(Managers.Game.Money>0)
        {
            LockMoney--;
            Managers.Game.Money--;
        }
        
    }

    void CreateCookingArea()
    {
        Managers.Object.Spawn<CookingAreaController>(Vector3.zero, (int)Type);

        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other !=null|| other.GetComponent<PlayerController>()==other)
        {
            PayForUnlock();
        }
    }
}
