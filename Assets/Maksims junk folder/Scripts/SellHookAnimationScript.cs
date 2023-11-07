using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SellHookAnimationScript : MonoBehaviour
{
    [SerializeField] Animator myAnimator;
    [SerializeField] private Transform SellPosition;
    [SerializeField] private ButtonVR currentMoney;
    [SerializeField] private OrderVisual order;

    private GameObject objectInZone;

    private float dissolve = 1f;

    void Start()
    {
        myAnimator.SetTrigger("Idle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CraftedItemData>() != null)
        {
            objectInZone = other.gameObject;
            var itemID= other.GetComponent<CraftedItemData>().c_itemID;
            var wantedItemID = other.GetComponent<CraftedItemData>().c_wantedItemID;
            var sellPrice = other.GetComponent<CraftedItemData>().sellPrice;
            if (wantedItemID == itemID)
            {
                myAnimator.SetTrigger("ItemInZone");

                currentMoney.AddBalToMoney(sellPrice);
                //Destroy(other.GetComponent<CraftedItemData>());
                Destroy(other.GetComponent<XRGrabInteractable>());
                Destroy(other.GetComponent<Rigidbody>());

                foreach (Collider item in other.GetComponents<Collider>())
                {
                    item.enabled = false;
                }
                other.transform.rotation = Quaternion.Euler(0, 0, -90);
                other.transform.position = SellPosition.position;

                Invoke("ResetAnimation", 1);
            }
        }
    }

    private void Update()
    {
        if(objectInZone != null)
        {
            Renderer[] ren = objectInZone.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in ren)
            {
                var m = r.materials;
                foreach (Material mat in m)
                {
                    var fadeInVal = mat.GetFloat("_FadeIn");
                    dissolve = fadeInVal;

                    if (fadeInVal <= -0.1f)
                    {
                        Destroy(objectInZone.gameObject, 0.1f);
                        Destroy(order.itemOrderImage.gameObject);
                        order.Invoke("SpawnOrder", 0.1f);
                    }
                    else
                    {
                        dissolve -= 0.001f;
                        mat.SetFloat("_FadeIn", dissolve);
                    }
                }
            }
        }
        
    }

    void ResetAnimation()
    {
        myAnimator.SetTrigger("Idle");
    }
}
