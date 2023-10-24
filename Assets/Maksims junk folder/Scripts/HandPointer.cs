using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SphereCollider))] //Add Collider if not present

public class HandPointer : MonoBehaviour
{
    [SerializeField] InputActionReference triggerActionRefference;
    [SerializeField] SphereCollider triggerCollider;


    //Enable and Disable the Collider when the Trigger button on the controller is pressed/released.
    #region
    private void OnEnable()
    {
        triggerActionRefference.action.performed += OnActionPerformed;
        triggerActionRefference.action.canceled += OnActionCanceled;
    }

    private void OnActionPerformed(InputAction.CallbackContext context) => triggerCollider.enabled = true;

    private void OnActionCanceled(InputAction.CallbackContext context) => triggerCollider.enabled = false;

    private void OnDisable()
    {
        triggerActionRefference.action.performed -= OnActionPerformed;
        triggerActionRefference.action.canceled -= OnActionCanceled;
    }
    #endregion
}
