using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class CustomerController : HumanController
{
    [SerializeField]
    private Define.CustomerSituation _customerSituation = Define.CustomerSituation.Paying;

    public bool isArrive { get; private set; } = false;
    public CustomerSituation CustomerSituation
    {
        get { return _customerSituation; }
        set
        {
            _customerSituation = value;
            UpdateSituation();
        }
    }
    public override bool Init()
    {
        if (!base.Init())
            return false;

        Clothing.CustomerRandomInit();

        agent.SetDestination(Managers.Object.CookingAreas["FoodTable"].transform.position);
        return true;
    }

    public override void UpdateController()
    {
        if (IsDestinationReached())
        {
            Debug.Log("목적지에 도착했습니다!");
        }
    }

    private bool IsDestinationReached()
    {
        // 목적지까지의 거리와 정지 거리 비교
        return agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending;
    }

    void UpdateSituation()
    {
        //switch (CustomerSituation)
        //{
        //    case CustomerSituation.Paying:

        //        arriveName = "CheckoutCounter";
        //        MoveToTarger(arriveName, -Vector3.forward * Define.CustomerLength);
        //        break;

        //    case CustomerSituation.WantTable:
        //        arriveName = "Table";
        //        if (Manager.Game.TargetPosition.ContainsKey(arriveName))
        //            MoveToTarger(arriveName, Vector3.right * Define.CustomerLength);
        //        else
        //        {
        //            MoveToPosition(transform.position + (Vector3.left * Define.CustomerWidth));
        //            StartCoroutine(WaitForComponentToSpawn());
        //        }
        //        break;

        //    case CustomerSituation.BackHome:
        //        MoveToPosition(transform.position + (Vector3.right * Define.CustomerWidth));
        //        break;
        //}
    }

    public void OnArriveAtTarget()
    {
        isArrive = true;
        //if (Managers.Game.TargetPosition.ContainsKey(arriveName))
        //    LookAtTarget(Manager.Game.TargetPosition[arriveName].gameObject);

        //switch (CustomerSituation)
        //{
        //    case CustomerSituation.Paying:
        //        if (BreadValue == 1)
        //        {
        //            Manager.Game.TargetPosition[arriveName].RemoveAfterStrangeElement(this);
        //            CustomerSituation = Define.CustomerSituation.WantTable;
        //            BallonSetting(CustomerSituation, BreadValue);
        //        }
        //        break;

        //    case CustomerSituation.BackHome:
        //        arriveName = "CustomerCreateZone";
        //        MoveToTarger(arriveName, Vector3.zero);
        //        GoToTheHome();
        //        break;
        //}
    }

    //public void MoveToTarger(string a, Vector3 v3)
    //{
    //    isArrive = false;
    //    agent.isStopped = false;
    //    bool isset = agent.SetDestination(Managers.Game.TargetPosition[a].SetTargetPosition(this, v3));
    //}

    public void MoveToPosition(Vector3 v3)
    {
        isArrive = false;
        agent.isStopped = false;
        agent.SetDestination(v3);
    }

}
