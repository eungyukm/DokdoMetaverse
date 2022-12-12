using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class SO_Inputs : ScriptableObject, ArowanaInputs.ITouchActions, ArowanaInputs.IPlayerActions
{
    public string xy1;
    public string xy2;
    public ArowanaInputs Inputs;
    //ArowanaInputs.ITouchActions Touch;
    private void OnEnable()
    {
        if(Inputs == null)
        {
            Inputs = new ArowanaInputs();
            Inputs.Player.SetCallbacks(this);
            Inputs.Player.Enable();
            Inputs.Touch.SetCallbacks(this);
            Inputs.Touch.Enable();
        }
    }
        
    private void OnDisable()
    {
        
    }

    public void OnPrimaryTouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnSecondaryTouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnDoubleTap(InputAction.CallbackContext context)
    {
        
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        
    }

    public void OnSlowTap(InputAction.CallbackContext context)
    {
        
    }

    public void OnPress(InputAction.CallbackContext context)
    {
        
    }

    public void OnRelease(InputAction.CallbackContext context)
    {
        
    }

    public void OnSingleTap(InputAction.CallbackContext context)
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }

    public void OnCameraPosition(InputAction.CallbackContext context)
    {
        
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        
    }

    public void OnPrimaryTouchDelta(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnSecondaryTouchDelta(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
