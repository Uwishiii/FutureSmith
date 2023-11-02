using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHeadsetTeleportScript : MonoBehaviour
{

    [SerializeField] GameObject playerSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.transform.position = playerSpawnPoint.transform.position;
            Destroy(gameObject);
        }
    }
}
