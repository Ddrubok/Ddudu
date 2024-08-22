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
        //transform.LookAt(cam.transform.position);


        // ī�޶��� ��ġ�� �ٶ󺸵� Y�� ȸ���� ���� �ʵ��� ����
        Vector3 lookDirection = cam.transform.position - transform.position; // ī�޶� ���� ����
        lookDirection.y = 0; // Y�� ȸ�� ����

        // ���ο� ȸ������ ���
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = rotation; // ȸ�� ����
    }
}
