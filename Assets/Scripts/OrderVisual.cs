using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class OrderVisual : MonoBehaviour
{
    [SerializeField] private Transform OrderObjPos;
    [SerializeField] private List<GameObject> OrderObjList;
    public int wantedItemID;

    void Start()
    {
        //Add delay to be able to load the list of item at the start before copying the list.
        Invoke("SpawnOrder", 1);

        //Take from the list of craftable items in CraftingBench
        var cBench = GameObject.Find("CraftingBench");
        var itemList = cBench.GetComponent<CraftingTableScript>();
        OrderObjList = itemList.craftableItems;
    }
    
    void Update()
    {

    }

    GameObject OrderSelect()
    {
        int randomNr = Random.Range(0, OrderObjList.Count);
        var selectedOrder = OrderObjList[randomNr];
        wantedItemID = randomNr + 1;
        return selectedOrder;
    }

    void SpawnOrder()
    {
        GameObject selectedOrderObj = OrderSelect();
        var itemOrderImage = Instantiate(selectedOrderObj, OrderObjPos);

        #region Configuration
        itemOrderImage.GetComponent<Rigidbody>().useGravity = false;
        itemOrderImage.GetComponent<BoxCollider>().enabled = false;
        itemOrderImage.GetComponent<XRGrabInteractable>().enabled = false;
        itemOrderImage.transform.rotation = Quaternion.Euler(0,0,90);
        itemOrderImage.transform.localScale = new Vector3(100, 100, 100);
        itemOrderImage.transform.position = OrderObjPos.position;
        itemOrderImage.AddComponent<Rotation>().RotationVal = new Vector3(50, 0, 0);
        #endregion

    }
}
