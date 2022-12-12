using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made By :: 우민우
/// Last Update :: 2021.08.24.
/// 
/// Comment
/// - 상호작용을 담당하는 클래스
/// - Event에 Callback을 추가하여 사용
/// </summary>

// Note ::
// - 현재 Intearctor는 별도로 없는 상태
// - Interactor가 없는 상태라서 TouchPointInteractor에게 로직이 위임되어 UI + Interactor의 기능을 동시에 담당
// - 차후 Interactor를 별도로 분할하여 Input과 Interactor의 기능을 분할 작업이 필요

public class InteractionComponent : MonoBehaviour, IInteractable
{
    protected bool bActive = true; // 활성화 여부
    protected bool bFocus = false; // 인터렉션 대상이 주변에 있어서 활성화 여부
    protected bool bInteracting = false; // 현재 인터렉션 중인지 여부
    [SerializeField] protected bool bCheckDistance = true; // 거리 확인 여부
    [SerializeField] protected float checkDistance = 1.0f; // 확인 가능 거리

    protected object sender = null; // 상호작용 대상
    protected Vector3 senderPosition = Vector3.zero; // 상호작용 대상 위치

    public event Action<InteractionComponent, EInteractionState, object, Vector3> OnChangedState = null;

    protected virtual void Awake()
    {
        Init();
        checkDistance *= checkDistance; // Sqr 계산 용도
    }

    public void Init()
    {
        // Note :: 
        // - Interaction Component를 감지하는 방법이 Rigidbody와 Collider를 이용하고 있음
        // - 해당 기능이 무겁다고 생각할 경우 변경이 필요
        // - ex) InteractionComponent를 별도의 Manager에서 관리하여 직접 거리만 비교
        // - ex) 주기적으로 Physics.Overlap을 통해 주변의 InteractionComponent 확인

        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider == null) collider = gameObject.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = checkDistance;
    }

    /// <summary>
    /// 오브젝트 활성화/비활성화
    /// </summary>
    /// <param name="value"></param>
    public void SetActive(bool value)
    {
        if (value) Active();
        else Deactive();
    }

    // Note ::
    // - Active와 Deactive를 별도로 제작한 이유는 SetActive를 virtual로 제작할 경우
    //   로직이 꼬일 수 있는 것을 미연에 방지하기 위함

    // 활성화 Callback
    public virtual void Active() 
    {
        bActive = true;
    }

    // 비활성화 Callback
    public virtual void Deactive() 
    {
        bActive = false;

        if (bInteracting)
        {
            StopInteraction(sender);
        }
    }

    public void SetFocus(bool value)
    {
        if (value) Focus();
        else Unfocus();
    }

    public virtual void Focus()
    {
        bFocus = true;
        OnChangedState?.Invoke(this, EInteractionState.ENTER, sender, senderPosition);
    }

    public virtual void Unfocus()
    {
        bFocus = false;
        OnChangedState?.Invoke(this, EInteractionState.EXIT, sender, senderPosition);
    }

    /// <summary>
    /// 현재 인터렉션을 진행 중인지 확인
    /// </summary>
    /// <returns></returns>
    public bool IsInteracting()
    {
        return bInteracting;
    }

    /// <summary>
    /// Other Position과의 거리가 Check Distance 내에 있는지 확인
    /// </summary>
    /// <param name="otherPosition">목표 위치</param>
    /// <returns></returns>
    public bool IsCheckDistance(Vector3 otherPosition)
    {
        float betweenDistance = (otherPosition - transform.position).sqrMagnitude;
        if (betweenDistance <= checkDistance)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 상호작용 조건을 검사
    /// </summary>
    /// <returns></returns>
    public virtual bool IsInteractable()
    {
        if (IsInteracting())
            return false;

        if (bCheckDistance && IsCheckDistance(senderPosition) == false)
            return false;

        return true;
    }

    /// <summary>
    /// 상호작용 시도 및 조건 검사
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="senderPosition"></param>
    /// <returns></returns>
    public virtual bool TryInteraction(object sender, Vector3 senderPosition)
    {
        if (IsInteractable() == false)
            return false;

        Interaction(sender, senderPosition);
        return true;
    }

    /// <summary>
    /// 상호작용 시작
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="senderPosition"></param>
    public virtual void Interaction(object sender, Vector3 senderPosition)
    {
        // Note :: 실제 상호작용이 처리되는 로직으로 조건 검사 X
        bInteracting = true;

        this.sender = sender;
        this.senderPosition = senderPosition;

        OnChangedState?.Invoke(this, EInteractionState.START, sender, senderPosition);
    }

    /// <summary>
    /// 상호작용 중지 시도
    /// </summary>
    public virtual bool TryStopInteraction(object sender)
    {
        // 인터렉션 여부만 검사
        if (IsInteracting() == false)
            return false;

        StopInteraction(sender);
        return true;
    }

    /// <summary>
    /// 상호작용 중지
    /// </summary>
    public virtual void StopInteraction(object sender)
    {
        // Note :: 현재 Stop은 Try가 없는 상태, 나중에 필요하면 추가
        bInteracting = false;

        OnChangedState?.Invoke(this, EInteractionState.END, sender, senderPosition);

        this.sender = null;
        this.senderPosition = Vector3.zero;
    }
}
