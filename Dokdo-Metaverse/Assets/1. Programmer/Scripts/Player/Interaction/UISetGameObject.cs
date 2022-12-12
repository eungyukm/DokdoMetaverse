using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// World UI Interacter를 사용할때 클릭시 비활성화된 게임 오브젝트를 활성화 시켜주는 컴포넌트입니다.
/// 
/// 작성자: 변고경
/// 작성일자: 2021/8/5
/// </summary>
public class UISetGameObject : MonoBehaviour
{
    [Tooltip("클릭시 활성화할 게임 오브젝트.")]
    public List<GameObject> objects;

    [Tooltip("콜라이더 트리거 영역을 나갔을때 해당 게임 오브젝트를 끄기 위해 필요")]
    public UITriggerObject triggerObject;

    public UnityEvent onClick;

    public bool activated;

    private void Awake()
    {
        if(TryGetComponent(out Collider col))
        {
            col.isTrigger = false;
        }

        //this.gameObject.layer = LayerMask.NameToLayer("UI");
    }

    private void Start()
    {
        //onClick.AddListener(() => FindObjectOfType<PlayerControlDisabler>().SetPlayerControl(false));
    }

    public void SetGameObjects(bool enable)
    {
        if (!triggerObject.enteredInArea) return;

        foreach (GameObject @object in objects)
        {
            @object.SetActive(enable);
        }
        activated = enable;
    }
}
