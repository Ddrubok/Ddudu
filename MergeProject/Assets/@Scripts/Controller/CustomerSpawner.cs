using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class CustomerSpawner : BaseController
{

    IEnumerator SpawnCustomer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (Managers.Object.Customers.Count >= MaxCustomerCount)
                continue;
            Managers.Object.Spawn<CustomerController>(transform.position);
        }
     
    }
    public override bool Init()
    {
        StartCoroutine(SpawnCustomer());    

        return true;
    }
    public override void UpdateController()
    {
       
    }
}
