using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 해당 UI의 클릭 상태와 드래그 상태를 체크해주는 컴포넌트입니다.
/// 상태 체크를 하고 싶은 UI 게임 오브젝트에 추가한 후 해당 클래스를 참조하여 사용해주세요.
/// 
/// 작성자: 변고경
/// 작성일자: 2021/8/5
/// </summary>
public class UIClickDragChecker : MonoBehaviour, IDragHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("현재 포인터 포지션")]
    public Vector2 pointerPosition;
    [Tooltip("현재 포인터의 델타 포지션")]
    public Vector2 pointerDeltaPosition;
    [Tooltip("포인터 다운 포지션")]
    public Vector2 pointerDownPosition;
    [Tooltip("포인터 업 포지션")]
    public Vector2 pointerUpPosition;

    [Tooltip("해당 UI를 드래그 중이면 True.")]
    public bool dragging;
    [Tooltip("해당 UI를 클릭하면 True.")]
    public bool clicked;

    public bool focusWhenClick;

    public void OnDrag(PointerEventData eventData)
    {
        pointerPosition = eventData.position;
        pointerDeltaPosition = eventData.delta;

        dragging = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (focusWhenClick) EventSystem.current.SetSelectedGameObject(this.gameObject, eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDownPosition = eventData.position;
        pointerPosition = eventData.position;

        clicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUpPosition = eventData.position;
        pointerPosition = eventData.position;

        dragging = false;
        clicked = false;
    }

    private void Update()
    {
        if(!dragging) pointerDeltaPosition = Vector2.zero;
        
#if (!UNITY_ANDROID && !UNITY_IOS) || UNITY_EDITOR
        pointerPosition = Input.mousePosition;
#endif
    }
}
