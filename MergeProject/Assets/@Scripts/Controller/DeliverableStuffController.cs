using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverableStuffController : StuffController
{
    public bool isMoving { get; private set; } = false;
    protected IEnumerator JumpMove(Transform target, float _height, float rowCount = 0, float columnCount = 0, float highCount = 0)
    {

        Vector3 startPoint = transform.position;
        Vector3 endPoint = target.position;

        Vector3 midPoint = (startPoint + endPoint) / 2;
        midPoint.y += _height;


        float t = 0;
        isMoving = true;
        while (t <= 1)
        {
            t += Time.deltaTime * 5.0f;


            Vector3 newPosition = (1 - t) * ((1 - t) * startPoint + t * midPoint) + t * ((1 - t) * midPoint + t * endPoint);

            transform.position = newPosition;

            yield return null;
        }

        transform.SetParent(target);
        transform.localPosition = Vector3.forward * columnCount + Vector3.right * rowCount + Vector3.up * highCount;
        transform.localRotation = Quaternion.identity;
        GetComponent<CapsuleCollider>().enabled = false;
        if (!GetComponent<Rigidbody>().isKinematic)
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().freezeRotation = true;
        isMoving = false;
    }

    public delegate void delegateFunc();
    protected IEnumerator JumpMove(Transform target, float _height, float time, delegateFunc m_func, float rowCount = 0, float columnCount = 0, float highCount = 0)
    {

        Vector3 startPoint = transform.position;
        Vector3 endPoint = target.position;

        Vector3 midPoint = (startPoint + endPoint) / 2;
        midPoint.y += _height;


        float t = 0;
        isMoving = true;
        while (t <= 1)
        {
            t += Time.deltaTime * 5.0f;


            Vector3 newPosition = (1 - t) * ((1 - t) * startPoint + t * midPoint) + t * ((1 - t) * midPoint + t * endPoint);

            transform.position = newPosition;

            yield return null;
        }

        transform.SetParent(target);
        transform.localPosition = Vector3.forward * columnCount + Vector3.right * rowCount + Vector3.up * highCount;
        transform.rotation = Quaternion.identity;
        GetComponent<CapsuleCollider>().enabled = false;
        if (!GetComponent<Rigidbody>().isKinematic)
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().freezeRotation = true;
        isMoving = false;
        yield return new WaitForSeconds(time);
        m_func();
    }

    public void JumpMoveCoroutine(Transform _tr, float _heigh, float rawDistance, float columdistance, float highDistance)
    {
        StartCoroutine(JumpMove(_tr, _heigh, rawDistance, columdistance, highDistance));
    }
}
