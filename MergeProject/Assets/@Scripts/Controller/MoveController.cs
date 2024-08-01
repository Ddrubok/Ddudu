using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    Image _handler;

    [SerializeField]
    Image _background;

    Vector2 _touchPosition;
    Vector2 _moveDir;

    void Start()
    {
        Debug.Log("start");

        if (Application.platform == RuntimePlatform.WindowsPlayer|| Application.platform == RuntimePlatform.WindowsEditor)
        {
            _background.raycastTarget = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessKeyboardInput();
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

       
        Managers.Game.MoveDir = new Vector3(_moveDir.x, 0.0f, _moveDir.y);
    }

    private void ProcessKeyboardInput()
    {
        // WASD 또는 화살표 키 입력 처리
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 벡터 계산
        _moveDir = new Vector2(horizontalInput, verticalInput).normalized;

        if (_moveDir.magnitude > 0.1f)
        {
          
            // 새로운 핸들 위치 계산
            Vector2 newPosition = _touchPosition + _moveDir;
            _handler.transform.position = newPosition;

            // 이동 방향 업데이트
            Managers.Game.MoveDir = _moveDir;

            Debug.Log(Managers.Game.MoveDir);
        }
        else
        {
            _moveDir = Vector2.zero;

            Managers.Game.MoveDir = Vector3.zero;
        }
    }
}
