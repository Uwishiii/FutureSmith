using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CraftingTableScript : MonoBehaviour
{
    //Attach to the table used to make weapons.
    /// <summary>
    /// This script is used to check what kind of parts are on the table and see if they meet the ones used in the recipe for the selected weapon.
    /// Table has 3 attach points.
    /// Each representing weapon part. In case of the shield only 2 are active.
    /// From left to right the attachpoints are for: metal cube - metal cylinder - wooden cylinder
    /// After the parts are plased a hammer hit will be needed to complete the craft.
    /// In case the user messes up - we destroy the parts and wait for new ones. Same if the user changes the recipe midway.
    /// </summary>

    [Header("Parts")]
    [SerializeField] bool partTypeBlade = false;
    [SerializeField] bool partTypeShield = false;
    [SerializeField] bool partTypeGuard = false;
    [SerializeField] bool partTypeHandle = false;

    [Header("SnapPoints/Holograms")]
    [SerializeField] GameObject spBlade;
    [SerializeField] GameObject spShield;
    [SerializeField] GameObject spGuard;
    [SerializeField] GameObject spHandle;

    [Header("Item Spawn Point")]
    [SerializeField] GameObject itemSpawnPoint;

    [Header("List with Items")]
    public List<GameObject> craftableItems;
    /// <summary>
    /// Since the list is being populated by the prefabs in folder Resources/Items the prefab names will have to abide by alphabetical or numerical ascending order to make sure the correct thing is spawned.
    /// </summary>

    List<GameObject> partsOnTable = new List<GameObject>();

    //Swords, shields ect. all have a unique itemID
    int itemID = 0;
    public int craftedItemID = 0;
    public int craftedItemPrice = 0;
    /// <summary>
    /// ID - item
    /// 1 - Sword
    /// 2 - Sword
    /// 3 - Sword
    /// 4 - Shield
    /// </summary>
    /// 

    private void Start()
    {
        LoadDefaults();

        //Load all items from folder Resources/Items
        craftableItems = new List<GameObject>(Resources.LoadAll<GameObject>("Items"));


    }

    private void OnTriggerEnter(Collider collision)
    {
        //Only execute if the objects are with layer interactable to prevent unnecessary checks.
        if (collision.gameObject.layer == 9)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Collider col = collision.gameObject.GetComponent<Collider>();
            XRGrabInteractable xRGrabInteractable = collision.gameObject.GetComponent<XRGrabInteractable>();

            //Get the check variables from the cube to see what kind of part it is
            MetalCubeScript getWeaponBooleans = collision.gameObject.GetComponent<MetalCubeScript>();
            if(getWeaponBooleans != null)
            {
                partTypeBlade = getWeaponBooleans.readyBlade;
                partTypeShield = getWeaponBooleans.readyShield;
            }

            if (partTypeBlade || partTypeShield)
            {
                if (spBlade.activeSelf || spShield.activeSelf)
                {
                    Destroy(xRGrabInteractable);
                    Destroy(rb);
                    col.enabled = false;
                    collision.transform.position = spBlade.transform.position;
                    partsOnTable.Add(collision.gameObject);
                }
            }

            if (collision.gameObject.CompareTag("Guard"))
            {
                if (spGuard.activeSelf)
                {
                    partTypeGuard = true;
                    Destroy(xRGrabInteractable);
                    Destroy(rb);
                    col.enabled = false;
                    collision.transform.position = spGuard.transform.position;
                    partsOnTable.Add(collision.gameObject);
                }
            }

            if (collision.gameObject.CompareTag("Handle"))
            {
                if (spHandle.activeSelf)
                {
                    partTypeHandle = true;
                    Destroy(xRGrabInteractable);
                    Destroy(rb);
                    col.enabled = false;
                    collision.transform.position = spHandle.transform.position;
                    partsOnTable.Add(collision.gameObject);
                }
            }
        }

        //Check for hammer and available parts to craft item
        if (collision.gameObject.CompareTag("Hammer"))
        {
            switch (itemID)
            {
                case 1:
                    //Sword
                    if(partTypeBlade && partTypeGuard && partTypeHandle)
                    {
                        var item = Instantiate(craftableItems[0], itemSpawnPoint.transform.position, Quaternion.identity);
                        item.AddComponent<CraftedItemData>().c_itemID = itemID;
                        ClearItemsOnTable();
                        LoadDefaults();
                    }
                    break;
                case 2:
                    //Sword
                    if (partTypeBlade && partTypeGuard && partTypeHandle)
                    {
                        var item = Instantiate(craftableItems[1], itemSpawnPoint.transform.position, Quaternion.identity);
                        item.AddComponent<CraftedItemData>().c_itemID = itemID;
                        ClearItemsOnTable();
                        LoadDefaults();
                    }
                    break;
                case 3:
                    //Sword
                    if (partTypeBlade && partTypeGuard && partTypeHandle)
                    {
                        var item = Instantiate(craftableItems[2], itemSpawnPoint.transform.position, Quaternion.identity);
                        item.AddComponent<CraftedItemData>().c_itemID = itemID;
                        ClearItemsOnTable();
                        LoadDefaults();
                    }
                    break;
                case 4:
                    //Sword
                    if (partTypeShield && partTypeHandle)
                    {
                        var item = Instantiate(craftableItems[3], itemSpawnPoint.transform.position, Quaternion.identity);
                        item.AddComponent<CraftedItemData>().c_itemID = itemID;
                        ClearItemsOnTable();
                        LoadDefaults();
                    }
                    break;
                case 5:
                    //Shield
                    if (partTypeShield && partTypeHandle)
                    {
                        var item = Instantiate(craftableItems[4], itemSpawnPoint.transform.position, Quaternion.identity);
                        item.AddComponent<CraftedItemData>().c_itemID = itemID;
                        ClearItemsOnTable();
                        LoadDefaults();
                    }
                    break;
            }
        }
    }

    private void Update()
    {
        switch (itemID)
        {
            case 1:
                //Sword
                spBlade.SetActive(true);
                spGuard.SetActive(true);
                spHandle.SetActive(true);
                spShield.SetActive(false);
                break;
            case 2:
                //Sword
                spBlade.SetActive(true);
                spGuard.SetActive(true);
                spHandle.SetActive(true);
                spShield.SetActive(false);
                break;
            case 3:
                //Sword
                spBlade.SetActive(true);
                spGuard.SetActive(true);
                spHandle.SetActive(true);
                spShield.SetActive(false);
                break; 
            case 4:
                //Sword
                spBlade.SetActive(true);
                spGuard.SetActive(true);
                spHandle.SetActive(true);
                spShield.SetActive(false);
                break;
            case 5:
                //Shield
                spBlade.SetActive(false);
                spGuard.SetActive(false);
                spHandle.SetActive(true);
                spShield.SetActive(true);
                break;
        }
    }

    void LoadDefaults()
    {
        spBlade.SetActive(false);
        spGuard.SetActive(false);
        spHandle.SetActive(false);
        spShield.SetActive(false);

        partTypeBlade = false;
        partTypeShield = false;
        partTypeGuard = false;
        partTypeHandle = false;

        itemID = 0;
        craftedItemID = 0;
        craftedItemPrice = 0;
}

    public void ClearItemsOnTable()
    {
        foreach(GameObject x in partsOnTable)
        {
            Destroy(x);
        }
    }

    public void SetItemIDto1() { itemID = 1; }
    public void SetItemIDto2() { itemID = 2; }
    public void SetItemIDto3() { itemID = 3; }
    public void SetItemIDto4() { itemID = 4; }
    public void SetItemIDto5() { itemID = 5; }
}
