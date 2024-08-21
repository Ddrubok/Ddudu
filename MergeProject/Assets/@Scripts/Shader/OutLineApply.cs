using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineApply : MonoBehaviour
{
    private Material instanceMaterial; 
    MeshRenderer[] meshRenderers;

    private bool isOutlineEnabled = false; // �ƿ����� Ȱ��ȭ ����

    void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        check();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleOutline();
        }
    }

    void check()
    {
        if(Managers.Object.OutLine!=null)
        {
            instanceMaterial = Instantiate(Managers.Object.OutLine);
            OutLine();
        }
    }

    void OutLine()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            // ���� ��Ƽ���� �迭�� �߰��� ��Ƽ������ �����Ͽ� ���ο� �迭 ����
            Material[] currentMaterials = meshRenderer.materials;
            Material[] newMaterials = new Material[currentMaterials.Length + 1];

            // ���� ��Ƽ���� ����
            for (int i = 0; i < currentMaterials.Length; i++)
            {
                newMaterials[i] = currentMaterials[i];
            }

            // �߰��� ��Ƽ������ ������ ��ġ�� �߰�
            newMaterials[newMaterials.Length - 1] = instanceMaterial;

            // ���ο� ��Ƽ���� �迭�� MeshRenderer�� �Ҵ�
            meshRenderer.materials = newMaterials;
        }
    }


    void OutLineOn()
    {
        instanceMaterial.SetFloat("_Outline", 0.12f); // �ƿ����� �β� ����
    }

    void OutLineOff()
    {
        instanceMaterial.SetFloat("_Outline", -1.0f); // �ƿ����� ��Ȱ��ȭ
    }

    void ToggleOutline()
    {
        isOutlineEnabled = !isOutlineEnabled;

        // �ƿ����� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        if (isOutlineEnabled)
        {
            OutLineOn();
        }
        else
        {
            OutLineOff();
        }
    }
}
