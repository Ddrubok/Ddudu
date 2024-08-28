using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public class HumanController : BaseController
{
    [SerializeField]
    private HumanState _humanState = HumanState.Idle;

    private clothing _clothing;

    public clothing Clothing { get { return _clothing; } }

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
    protected float RunSpeed = 1.5f;

    [SerializeField]
    protected Animator _animator;

    protected NavMeshAgent agent;

    public HumanState HumanState
    {
        get { return _humanState; }
        set
        {
            _humanState = value;
            UpdateAnimation();
        }
    }

    public virtual void UpdateAnimation()
    {
        switch (HumanState)
        {
            case HumanState.Idle:
                _animator.Play("idle");
                _animator.SetInteger("arms", 5);
                _animator.SetInteger("legs", 5);
                break;

            case HumanState.Move:
                _animator.Play("walk");
                _animator.SetInteger("arms", 1);
                _animator.SetInteger("legs", 1);
                break;

            case HumanState.Talking:
                _animator.Play("Talking");
                break;

            case HumanState.Run:
                _animator.Play("run");
                _animator.SetInteger("arms", 2);
                _animator.SetInteger("legs", 2);
                break;
        }
    }

    public override bool Init()
    {
        base.Init();
        _animator = GetComponentInChildren<Animator>();
        HumanState = HumanState.Idle;
        agent = GetComponent<NavMeshAgent>();
        _clothing = GetComponent<clothing>();

        return true;
    }

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
