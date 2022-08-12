using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTrigger : MonoBehaviour
{
    public SheepScript sheep;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sheep.isScared = true;
        }
    }
}
