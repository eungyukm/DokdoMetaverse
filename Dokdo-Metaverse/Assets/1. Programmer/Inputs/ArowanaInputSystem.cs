using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

[RequireComponent(typeof(InputSystemUIInputModule))]
public class ArowanaInputSystem : MonoBehaviour
{
    public static ArowanaInputSystem instance;
    public static ArowanaInputs inputs;

    private static bool _finishSet;
    public static bool finishSet{ get { return _finishSet; } private set { _finishSet = value; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
        
        if (inputs == null) inputs = new ArowanaInputs();

        _finishSet = true;
    }

    private void OnEnable()
    {
        if (inputs == null) return;
        inputs.Enable();
    }

    private void OnDisable()
    {
        if (inputs == null) return;
        inputs.Disable();
    }
}
