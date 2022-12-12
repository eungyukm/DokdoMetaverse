using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Axis
{
    X, Y, Both
}

public class ModelSwiper : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Axis axis = Axis.Y;

    public Camera cam;

    public Transform targetToMove;

    public Transform originTr;

    public RectTransform containerRect;

    

    Vector2 pointerDownPosition;
    Vector2 currentPointerPosition;
    Vector2 pointerUpPosition;
    Vector2 deltaPosition;

    bool dragging = false;

    float pitch;
    float yaw;

    float turnSpeed = 10f;

    [Range(0f,1f)]
    public float maxCamDistance = 0.8f;
    [Range(0f, 1f)]
    public float minCamDistance = 0.3f;

    [Range(1.0f, 10f)]
    public float zoomDamping = 7f;

    private float currentZoomSpeed;

    public bool canZoom = true;

    private void Awake()
    {
        cam.transform.localPosition = Vector3.back;
        cam.transform.localRotation = Quaternion.identity;
        //cam.orthographic = true;
        cam.nearClipPlane = 0.001f;
        cam.farClipPlane = 5f;
        //cam.orthographicSize = Mathf.Round((maxCamDistance + minCamDistance) / 2);

        ArowanaInputSystem.inputs.Player.CameraPosition.performed += (ctx) =>
        {
            if (!canZoom) return;

            var inputValue = ctx.ReadValue<float>();
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cam.orthographicSize - (inputValue / 100), ref currentZoomSpeed, zoomDamping / 5 * Time.deltaTime);

            if (cam.orthographicSize > maxCamDistance)
            {
                cam.orthographicSize = maxCamDistance;
            }
            else if (cam.orthographicSize < minCamDistance)
            {
                cam.orthographicSize = minCamDistance;
            }
        };
    }


    public void OnDrag(PointerEventData eventData)
    {
        deltaPosition = eventData.delta;
        dragging = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        deltaPosition = Vector2.zero;
        dragging = false;
    }

    float previousPinchDistance = 0f, pinchDistance = 0;
    bool zooming;

    private void Update()
    {
        ZoomControl();
        MoveTarget();
    }

    private void ZoomControl()
    {
        if (!canZoom) return;

        if (Input.touchCount > 1)
        {
            Touch primaryTouch = Input.GetTouch(0);
            Touch secondaryTouch = Input.GetTouch(1);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, primaryTouch.position, Camera.main, out Vector2 pLocalPos);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, secondaryTouch.position, Camera.main, out Vector2 sLocalPos);

            if (containerRect != null &&
                    RectTransformUtility.RectangleContainsScreenPoint(containerRect, pLocalPos, Camera.main) ||
                    RectTransformUtility.RectangleContainsScreenPoint(containerRect, sLocalPos, Camera.main))
            {

                pinchDistance = Vector2.Distance(primaryTouch.position, secondaryTouch.position);

                if (pinchDistance < previousPinchDistance)
                {
                    // 줌 아웃
                    cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cam.orthographicSize + 0.1f, ref currentZoomSpeed, zoomDamping * Time.deltaTime);
                }
                else if (pinchDistance > previousPinchDistance)
                {
                    // 줌 인
                    cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cam.orthographicSize - 0.1f, ref currentZoomSpeed, zoomDamping * Time.deltaTime);
                }

                if (cam.orthographicSize > maxCamDistance)
                {
                    cam.orthographicSize = maxCamDistance;
                }
                else if (cam.orthographicSize < minCamDistance)
                {
                    cam.orthographicSize = minCamDistance;
                }

                previousPinchDistance = pinchDistance;
                zooming = true;
            }

        }
        else
        {
            zooming = false;
        }
    }

    Quaternion currentRot;
    Quaternion targetRot;

    private void MoveTarget()
    {
        if (Input.touchCount > 1) return;

        yaw = deltaPosition.x * Time.deltaTime * turnSpeed;
        pitch = deltaPosition.y * Time.deltaTime * turnSpeed;

        switch (axis)
        {
            case Axis.X:
                targetToMove.transform.RotateAround(originTr.position, originTr.right, pitch);
                break;
            case Axis.Y:
                targetToMove.transform.RotateAround(originTr.position, -originTr.up, yaw);
                break;
            case Axis.Both:
                targetToMove.transform.RotateAround(originTr.position, -originTr.up, yaw);
                targetToMove.transform.RotateAround(originTr.position, originTr.right, pitch);
                break;
        }
    }
}
