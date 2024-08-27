using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineApply : MonoBehaviour
{
    private Material instanceMaterial;
    Renderer[] meshRenderers;

    private bool isOutlineEnabled = false; // 아웃라인 활성화 상태

    void Awake()
    {
        meshRenderers = GetComponentsInChildren<Renderer>();
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
        if (Managers.Object.OutLine != null)
        {
            instanceMaterial = Instantiate(Managers.Object.OutLine);
            OutLine();
        }
    }

    void OutLine()
    {
        foreach (Renderer meshRenderer in meshRenderers)
        {
            Material[] currentMaterials = meshRenderer.materials;
            Material[] newMaterials = new Material[currentMaterials.Length + 1];

            for (int i = 0; i < currentMaterials.Length; i++)
            {
                newMaterials[i] = currentMaterials[i];
            }
            newMaterials[newMaterials.Length - 1] = instanceMaterial;

            meshRenderer.materials = newMaterials;
        }
    }


    public void OutLineOn()
    {
        instanceMaterial.SetFloat("_Outline", 0.12f); // 아웃라인 두께 설정
    }

    public void OutLineOff()
    {
        instanceMaterial.SetFloat("_Outline", -1.0f); // 아웃라인 비활성화
    }

    public void ToggleOutline()
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
