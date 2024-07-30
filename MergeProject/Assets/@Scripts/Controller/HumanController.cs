using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : BaseController
{
    //[SerializeField]
    //private Define.HumanState _humanState = Define.HumanState.Idle;

    //[SerializeField]
    //Transform _breadTransform;
    //public Transform BreadPos
    //{
    //    get { return _breadTransform; }
    //}

    //Stack<CroassantController> _bread = new Stack<CroassantController>();

    //public Stack<CroassantController> Bread
    //{
    //    get { return _bread; }
    //}

    protected float _speed = 3.0f;
    protected float _rotationSpeed = 10.0f;

    //protected Animator _animator;

    protected NavMeshAgent agent;

    //public Define.HumanState HumanState
    //{
    //    get { return _humanState; }
    //    set
    //    {
    //        _humanState = value;
    //        UpdateAnimation();
    //    }
    //}

    //public virtual void UpdateAnimation()
    //{
    //    switch (HumanState)
    //    {
    //        case Define.HumanState.Idle:
    //            _animator.Play("Idle");
    //            break;

    //        case Define.HumanState.Move:
    //            _animator.Play("Move");
    //            break;

    //        case Define.HumanState.Talking:
    //            _animator.Play("Talking");
    //            break;
    //    }
    //}

    //public override bool Init()
    //{
    //    base.Init();
    //    _animator = GetComponentInChildren<Animator>();
    //    HumanState = Define.HumanState.Idle;
    //    agent = GetComponent<NavMeshAgent>();

    //    return true;
    //}

    //protected bool _talking = false;

    //public bool IsTalking
    //{
    //    get
    //    {
    //        return _talking;
    //    }
    //    set
    //    {
    //        _talking = value;
    //    }
    //}

    //public override void UpdateController()
    //{
    //    base.UpdateController();

    //    if (agent.velocity.magnitude > 0)
    //        HumanState = Define.HumanState.Move;
    //    else
    //    {
    //        if (_talking)
    //            HumanState = Define.HumanState.Talking;
    //        else
    //            HumanState = Define.HumanState.Idle;
    //    }


    //}

    //public  bool GetBread(CroassantController cc)
    //{
    //    if (_bread.Count >= Define.MaxBread)
    //        return false;

    //    Bread.Push(cc);
    //    return true;
    //}

    //public bool GetBread(CroassantController cc, int maxCount)
    //{
    //    if (_bread.Count >= maxCount)
    //        return false;

    //    Bread.Push(cc);
    //    return true;
    //}

    public void LookAtTarget(GameObject go)
    {
        Vector3 direction = (go.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }
}
