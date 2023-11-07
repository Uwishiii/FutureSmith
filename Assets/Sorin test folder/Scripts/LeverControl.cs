using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    public HingeJoint leverHinge;
    public float onAngle = 40.0f; 
    public bool isOn = false;
    public GameObject targetObjectON;
    public GameObject targetObjectOFF;
    public GameObject TargetFire;
    public GameObject TargetSmoke;
    [SerializeField] Collider furnaceCollider;

    [SerializeField] AudioSource audio;
    

    void Start()
    {
        targetObjectON.SetActive(false);
        targetObjectOFF.SetActive(true);
        TargetFire.SetActive(false);
        TargetSmoke.SetActive(false);
        furnaceCollider.enabled = false;
        audio.Play();
        audio.Pause();
    }


    void Update()
    {
        float currentAngle = leverHinge.angle;

        if (currentAngle >= onAngle && !isOn)
        {
            isOn = true;
            //Debug.Log("is ON");
            targetObjectON.SetActive(true);
            targetObjectOFF.SetActive(false);
            //remember to start the heating animation

            TargetFire.SetActive(true);
            TargetSmoke.SetActive(false);
            furnaceCollider.enabled = true;
            audio.UnPause();
        }

        
        else if (currentAngle < onAngle && isOn)
        {
            isOn = false;
            //Debug.Log("is OFF");
            targetObjectON.SetActive(false);
            targetObjectOFF.SetActive(true);
            //remember to stop the heating animation

            TargetFire.SetActive(false);
            TargetSmoke.SetActive(true);
            furnaceCollider.enabled = false;
            audio.Pause();
        }

    }

}
