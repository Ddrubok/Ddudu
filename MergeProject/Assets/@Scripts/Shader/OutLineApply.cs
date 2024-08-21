using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineApply : MonoBehaviour
{
    private Material instanceMaterial; 
    MeshRenderer[] meshRenderers;

    private bool isOutlineEnabled = false; // 아웃라인 활성화 상태

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
            // 현재 머티리얼 배열에 추가할 머티리얼을 포함하여 새로운 배열 생성
            Material[] currentMaterials = meshRenderer.materials;
            Material[] newMaterials = new Material[currentMaterials.Length + 1];

            // 기존 머티리얼 복사
            for (int i = 0; i < currentMaterials.Length; i++)
            {
                newMaterials[i] = currentMaterials[i];
            }

            // 추가할 머티리얼을 마지막 위치에 추가
            newMaterials[newMaterials.Length - 1] = instanceMaterial;

            // 새로운 머티리얼 배열을 MeshRenderer에 할당
            meshRenderer.materials = newMaterials;
        }
    }


    void OutLineOn()
    {
        instanceMaterial.SetFloat("_Outline", 0.12f); // 아웃라인 두께 설정
    }

    void OutLineOff()
    {
        instanceMaterial.SetFloat("_Outline", -1.0f); // 아웃라인 비활성화
    }

    void ToggleOutline()
    {
        isOutlineEnabled = !isOutlineEnabled;

        // 아웃라인 활성화 또는 비활성화
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
