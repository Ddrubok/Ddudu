using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public class PlayerController : HumanController
{
    Vector3 _moveDir = Vector3.zero;
    [SerializeField]
    GameObject _maxText;

    private OutLineApply _outLineApply;
    public void MaxTextOff()
    {
        _maxText.SetActive(false);
    }
    public void MaxTextPos(float _y)
    {
        _maxText.SetActive(true);
        _maxText.transform.localPosition = Vector3.up * _y;
    }
    public override bool Init()
    {
        if (!base.Init())
            return false;
        Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
        Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;
        Managers.Game.Camera.TargetChange(gameObject);
        Clothing.PlayerInit();
        HumanState = HumanState.SitDown;

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ActionAble")
        {
            if (Managers.Game.go == null)
            {
                Managers.Game.go = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if(Managers.Game.go ==other.gameObject)
        {
            Managers.Game.go = null;
        }
    }
    void HandleOnMoveDirChanged(Vector3 dir)
    {
        _moveDir = dir;
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 dir = new Vector3(_moveDir.x, 0.0f, _moveDir.y) * _speed * Time.deltaTime;
        transform.position += dir;

        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

            agent.velocity = Vector3.forward;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                HumanState = Define.HumanState.Run;
                transform.position += (dir * RunSpeed);
            }
            else
                HumanState = Define.HumanState.Move;

        }
        else
        {
            agent.velocity = Vector3.zero;
            HumanState = Define.HumanState.Idle;
        }

        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void GetMoney(int num = 1)
    {
        Managers.Game.Money += num;
    }

    public override void UpdateController()
    {
        base.UpdateController();

        //MovePlayer();
    }

    void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
    }
}
