using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHeadsetTeleportScript : MonoBehaviour
{

    [SerializeField] Vector3 playerStartPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.transform.position = playerStartPos;
        }
    }
}
