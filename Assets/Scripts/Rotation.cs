using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 RotationVal;
    void Update()
    {
        transform.Rotate (RotationVal.x*Time.deltaTime,RotationVal.y*Time.deltaTime,RotationVal.z*Time.deltaTime);
    }
}