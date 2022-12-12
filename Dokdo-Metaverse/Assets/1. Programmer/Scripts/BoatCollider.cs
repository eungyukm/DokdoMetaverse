using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollider : MonoBehaviour
{
    private Transform player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            player.SetParent(transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (player)
        {
            player.SetParent(null);
            DontDestroyOnLoad(player);
        }
    }
}
