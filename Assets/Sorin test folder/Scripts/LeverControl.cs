using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    public HingeJoint leverHinge;
    public float onAngle = 45.0f; 
    public bool isOn = false;
    public GameObject targetObjectON;
    public GameObject targetObjectOFF;
    public GameObject TargetFire;
    public GameObject TargetSmoke;
    

    void Start()
    {
        targetObjectON.SetActive(false);
        targetObjectOFF.SetActive(true);
        TargetFire.SetActive(false);
        TargetSmoke.SetActive(false);
    }


    void Update()
    {
        float currentAngle = leverHinge.angle;

        if (currentAngle >= onAngle && !isOn)
        {
            isOn = true;
            Debug.Log("is ON");
            targetObjectON.SetActive(true);
            targetObjectOFF.SetActive(false);
            //remember to start the heating animation

            TargetFire.SetActive(true);
            TargetSmoke.SetActive(false);
        }

        
        else if (currentAngle < onAngle && isOn)
        {
            isOn = false;
            Debug.Log("is OFF");
            targetObjectON.SetActive(false);
            targetObjectOFF.SetActive(true);
            //remember to stop the heating animation

            TargetFire.SetActive(false);
            TargetSmoke.SetActive(true);
        }

    }

}
