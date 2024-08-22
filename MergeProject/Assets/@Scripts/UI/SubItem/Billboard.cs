using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private CameraController cam;
    private void Awake()
    {
        if (cam == null)
            cam = Managers.Game.Camera;
    }

    void Update()
    {
        // 항상 카메라의 위치를 바라보게 한다.
        transform.LookAt(cam.transform.position);
    }
}
