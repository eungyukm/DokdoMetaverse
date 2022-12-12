using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchPointInteractor : BaseTouchInteracter
{
    [SerializeField] protected InteractorComponent sender = null;

    public Camera rayCastCamra;

    protected override void OnClickStarted(InputAction.CallbackContext callback)
    {
        base.OnClickStarted(callback);

        RaycastHit raycastHit = GetWorldPositionHitData(pointPos);
        if (raycastHit.collider.TryGetComponent(out IInteractable interactable))
        {
            sender.Interaction(interactable);
        }
    }
}
