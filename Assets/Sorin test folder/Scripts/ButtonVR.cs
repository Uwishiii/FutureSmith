using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonVR : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private GameObject woodPrefab;

    [SerializeField]
    private GameObject handlePrefab;

    [SerializeField]
    private GameObject guardPrefab;

    [SerializeField]
    private GameObject button;

    public UnityEvent onPress;
    public UnityEvent onRelease;

    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;

    private static int money = 50;

    [SerializeField] TMP_Text moneyDisplay;


    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            //sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnCube()
    {
        if (money >= 5)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, new Vector3(-0.3f, 1f, -0.6f), Quaternion.Euler(0, 90.0f, 0));
            money -= 5;
        }
    }

    public void SpawnWood()
    {
        if (money >= 5)
        {
            GameObject spawnedWood = Instantiate(woodPrefab, new Vector3(-0.3f, 1f, -0.6f), Quaternion.Euler(0, 90.0f, 0));
            money -= 5;
        }
    }

    public void SpawnHandle()
    {
        if (money >= 5)
        {
            GameObject spawnedHandle = Instantiate(handlePrefab, new Vector3(-0.3f, 1f, -0.6f), Quaternion.Euler(0, 90.0f, 0));
            money -= 5;
        }
    }

    public void SpawnGuard()
    {
        if (money >= 5)
        {
            GameObject spawnedGuard = Instantiate(guardPrefab, new Vector3(-0.3f, 1f, -0.6f), Quaternion.Euler(0, 90.0f, 0));
            money -= 5;
        }
    }

    private void Update()
    {
        moneyDisplay.text = "$: " + money;
    }
}
