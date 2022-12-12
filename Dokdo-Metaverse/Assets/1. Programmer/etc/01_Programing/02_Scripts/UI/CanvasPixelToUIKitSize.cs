using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPixelToUIKitSize : MonoBehaviour
{
    private CanvasScaler canvasScaler;

    private void Awake()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        Resize();
    }

    private void Resize()
    {
        if (Application.isEditor) return;

        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
#if UNITY_ANDROID
        canvasScaler.scaleFactor = Screen.dpi / 160;
#elif UNITY_IOS
        canvasScaler.scaleFactor = ApplePlugin.GetNativeScaleFactor();
#endif
    }
}
