using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHeadsetTeleportScript : MonoBehaviour
{

    [SerializeField] Vector3 playerStartPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.transform.position = playerStartPos;
            Destroy(gameObject);
        }
    }
}
