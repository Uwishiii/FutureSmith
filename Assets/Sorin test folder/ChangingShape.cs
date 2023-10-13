using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingShape : MonoBehaviour
{
    private int hits = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer") && hits < 3 && gameObject.CompareTag("done"))
        {
            

            Transform cubeTransform = transform;

           
            if (hits == 0)
            {
                cubeTransform.localScale = new Vector3(0.7f, 0.4f, 0.7f);
            }
            else if (hits == 1)
            {
                cubeTransform.localScale = new Vector3(0.8f, 0.3f, 0.8f);
            }
            else if (hits == 2)
            {
                cubeTransform.localScale = new Vector3(0.8f, 0.1f, 0.8f);
                gameObject.tag = "flat";
            }

            hits++; 
        }
    }
}
