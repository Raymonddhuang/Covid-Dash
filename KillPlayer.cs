using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform point;

    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.CompareTag("Player"))
        {
            player.transform.position = point.transform.position;
            Physics.SyncTransforms();
        }
    }
}