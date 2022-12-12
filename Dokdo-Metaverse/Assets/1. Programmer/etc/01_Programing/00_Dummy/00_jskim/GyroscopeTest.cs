using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if(SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = GyroToUnity(Input.gyro.attitude);
    }

    private Quaternion GyroToUnity(Quaternion attitude)
    {
        return new Quaternion(attitude.x, attitude.y, -attitude.z, -attitude.w);
    }
}
