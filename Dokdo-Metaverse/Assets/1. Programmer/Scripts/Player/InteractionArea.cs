using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class InteractionArea : MonoBehaviour
{
    public UnityEvent _ontriggerEnter;
    public UnityEvent _ontriggerExit;

    public string CollisionTag = "Player";

    public bool entered = false;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == CollisionTag)
        {
            _ontriggerEnter?.Invoke();
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == CollisionTag)
        {
            _ontriggerExit?.Invoke();
            entered = false;
        }
    }
}
