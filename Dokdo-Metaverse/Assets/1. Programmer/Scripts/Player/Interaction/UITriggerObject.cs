using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/// <summary>
/// 콜라이더 트리거 영역에 도달시 이벤트를 발생시키는 컴포넌트입니다.
/// 현재는 콜라이더 트리거 도달시 UI를 활성화하는 용도로 쓰이고 있습니다.
/// 
/// 작성자: 변고경
/// 작성일자: 2021/8/5
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class UITriggerObject : MonoBehaviour
{
    [Tooltip("World UI Interacter를 사용할때 콜라이더 트리거 밖으로 나갔을때 아이콘을 끄는 용도로 사용")]
    public UISetGameObject uISetGameObject;

    //[Tooltip("콜라이더 트리거 영역에 도달시 표시할 아이콘")]
    //public Image icon;

    [Tooltip("콜라이더 트리거 영역에 도달시 표시할 오브젝트")]
    public GameObject popUpObject;

    [Tooltip("콜라이더 트리거 영역에 들어가면 True, 나가면 False")]
    //[HideInInspector]
    public bool enteredInArea = false;

    [Tooltip("콜라이더 트리거 영역에 들어갈 때 이벤트")]
    [SerializeField]
    private UnityEvent onEnter;

    [Tooltip("콜라이더 트리거 영역에서 나갈 때 이벤트")]
    [SerializeField]
    private UnityEvent onExit;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void Start()
    {
        //icon.enabled = false;
        if (popUpObject) popUpObject.SetActive(false);

        //onExit.AddListener(() => FindObjectOfType<PlayerControlDisabler>().SetPlayerControl(true));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SetEnterArea(true);
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SetEnterArea(false);
            if (uISetGameObject != null) uISetGameObject.SetGameObjects(false);
            onExit.Invoke();
        }
        
    }

    /// <summary>
    /// 콜라이더 트리거 영역 출입에 대한 변수 세팅 
    /// </summary>
    /// <param name="enable">활성화 여부</param>
    private void SetEnterArea(bool enable)
    {
        //if(icon != null) icon.enabled = enable;
        if (popUpObject) popUpObject.SetActive(enable);
        enteredInArea = enable;
    }
}
