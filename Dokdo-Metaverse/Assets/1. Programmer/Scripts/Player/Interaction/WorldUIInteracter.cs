using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 월드 스페이스에 있는 UI와 상호작용 할 수 있게 해주는 컴포넌트입니다.
/// 
/// 작성자: 변고경
/// 작성일자: 2021/8/5
/// </summary>

public class WorldUIInteracter : BaseTouchInteracter
{
    protected override void Awake()
    {
        base.Awake();
        triggerInteraction = QueryTriggerInteraction.Ignore;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnClickStarted(InputAction.CallbackContext callback)
    {
        //EnableUI();
    }

    protected override void Update()
    {
        base.Update();
        // WorldUIInteracter를 조작UI 중이 아닐때 작동되지 않도록 하려고 UIClickDragChecker를 사용하는데 
        // UIClickDragChecker에서 사용하고 있는 UI 콜백 메서드들이 InputSystem의 입력 콜백 메서드보다 늦게 호출되서 
        // 클릭 체크 전에 EnableUI() 메서드가 호출되는 문제가 있어서 Update에서 체크하고 호출하도록 하였습니다.
        if (clickDragChecker.clicked && !clickDragChecker.dragging) EnableUI();
    }

    /// <summary>
    /// UI 활성화
    /// </summary>
    private void EnableUI()
    {
        RaycastHit _hit = GetWorldPositionHitData(pointPos);

        if (_hit.collider == null) return;
        Debug.Log(_hit.collider.gameObject.name);
        if (_hit.collider.TryGetComponent(out UISetGameObject uI))
        {
            if (uI.activated) return;
            else
            {
                if (uI.triggerObject.enteredInArea)
                {
                    uI.SetGameObjects(true);
                    uI.onClick.Invoke();
                }
                else
                {
                    uI.SetGameObjects(false);
                }
            }
        }
        else if (_hit.collider.TryGetComponent(out TouchInteractable interactable))
        {
            if (interactable.CheckInteraction(_hit.distance)) interactable.onTouch.Invoke();
        }
    }
}
