using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : BaseController
{

    IEnumerator SpawnCustomer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);
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
