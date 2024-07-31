using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : HumanController
{
    Vector3 _moveDir = Vector3.zero;
    [SerializeField]
    GameObject _maxText;
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
        base.Init();
        Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;
        Managers.Game.Camera.TargetChange(gameObject);
        return true;
    }

    void HandleOnMoveDirChanged(Vector3 dir)
    {
        _moveDir = dir;
    }

    void MovePlayer()
    {
        Vector3 dir = _moveDir * _speed * Time.deltaTime;
        transform.position += dir;

        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

            agent.velocity = Vector3.forward;
            //   HumanState = Define.HumanState.Move;
        }
        else
        {
            agent.velocity = Vector3.zero;
            // HumanState = Define.HumanState.Idle;
        }

        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public override void UpdateController()
    {
        base.UpdateController();

        MovePlayer();
    }

    void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
    }
}
