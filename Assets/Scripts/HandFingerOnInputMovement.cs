using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandFingerOnInputMovement : MonoBehaviour
{
    //Script that controlls the hand fingers when controller buttons are pressed.

    [SerializeField] InputActionProperty pinchAnimationAction;
    [SerializeField] InputActionProperty gripAnimationAction;
    [SerializeField] Animator handAnimator;

    // Update is called once per frame
    void Update()
    {
        //Check for controller inputs => Update values => Play animation

        //Index/Thumb pinch
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        //Grip/Fist
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
