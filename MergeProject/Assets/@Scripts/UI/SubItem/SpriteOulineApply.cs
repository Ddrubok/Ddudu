using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteOutlineApply : MonoBehaviour
{
    private List<SpriteOutline> spriteOutline;

    private void Awake()
    {
        spriteOutline = new List<SpriteOutline>();
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            spriteOutline.Add(sprite.GetOrAddComponent<SpriteOutline>());
        }

    }

    public void OutLineOn()
    {
        foreach(SpriteOutline so in spriteOutline)
        {
            so.OutLineOn();
        }
    }

    public void OutLineOff()
    {
        foreach (SpriteOutline so in spriteOutline)
        {
            so.OutLineOff();
        }
    }

}
