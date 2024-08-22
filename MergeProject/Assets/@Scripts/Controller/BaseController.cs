using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class BaseController : MonoBehaviour
{
    public ObjectType ObjectType { get; protected set; }

    protected OutLineApply outLine;

    void Awake()
    {
        Init();
    }

    bool _init = false;
    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }

    void Update()
    {
        UpdateController();
        AnimationEnd();

    }

    protected void SetOutLine()
    {
        outLine = gameObject.GetOrAddComponent<OutLineApply>();
    }

    protected void OutLineOn()
    {
        if (outLine != null)
            outLine.OutLineOn();
    }
    protected void OutLineOff()
    {
        if (outLine != null)
            outLine.OutLineOff();
    }



    public virtual void UpdateController()
    {
    }

    protected virtual void AnimationEnd()
    {

    }
}
