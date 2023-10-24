using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderRobotAnimationScript : MonoBehaviour
{
    [SerializeField] Animator myAnimator;

    void Start()
    {
        myAnimator.SetTrigger("Retrack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            myAnimator.SetTrigger("Deploy");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        myAnimator.SetTrigger("Retrack");
    }
}
