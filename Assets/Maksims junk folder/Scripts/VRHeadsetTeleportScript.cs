using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRHeadsetTeleportScript : MonoBehaviour
{

    [SerializeField] GameObject playerSpawnPoint;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject roboHandLeft;
    [SerializeField] GameObject roboHandRight;
    [SerializeField] GameObject roboHandMenu;

    [SerializeField] GameObject humHandLeft;
    [SerializeField] GameObject humHandRight;

    private XRGrabInteractable grab;

    private void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.transform.position = playerSpawnPoint.transform.position;

            grab.enabled = false;

            timer.SetActive(true);
            roboHandLeft.SetActive(true);
            roboHandRight.SetActive(true);
            roboHandMenu.SetActive(true);

            humHandLeft.SetActive(false);
            humHandRight.SetActive(false);

            gameObject.transform.position = new Vector3(-8.777034f, 1.36f, -3.817631f);
            gameObject.transform.rotation = Quaternion.Euler(0, -159.886f, 0);
        }
    }
}
