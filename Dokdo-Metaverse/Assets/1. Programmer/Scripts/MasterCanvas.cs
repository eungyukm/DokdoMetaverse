using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(CanvasScaler))]
[RequireComponent(typeof(GraphicRaycaster))]
[RequireComponent(typeof(SafeAreaSetter))]
public class MasterCanvas : MonoBehaviour
{
    private Canvas _canvas;
    private CanvasScaler _canvasScaler;
    private GraphicRaycaster _raycaster;
    private SafeAreaSetter _safeAreaSetter;

    [HideInInspector]
    public CanvasGroup _canvasGroup;

    private void Awake()
    {
        GetCanvasComponents();

        Initialize();
    }

    private void GetCanvasComponents()
    {
        _canvas = GetComponent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasScaler = GetComponent<CanvasScaler>();
        _raycaster = GetComponent<GraphicRaycaster>();
        _safeAreaSetter = GetComponent<SafeAreaSetter>();
    }

    private void Initialize()
    {
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.sortingOrder = 0;

        _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _canvasScaler.referenceResolution = new Vector2(1920f, 1080f);
        _canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        _canvasScaler.referencePixelsPerUnit = 100;

        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.ignoreParentGroups = false;

        if (_safeAreaSetter.canvas == null) _safeAreaSetter.canvas = _canvas;
    }
}
