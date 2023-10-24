using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnappointScript : MonoBehaviour
{
    bool snapped = false;

    //MAKE SURE TO DISSABLE CONTINUOUS SNAPPING
    //if left to snap it leads to twitching

    private void OnTriggerEnter(Collider other)
    {
        if (!snapped)
        {
            Snapped(other);
        }
    }
    void Snapped(Collider snappingObj)
    {
        gameObject.transform.parent.position = snappingObj.transform.position + (gameObject.transform.parent.position - gameObject.transform.position);
        snapped = true;
    }
}
