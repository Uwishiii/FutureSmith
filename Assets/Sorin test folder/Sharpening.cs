using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharpening : MonoBehaviour
{
    private float timer = 0f;
    private bool isInSharpeningZone = false;

    private void Update()
    {
        if (isInSharpeningZone && gameObject.CompareTag("flat"))
        {
            timer += Time.deltaTime;
            if (timer >= 1f) // Perform an action every second (1 second)
            {
                // Add your shape-changing action here
                Debug.Log("works every 1sec");
                timer = 0f; // Reset the timer
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sharpening"))
        {
            isInSharpeningZone = true;
            timer = 0f;
            Debug.Log("entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sharpening"))
        {
            isInSharpeningZone = false;
            Debug.Log("left");
        }
    }
}
