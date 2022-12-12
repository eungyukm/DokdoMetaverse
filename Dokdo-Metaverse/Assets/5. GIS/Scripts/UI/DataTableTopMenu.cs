using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataTableTopMenu : MonoBehaviour
{
    public Button closeBtn;
    public UnityAction OnCloseButtonClick;

    private void Awake()
    {
        closeBtn.onClick.AddListener(CloseButtonClicked);
    }

    private void CloseButtonClicked()
    {
        OnCloseButtonClick?.Invoke();
    }
}
