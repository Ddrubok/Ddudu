using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    
    [SerializeField]
    Button _button;

    private void Start()
    {
        _button.onClick.AddListener(OnButtonClick);
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            _button.gameObject.SetActive(false);
        }
       
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&Managers.Game.go!=null)
        {
            OnAction();
        }

        if (Managers.Game.go == null)
            OffAction();

    }

    void OnButtonClick()
    {
        OnAction();
    }

    void OnAction()
    {
        Managers.Game.ActionButton = true;
    }
    void OffAction()
    {
        Managers.Game.ActionButton = false;
    }

}
