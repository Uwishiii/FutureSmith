using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

    public Material basic;
    public GameObject particleEffect;



    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer = other.GetComponent<Renderer>(); //get renderer of obj to change the material

        if (other.CompareTag("done"))
        {
            renderer.material = basic;
            Instantiate(particleEffect, other.transform.position, Quaternion.identity);
            other.tag = "Cube";
        }
        if (other.CompareTag("flatHeated"))
        {
            renderer.material = basic;
            Instantiate(particleEffect, other.transform.position, Quaternion.identity);
            other.tag = "flat";
        }
        if (other.CompareTag("longHeated"))
        {
            renderer.material = basic;
            Instantiate(particleEffect, other.transform.position, Quaternion.identity);
            other.tag = "long";
        }
    }
}
    

    
  
