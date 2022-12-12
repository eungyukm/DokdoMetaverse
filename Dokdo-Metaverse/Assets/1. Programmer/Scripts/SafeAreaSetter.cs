using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SafeAreaSetter : MonoBehaviour
{
    public Canvas canvas;
    private RectTransform panelSafeArea;
    private Rect currentSafeArea = new Rect();
    ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;

    // Start is called before the first frame update
    void Start()
    {
        if(canvas == null)
        {
            canvas = transform.parent.GetComponent<Canvas>();
        }
        panelSafeArea = GetComponent<RectTransform>();

        currentOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;

        ApplaySafeArea();
    }

    private void ApplaySafeArea()
    {
        if(panelSafeArea == null)
        {
            return;
        }

        Rect safeArea = Screen.safeArea;

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position = safeArea.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;

        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;
    }

    // Update is called once per frame
    void Update()
    {
        if((currentOrientation != Screen.orientation) || (currentSafeArea != Screen.safeArea))
        {
            ApplaySafeArea();
        }
    }
}
