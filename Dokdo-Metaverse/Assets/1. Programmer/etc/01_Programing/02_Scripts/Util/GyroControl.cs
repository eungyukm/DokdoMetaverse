using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour
{
    public bool active = false;

    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotFix;

    //[SerializeField]
    //private Transform worldObj;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;

        gyroSupported = SystemInfo.supportsGyroscope;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;// Áß¿ä!

            rotFix = new Quaternion(0, 0, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;

        transform.localRotation = transform.parent.localRotation * gyro.attitude * rotFix;

    }

    void ResetGyroRotation()
    {
        startY = transform.eulerAngles.y;
    }
}
