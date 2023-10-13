using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    public HingeJoint leverHinge;
    public float onAngle = 45.0f; 
    public bool isOn = false;

    void Update()
    {
        float currentAngle = leverHinge.angle;

        if (currentAngle >= onAngle && !isOn)
        {
            isOn = true;
            Debug.Log("is ON");
            //remember to start the heating animation
            
        }
        else if (currentAngle < onAngle && isOn)
        {
            isOn = false;
            Debug.Log("is OFF");
            //remember to stop the heating animation


        }
    }

}
