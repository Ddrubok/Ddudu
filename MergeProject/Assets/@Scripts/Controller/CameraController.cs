using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private GameObject Target;
   //private float smoothSpeed = 0.05f;
   //private float threshold = 0.1f;
   //private float yValue = 15.0f;
   // private float zValue = 8.0f;

    private float smoothSpeed = 0.05f;
    private float threshold = 0.1f;
    private float yValue = 10.0f;
    private float zValue = 0;
    void Start()
    {
        Managers.Game.Camera = this;
    }

    public void TargetChange(GameObject _Target)
    {
        Target = _Target;

    }
    void LateUpdate()
    {
        if (Target == null) return;

        Vector3 desiredPosition = new Vector3(Target.transform.position.x, yValue, Target.transform.position.z + zValue);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (Target != Managers.Game.Player)
        {
            if (Vector3.Distance(transform.position, desiredPosition) < threshold)
            {
               Target = Managers.Game.Player.gameObject;
            }
        }
    }

}
