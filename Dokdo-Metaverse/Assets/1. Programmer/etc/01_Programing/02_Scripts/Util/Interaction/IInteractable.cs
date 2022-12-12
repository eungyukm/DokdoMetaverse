using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EInteractionState
{
    NONE,
    ENTER,  // 상호작용 거리 내에 들어옴
    EXIT,   // 상호작용 거리 밖으로 나감
    TRY,    // 상호작용 시도
    FAILED, // 상호작용 실패
    START,  // 상호작용 성공
    END,    // 상호작용 종료
}

public interface IInteractable
{
    void SetActive(bool value);

    void SetFocus(bool value);

    bool IsInteractable(); // 인터렉션 가능 여부 확인

    bool TryInteraction(object sender, Vector3 senderPosition); // 인터렉션 시작

    bool TryStopInteraction(object sender); // 인터렉션 종료
}