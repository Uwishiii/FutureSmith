using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCombScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 && collision.gameObject.tag != ("Cube"))
        {
            // creates joint
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            // sets joint position to point of contact
            joint.anchor = collision.contacts[0].point;
            // conects the joint to the other object
            joint.connectedBody = collision.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
            // Stops objects from continuing to collide and creating more joints
            joint.enableCollision = false;
            // Make the joint breakable
            joint.breakForce = 10;
        }
    }
}
