using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class StuffLockController : StuffController
{
    [field: SerializeField]
    CookingAreaType Type { get; set; } = CookingAreaType.None;

    private int _lockMoney;
    private bool Once;

    private bool CanIUnLock = false;

   private SpriteOutlineApply _spriteOutlineApply;
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
    private TextMeshProUGUI text;

    public override bool Init()
    {
        if (!base.Init())
            return false;
        Once = false;

        _spriteOutlineApply = gameObject.AddComponent<SpriteOutlineApply>();
        _spriteOutlineApply.OutLineOff();
        return true;
    }

    public void setLockObject(CookingAreaType type)
    {
        Type = type;
        LockMoney = 100;
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

    IEnumerator MoneyCheckUnlock()
    {
        if(CanIUnLock)
        {
            Once = true;

            while(_lockMoney>0)
            {
                PayForUnlock();
                yield return new WaitForSeconds(0.01f);
            }
          
        }
        else
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LockMoney <= Managers.Game.Money)
        {
            CanIUnLock = true;
        }
        else CanIUnLock = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.GetComponent<PlayerController>() != null&&Managers.Game.ActionButton&&!Once)
        {
            StartCoroutine(MoneyCheckUnlock());
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CanIUnLock = false;
        Managers.Game.ActionButton = false;
    }

}
