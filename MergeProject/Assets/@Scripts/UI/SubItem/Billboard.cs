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
        // �׻� ī�޶��� ��ġ�� �ٶ󺸰� �Ѵ�.
        transform.LookAt(cam.transform.position);
    }
}
