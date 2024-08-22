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
        //transform.LookAt(cam.transform.position);


        // 카메라의 위치를 바라보되 Y축 회전은 하지 않도록 설정
        Vector3 lookDirection = cam.transform.position - transform.position; // 카메라 방향 벡터
        lookDirection.y = 0; // Y축 회전 방지

        // 새로운 회전값을 계산
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = rotation; // 회전 적용
    }
}
