using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorLayerTest : MonoBehaviour
{
    private Animator _animator;

    public List<SynchronizedLayer> layers;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // private void OnValidate()
    // {
    //     if (!_animator.runtimeAnimatorController.Equals(GetComponent<Animator>().runtimeAnimatorController))
    //     {
    //         _animator = GetComponent<Animator>();
    //         for (var i = 0; i < _animator.layerCount; i++)
    //         {
    //             var layer = new SynchronizedLayer(i, SynchronizeType.Disabled);
    //             layers.Add(layer);
    //         }
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            Debug.Log($"{_animator.GetLayerName(i)} weight: {_animator.GetLayerWeight(i)}");
        }
    }
    
    public enum SynchronizeType
    {
        Disabled = 0,
        Discrete = 1,
        Continuous = 2,
    }
    
    [System.Serializable]
    public class SynchronizedLayer
    {
        public SynchronizeType SynchronizeType;
        public int LayerIndex;

        public SynchronizedLayer(int index, SynchronizeType type)
        {
            SynchronizeType = type;
            LayerIndex = index;
        }
    }
}
