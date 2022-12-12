using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made By :: 우민우
/// /// Last Update :: 2021.08.24.
/// 
/// Comment
/// - 상호작용을 시도하는 클래스
/// - 주변의 IInteractor가 붙은 클래스를 찾아서 상호작용 시도
/// </summary>

public class InteractorComponent : MonoBehaviour
{
    [SerializeField] protected float interactionDistance = 1.0f;
    protected List<IInteractable> interactables = null;

    protected bool bInteracting = false; // 인터렉션 여부
    protected IInteractable currentInteractable = null; // 현재 상호작용 중인 대상

    protected virtual void Awake()
    {
        Init();
        interactables = new List<IInteractable>();
    }

    protected void Init()
    {
        // Note :: 
        // - Interaction Component를 감지하는 방법이 Rigidbody와 Collider를 이용하고 있음
        // - 해당 기능이 무겁다고 생각할 경우 변경이 필요
        // - ex) InteractionComponent를 별도의 Manager에서 관리하여 직접 거리만 비교
        // - ex) 주기적으로 Physics.Overlap을 통해 주변의 InteractionComponent 확인

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null) rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;

        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider == null) collider = gameObject.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = interactionDistance;
    }

    /// <summary>
    /// 상호작용 가능 여부
    /// </summary>
    /// <returns></returns>
    public bool IsInteracting()
    {
        return bInteracting;
    }

    /// <summary>
    /// 상호작용 추가
    /// </summary>
    /// <param name="other"></param>
    public void AddInteractable(IInteractable other)
    {
        if (interactables.Contains(other))
            return;

        interactables.Add(other);
        other.SetFocus(true);
    }

    /// <summary>
    /// 상호작용 제거
    /// </summary>
    /// <param name="other"></param>
    public void RemoveInteractable(IInteractable other)
    {
        if (interactables.Contains(other) == false)
            return;

        other.TryStopInteraction(this);
        interactables.Remove(other);
        other.SetFocus(false);
    }

    /// <summary>
    /// 가장 가까운 대상 상호작용
    /// </summary>
    public void InteractionToNearest()
    {
        if (interactables.Count >= 0)
        {
            Interaction(interactables[0]);
        }
    }

    /// <summary>
    /// 인터렉션 시도
    /// </summary>
    /// <param name="interactable"></param>
    public void Interaction(IInteractable interactable)
    {
        if (bInteracting)
            return;

        if (interactable.TryInteraction(this, transform.position))
        {
            currentInteractable = interactable;
            bInteracting = true;
        }
    }

    /// <summary>
    /// 인터렉션 중지
    /// </summary>
    public void StopInteraction()
    {
        if (bInteracting == false)
            return;

        // 현재 인터렉션 중인 대상이 없을 경우 bInteracting만 초기화
        if (currentInteractable != null)
        {
            if (currentInteractable.TryStopInteraction(this))
            {
                currentInteractable = null;
                bInteracting = false;
            }
        }
        else
        {
            bInteracting = false;
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            AddInteractable(interactable);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            RemoveInteractable(interactable);
        }
    }
}
