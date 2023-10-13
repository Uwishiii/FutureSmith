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
    private bool flatCheck = false; 

    private bool objectIsDone = false;

    private Renderer currentObjectRenderer; //store the object renderer.
    private Collider currentObjectCollider;


    public LeverControl leverControl;


    private void OnTriggerStay(Collider other)
    {
        if (objectIsDone)
        {
            other.tag = "done";
        }

        if (!other.CompareTag("done"))
        {
            if (other.CompareTag("Cube") || other.CompareTag("Sphere") || other.CompareTag("flat"))
            {
                if (other.CompareTag("flat"))
                {
                    flatCheck = true;
                }

                Renderer renderer = other.GetComponent<Renderer>(); //get renderer of obj to change the material
                if (renderer != null && !isChangingMaterial && leverControl.isOn)
                {

                    currentObjectRenderer = renderer; //store the obj renderer
                    currentObjectCollider = other;
                    isObjectInsideZone = true;
                    StartCoroutine(ChangeMaterialAfterDelay(renderer)); //start coroutine
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Cube") || other.CompareTag("Sphere"))
        {
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
            if(!leverControl.isOn)
            {
                isChangingMaterial = false;
                yield break;
            }

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
                    if (flatCheck)
                    {
                        currentObjectCollider.tag = "flatHeated";
                    }
                    else
                    {
                        currentObjectCollider.tag = "done";
                    }
                    break;
            }


            currentMaterialIndex = i + 1;

            flatCheck = false;
            yield return new WaitForSeconds(2.0f);//wait 2sec
        }


        currentMaterialIndex = 0; //start from beginning for next obj
        isChangingMaterial = false;
    }
}
