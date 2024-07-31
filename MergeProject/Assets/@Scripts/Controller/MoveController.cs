using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    Image _handler;

    Vector2 _touchPosition;
    Vector2 _moveDir;

    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {

        Debug.Log("OnPointerDown");
        _handler.transform.position = eventData.position;
        _touchPosition = eventData.position;
    }

    public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        _handler.transform.position = _touchPosition;
        _moveDir = Vector2.zero;

        Managers.Game.MoveDir = Vector3.zero;
    }

    public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector2 touchDir = (eventData.position - _touchPosition);

        _moveDir = touchDir.normalized;
        Vector2 newPosition = _touchPosition + _moveDir;
        _handler.transform.position = newPosition;

       
        Managers.Game.MoveDir = new Vector3(-_moveDir.x, 0.0f, -_moveDir.y);
    }
}
