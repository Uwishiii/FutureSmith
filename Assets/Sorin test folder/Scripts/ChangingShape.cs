using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingShape : MonoBehaviour
{
    public Material redMaterial1;
    public Material redMaterial2;
    public Material redMaterial3;
    public Material redMaterial4;
    public Material basic;

    private int hits = 0;
    private int number = 0;
    private bool canBeHit = true;
    private float cooldownDuration = 0.5f; 
    private float cooldownTimer;

    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        cooldownTimer = cooldownDuration;
    }

    private void Update()
    {
        if (!canBeHit)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                canBeHit = true;
                cooldownTimer = cooldownDuration;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canBeHit && collision.gameObject.CompareTag("Hammer") && hits < 3 && gameObject.CompareTag("done"))
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
                cubeTransform.localScale = new Vector3(0.9f, 0.1f, 0.9f);
                gameObject.tag = "flatHeated";
            }

            hits++;
            canBeHit = false;
        }

        if (canBeHit && collision.gameObject.CompareTag("Hammer") && number < 3 && gameObject.CompareTag("flatHeated"))
        {
            Transform cubeTransform = transform;

            if (number == 0)
            {
                cubeTransform.localScale = new Vector3(1f, 0.3f, 0.5f);
            }
            else if (number == 1)
            {
                cubeTransform.localScale = new Vector3(1.3f, 0.2f, 0.2f);
            }
            else if (number == 2)
            {
                cubeTransform.localScale = new Vector3(1.7f, 0.2f, 0.2f);
                gameObject.tag = "longHeated";
            }

            number++;
            canBeHit = false;
        }
    }
}
