using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject combinedObjectPrefab; 
    public GameObject particleEffect; 

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("wood") && other.CompareTag("flat"))
        {
            Debug.Log("entered");
            Vector3 collisionPoint = transform.position;

            Destroy(other.gameObject);
            Destroy(gameObject);

            Instantiate(combinedObjectPrefab, collisionPoint, Quaternion.identity);
            Instantiate(particleEffect, collisionPoint, Quaternion.identity);
        }
    }
}
