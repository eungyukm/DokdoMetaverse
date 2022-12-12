using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RotationOnly
{
    X,Y,Z, None
}

/// <summary>
/// UI 빌보드 컴포넌트입니다. 
/// 
/// 작성자: 변고경
/// 작성일자: 2021/8/5
/// </summary>
public class Bilboard : MonoBehaviour
{
    public Camera cam;

    [Tooltip("회전할 축")]
    [SerializeField]
    private RotationOnly rotationOnly = RotationOnly.None;

    private Vector3 v;

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    /// <summary>
    /// 메인 카메라(플레이어)를 바라본다.
    /// </summary>
    private void Look()
    {
        //if(cam == null) v = Camera.main.transform.position - transform.position;
        //else v = cam.transform.position - transform.position;
        if (cam == null)
        {
            cam = Camera.main;
        }
        v = cam.transform.position - transform.position;

        switch (rotationOnly)
        {
            case RotationOnly.X:
                v.y = 0;
                v.z = 0;
                break;
            case RotationOnly.Y:
                v.x = 0;
                v.z = 0;
                break;
            case RotationOnly.Z:
                v.x = 0;
                v.y = 0;
                break;
            case RotationOnly.None:
                v = Vector3.zero;
                break;
            default:
                v = Vector3.zero;
                break;
        }

        transform.LookAt(Camera.main.transform.position - v);
    }
}