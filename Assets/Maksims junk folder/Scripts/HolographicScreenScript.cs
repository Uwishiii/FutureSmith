using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolographicScreenScript : MonoBehaviour
{
    //This script handles the ripple effect for the HologramScreen Shader

    [SerializeField] private float rippleCooldown = 0.4f;

    private Material material;
    private float rippleTime = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        rippleTime += Time.deltaTime;
        material.SetFloat("_Ripple_Time", rippleTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        Vector3 loc_vec = transform.InverseTransformPoint(contact.point);


        //Math moment z.z.z.
        var old_x = loc_vec.x;
        var old_y = loc_vec.y;
        var old_z = loc_vec.z;

        var old_x_min = 5;
        var old_y_min = 5;
        var old_z_min = 5;

        var old_x_max = -5;
        var old_y_max = -5;
        var old_z_max = -5;

        var new_x_min = 0;
        var new_y_min = 0;
        var new_z_min = 0;

        var new_x_max = 1;
        var new_y_max = 1;
        var new_z_max = 1;

        var new_x = ((old_x - (old_x_min)) / (old_x_max - (old_x_min))) * (new_x_max - new_x_min) + new_x_min;
        var new_y = ((old_y - (old_y_min)) / (old_y_max - (old_y_min))) * (new_y_max - new_y_min) + new_y_min;
        var new_z = ((old_z - (old_z_min)) / (old_z_max - (old_z_min))) * (new_z_max - new_z_min) + new_z_min;

        //Debug.Log("Old X Local Contact = " + old_x);
        //Debug.Log("New X Local Contact = " + new_x);

        if (rippleTime < rippleCooldown)
        {
            return;
        }
        material.SetVector("_Ripple_Origin", new Vector4(new_x, new_z, new_y, 0));
        rippleTime = material.GetFloat("_Ripple_Thickness") * -2.0f;

    }
}
