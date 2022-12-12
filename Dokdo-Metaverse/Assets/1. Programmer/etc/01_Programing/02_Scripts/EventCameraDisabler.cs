using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class EventCameraDisabler : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private AudioListener audioListener;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        audioListener = GetComponent<AudioListener>();
    }

    private void FixedUpdate()
    {
        if (Camera.main != null)
        {
            _camera.enabled = false;
            audioListener.enabled = false;
        }
        else
        {
            _camera.enabled = true;
            audioListener.enabled = true;
        }
    }
}
