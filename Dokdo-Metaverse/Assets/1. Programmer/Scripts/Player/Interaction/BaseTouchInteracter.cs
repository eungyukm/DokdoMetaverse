using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Overlay UI를 제외한 오브젝트들에 대한 터치 조작을 가능하게 해주는 베이스 클래스입니다.
/// 
/// 작성자: 변고경
/// 작성일자: 2021/8/5
/// </summary>
public class BaseTouchInteracter : MonoBehaviour
{
    [SerializeField]
    protected UIClickDragChecker clickDragChecker;

    [Tooltip("콜라이더 트리거에 대한 상호작용 여부")]
    [SerializeField]
    protected QueryTriggerInteraction triggerInteraction;

    [Tooltip("상호작용 처리에서 무시할 레이어")] 
    [SerializeField]
    protected LayerMask ignoreLayerMask;

    [Tooltip("레이캐스트 거리")]
    [SerializeField]
    private float collideMaxDistance = 100f;

    protected Vector3 pointPos;

    protected virtual void Awake(){}

    protected virtual void Start()
    {
        ArowanaInputSystem.inputs.Touch.SingleTap.started += OnClickStarted;
        ArowanaInputSystem.inputs.Touch.SingleTap.canceled += OnClickCancled;
        ArowanaInputSystem.inputs.Touch.SingleTap.performed += OnClickPerformed;
    }

    protected virtual void OnClickStarted(InputAction.CallbackContext callback){}
    protected virtual void OnClickCancled(InputAction.CallbackContext callback){}
    protected virtual void OnClickPerformed(InputAction.CallbackContext callback){}

    protected virtual void Update()
    {
        if (!ArowanaInputSystem.finishSet) return;
        
        pointPos = ArowanaInputSystem.inputs.Touch.Point.ReadValue<Vector2>();
    }

    /// <summary>
    /// 터치 / 마우스 클릭 입력시 입력 포지션에 대응하는 3D 포지션에 레이캐스트 히트 데이터를 리턴
    /// </summary>
    /// <param name="screenPosition">터치 / 마우스 좌표</param>
    /// <returns>입력 포지션에 대응하는 3D 포지션에 레이캐스트 히트 데이터</returns>
    public RaycastHit GetWorldPositionHitData(Vector3 screenPosition)
    {
        if (ArowanaInputSystem.inputs.Touch.SecondaryTouch.triggered) return new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        Physics.Raycast(ray, out RaycastHit hit, collideMaxDistance, ~ignoreLayerMask, triggerInteraction);

        return hit;
    }
}
