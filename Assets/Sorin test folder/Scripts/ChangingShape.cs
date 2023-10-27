using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangingShape : MonoBehaviour
{
    public Material redMaterial1;
    public Material redMaterial2;
    public Material redMaterial3;
    public Material redMaterial4;
    public Material basic;

    private int hits = 0;
    private int number = 0;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer") && hits < 4 && gameObject.CompareTag("done"))
        {
            

            Transform cubeTransform = transform;
            Renderer renderer = GetComponent<Renderer>();


            if (hits == 0)
            {
                cubeTransform.localScale = new Vector3(0.7f, 0.4f, 0.7f);
                //renderer.material = redMaterial4;
            }
            else if (hits == 1)
            {
                cubeTransform.localScale = new Vector3(0.8f, 0.3f, 0.8f);
                //renderer.material = redMaterial3;
            }
            else if (hits == 2)
            {
                cubeTransform.localScale = new Vector3(0.8f, 0.1f, 0.8f);
                //renderer.material = redMaterial2;
               
            }
            else if (hits == 3)
            {
                cubeTransform.localScale = new Vector3(0.9f, 0.1f, 0.9f);
                //renderer.material = basic;
                gameObject.tag = "flatHeated";
            }

            hits++; 
        }

        if (collision.gameObject.CompareTag("Hammer") && number < 4 && gameObject.CompareTag("flatHeated"))
        {


            Transform cubeTransform = transform;
            Renderer renderer = GetComponent<Renderer>();

            if (number == 0)
            {
                cubeTransform.localScale = new Vector3(0.9f, 0.2f, 0.7f);
                //renderer.material = redMaterial4;
            }
            else if (number == 1)
            {
                cubeTransform.localScale = new Vector3(1f, 0.3f, 0.5f);
                //renderer.material = redMaterial3;
            }
            else if (number == 2)
            {
                cubeTransform.localScale = new Vector3(1.3f, 0.2f, 0.2f);
                //renderer.material = redMaterial2;
                
            }
            else if (number == 3)
            {
                cubeTransform.localScale = new Vector3(1.5f, 0.2f, 0.2f);
                //renderer.material = basic;
                gameObject.tag = "longHeated";
            }

            number++;
        }



    }
}
