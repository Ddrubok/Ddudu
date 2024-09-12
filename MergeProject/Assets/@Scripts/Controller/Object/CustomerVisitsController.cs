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
        // VisitCustomer ť�� �ִ� ���� ��ġ�� ����
        int index = 0;
        foreach (var customer in VisitCustomer)
        {
            Vector3 newPosition = new Vector3(0, 0, index * Define.CustomerSpacing); // Define.CustomerSpacing�� �� ���� ����
            customer.transform.position = newPosition;
            index++;
        }
    }

    public void AddCustomerToOnWay(CustomerController customer)
    {
       
        // ���� ���� ����
        Vector3 destination = GetDestinationForCustomer();
        customer.MoveToTarget(name, destination);
        OnWayCustomer.Enqueue(customer);
    }

    public void CustomerArrived(CustomerController customer)
    {
        if (OnWayCustomer.Contains(customer))
        {
            // OnWayCustomer ť���� ����
            OnWayCustomer.Dequeue();
            // VisitCustomer ť�� �߰�
            VisitCustomer.Enqueue(customer);
            customer.OnArriveAtTarget(); // ���� ó��
        }
    }

    private Vector3 GetDestinationForCustomer()
    {
        // VisitCustomer ť�� ũ��(���� ��� ���� �� ��)�� ���� ���� ���� ���
        int waitingCount = VisitCustomer.Count;
        Vector3 baseDestination = new Vector3(0, 0, waitingCount * Define.CustomerSpacing); // ��� �� �� ���� ���� ��ġ ����
        return baseDestination;
    }
}
