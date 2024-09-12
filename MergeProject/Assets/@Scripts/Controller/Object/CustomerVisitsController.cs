using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerVisitsController : BaseController
{
    Queue<CustomerController> OnWayCustomer = new Queue<CustomerController>();
    Queue<CustomerController> VisitCustomer = new Queue<CustomerController>();
    string name = new string("asd");

    public override void UpdateController()
    {
        HandleVisitQueue();
    }
    private void HandleVisitQueue()
    {
        // VisitCustomer 큐에 있는 고객의 위치를 조정
        int index = 0;
        foreach (var customer in VisitCustomer)
        {
            Vector3 newPosition = new Vector3(0, 0, index * Define.CustomerSpacing); // Define.CustomerSpacing은 고객 간의 간격
            customer.transform.position = newPosition;
            index++;
        }
    }

    public void AddCustomerToOnWay(CustomerController customer)
    {
       
        // 도착 지점 설정
        Vector3 destination = GetDestinationForCustomer();
        customer.MoveToTarget(name, destination);
        OnWayCustomer.Enqueue(customer);
    }

    public void CustomerArrived(CustomerController customer)
    {
        if (OnWayCustomer.Contains(customer))
        {
            // OnWayCustomer 큐에서 제거
            OnWayCustomer.Dequeue();
            // VisitCustomer 큐에 추가
            VisitCustomer.Enqueue(customer);
            customer.OnArriveAtTarget(); // 도착 처리
        }
    }

    private Vector3 GetDestinationForCustomer()
    {
        // VisitCustomer 큐의 크기(현재 대기 중인 고객 수)에 따라 도착 지점 계산
        int waitingCount = VisitCustomer.Count;
        Vector3 baseDestination = new Vector3(0, 0, waitingCount * Define.CustomerSpacing); // 대기 중 고객 수에 따라 위치 변경
        return baseDestination;
    }
}
