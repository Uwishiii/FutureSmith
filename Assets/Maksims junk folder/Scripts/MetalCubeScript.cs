using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.XR.CoreUtils;
using UnityEngine;

//The collider is essentual to the system bellow.
[RequireComponent(typeof(BoxCollider))]

public class MetalCubeScript : MonoBehaviour
{
    //This script handles all of the interaction the cube can have in the game.
    
    //Done states
    /// <summary>
    /// We use the booleans like a check list to see if the object was interacted with.
    /// </summary>
    bool isHeated = false;
    bool isCooled = false;
    bool isHammered = false;
    bool isSharpened = false;
    
    //State Level
    /// <summary>
    /// Levels of states such as 4 levels (0 = Default) for heated until done.
    /// </summary>
    int lvlHeated = 0;
    //int lvlCooled = 0;
    int lvlHammered = 0;
    int lvlSharpened = 0;

    //Location
    /// <summary>
    /// To see if the cube should be manipulated by outside factors. Based on collision detection.
    /// </summary>
    bool inFurnace = false;
    //bool inWater = false;
    //bool inHammering = false;
    bool inSharpening = false;

    //Craftable States
    /// <summary>
    /// Based on these variables the cube can be crafted into...
    /// </summary>
    [HideInInspector] public bool readyBlade = false;
    [HideInInspector] public bool readyShield = false;

    [SerializeField] GameObject coolParticle;

    private void Start()
    {
        //Get cube renderer
        var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();

        //Set color to default
        Color customColor0 = new Color(0.8207547f, 0.8207547f, 0.8207547f, 1.0f);
        cubeRenderer.material.color = customColor0;
    }

    //Chech with what the cube is colliding
    private void OnTriggerEnter(Collider collision)
    {
        if (!isHeated && collision.gameObject.CompareTag("Furnace"))
        {
            isCooled = false;
            inFurnace = true;
            CubeHeating();
            Debug.Log("we ball");
        }

        if (!isCooled && collision.gameObject.CompareTag("Water"))
        {
            CubeCooling();
            collision.GetComponent<AudioSource>().Play();
        }

        if (!isHammered && collision.gameObject.CompareTag("Hammer"))
        {
            Invoke("CubeHammering",0.1f);
        }

        if (!isSharpened && collision.gameObject.CompareTag("Grinder"))
        {
            inSharpening = true;
            CubeSharpening();
            collision.GetComponent<AudioSource>().Play();
        }
    }

    //Reset
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Furnace"))
        {
            inFurnace = false;
        }

        if (other.gameObject.CompareTag("Grinder"))
        {
            inSharpening = false;
            other.GetComponent<AudioSource>().Pause();
        }
    }

    //Change the color of the cube to allow hammering and cooling
    private void CubeHeating()
    {
        if (!isHeated && !isSharpened)
        {
            readyShield = false;

            //Get cube renderer
            var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();

            switch (lvlHeated)
            {
                case 1:
                    Color customColor1 = new Color(0.9811321f, 0.8376647f, 0.8376647f, 1.0f);
                    cubeRenderer.material.color = customColor1;
                    break;

                case 2:
                    Color customColor2 = new Color(0.9811321f, 0.6525454f, 0.6525454f, 1.0f);
                    cubeRenderer.material.color = customColor2;
                    break;

                case 3:
                    Color customColor3 = new Color(0.9811321f, 0.5229619f, 0.5229619f, 1.0f);
                    cubeRenderer.material.color = customColor3;
                    break;

                case 4:
                    Color customColor4 = new Color(0.9716981f, 0.3245104f, 0.3245104f, 1.0f);
                    cubeRenderer.material.color = customColor4;

                    isHeated = true;
                    break;
            }

            lvlHeated += 1;

            if (inFurnace)
            {
                Invoke("CubeHeating", 1f);
            }
        }
    }

    //Change the color of the cube to default to allow sharpening
    private void CubeCooling()
    {
        var sPart = Instantiate(coolParticle, gameObject.transform);
        Destroy(sPart, 1.5f);
        //Get cube renderer
        var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();

        //Set color to default
        Color customColor0 = new Color(0.8207547f, 0.8207547f, 0.8207547f, 1.0f);
        cubeRenderer.material.color = customColor0;

        isCooled = true;
        isHeated = false;
        lvlHeated = 0;

        if (lvlHammered == 4)
        {
            readyShield = true;
        }
    }

    //Change cube form to allow cooling and sharpening
    private void CubeHammering()
    {
        //First 4 hits make the cube flat. To make it in a shape of a blade heat up again and hit 4 more times.
        
        Transform cubeTransform = gameObject.transform.GetChild(0);
        var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();
        BoxCollider collider = GetComponent<BoxCollider>();

        Color customColor1 = new Color(0.9811321f, 0.8376647f, 0.8376647f, 1.0f);
        Color customColor2 = new Color(0.9811321f, 0.6525454f, 0.6525454f, 1.0f);
        Color customColor3 = new Color(0.9811321f, 0.5229619f, 0.5229619f, 1.0f);
        Color customColor4 = new Color(0.9716981f, 0.3245104f, 0.3245104f, 1.0f);

        if(isHeated)
        {
            lvlHammered += 1;
            switch (lvlHammered)
            {
                case 1:
                    cubeTransform.localScale = new Vector3(0.7f, 0.4f, 0.7f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor4;
                    break;
                case 2:
                    cubeTransform.localScale = new Vector3(0.8f, 0.3f, 0.8f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor3;
                    break;
                case 3:
                    cubeTransform.localScale = new Vector3(0.8f, 0.1f, 0.8f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor2;
                    break;
                case 4:
                    cubeTransform.localScale = new Vector3(0.9f, 0.1f, 0.9f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor1;

                    isHeated = false;
                    lvlHeated = 0;
                    break;
                case 5:
                    cubeTransform.localScale = new Vector3(0.9f, 0.2f, 0.7f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor4;
                    break;
                case 6:
                    cubeTransform.localScale = new Vector3(1f, 0.3f, 0.5f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor3;
                    break;
                case 7:
                    cubeTransform.localScale = new Vector3(1.3f, 0.2f, 0.2f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor2;
                    break;
                case 8:
                    cubeTransform.localScale = new Vector3(1.5f, 0.2f, 0.2f);
                    collider.size = cubeTransform.localScale;
                    cubeRenderer.material.color = customColor1;
                    isHeated = false;
                    break;
            }
        }
    }

    //Change cube form to allow sword building
    private void CubeSharpening()
    {
        Transform cubeTransform = gameObject.transform.GetChild(0);
        BoxCollider collider = GetComponent<BoxCollider>();
        if (lvlHammered >= 8 && isCooled)
        {
            switch (lvlSharpened)
            {
                case 1:
                    cubeTransform.localScale = new Vector3(1.5f, 0.1f, 0.2f);
                    collider.size = cubeTransform.localScale;
                    isSharpened = true;
                    break;
                case 2:
                    cubeTransform.localScale = new Vector3(1.5f, 0.05f, 0.1f);
                    collider.size = cubeTransform.localScale;
                    readyBlade = true;
                    break;
            }

            lvlSharpened += 1;

            if (inSharpening)
            {
                Invoke("CubeSharpening",1);
            }
        }
    }

}
