using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//To detect collision add a collider if not present
[RequireComponent(typeof(BoxCollider))]

//Inherits from Button meaning it is the same as the Button Component
public class ButtonHandTrigger : Button
{
    //other in this case is the fingertip
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FingerTip"))
        {
            //To see the color change we have to use ExecuteEvent
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }
    }
}
