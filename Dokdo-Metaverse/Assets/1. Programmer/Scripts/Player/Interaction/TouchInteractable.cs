using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum IntertactionCheck
{
    CameraDistance,
    Collision,
    Both,
}

//[RequireComponent(typeof(Collider))]
public class TouchInteractable : MonoBehaviour
{
    public UnityEvent onTouch;

    public ScriptableObject scriptableObject;

    public IntertactionCheck intertactionCheck;

    public float interactDistance = 8f;

    public InteractionArea interactionArea;

    public bool CheckInteraction(float distance)
    {
        switch (intertactionCheck)
        {
            case IntertactionCheck.CameraDistance:
                if (distance <= interactDistance) return true;
                break;
            case IntertactionCheck.Collision:
                if (interactionArea.entered) return true;
                break;
            case IntertactionCheck.Both:
                if ((distance <= interactDistance) && (interactionArea.entered)) return true;
                break;
        }

        return false;
    }
}