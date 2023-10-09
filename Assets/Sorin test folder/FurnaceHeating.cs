using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FurnaceHeating : MonoBehaviour
{
    public Material redMaterial1;
    public Material redMaterial2;
    public Material redMaterial3;
    public Material redMaterial4;

    private bool isChangingMaterial = false;
    private bool isObjectInsideZone = false; //track if obj is inside collider zone
    private int currentMaterialIndex = 0; //current material

    private bool objectIsDone = false;

    private Renderer currentObjectRenderer; // Store the current object's renderer.


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") || other.CompareTag("Sphere"))
        {

            Renderer renderer = other.GetComponent<Renderer>(); //get renderer of obj to change the material
            if (renderer != null && !isChangingMaterial)
            {

                currentObjectRenderer = renderer; //store the obj renderer
                isObjectInsideZone = true;
                StartCoroutine(ChangeMaterialAfterDelay(renderer)); //start coroutine
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Cube") || other.CompareTag("Sphere"))
        {
            if (objectIsDone)
            {
            other.tag = "done";
            }
            if (currentObjectRenderer != null && currentObjectRenderer.gameObject == other.gameObject) //check if the obj that exits the collider is the same as teh one in the coroutine 
            {
                isObjectInsideZone = false; //stop the couroutine
            }
        }
    }

    private IEnumerator ChangeMaterialAfterDelay(Renderer renderer)
    {
        isChangingMaterial = true;

        for (int i = currentMaterialIndex; i <= 4; i++)
        {

            if (!isObjectInsideZone) //check if obj is still inside before changing material
            {
                isChangingMaterial = false;
                yield break; //exit the coroutine.
            }


            switch (i) //go to next material
            {
                case 0:
                    renderer.material = redMaterial1;
                    break;
                case 1:
                    renderer.material = redMaterial2;
                    break;
                case 2:
                    renderer.material = redMaterial3;
                    break;
                case 3:
                    renderer.material = redMaterial4;
                    break;
                case 4:
                    renderer.material = redMaterial4;
                    objectIsDone = true;
                    break;

            }


            currentMaterialIndex = i + 1;

            yield return new WaitForSeconds(2.0f);//wait 2sec
        }


        currentMaterialIndex = 0; //start from beginning for next obj
        isChangingMaterial = false;
    }
}
