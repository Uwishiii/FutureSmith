using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftedItemData : MonoBehaviour
{
    public int c_itemID;
    public int sellPrice;

    private void Start()
    {
        switch (c_itemID)
        {
            case 1:
                sellPrice = 20;
                break;      
            case 2:         
                sellPrice = 20;
                break;      
            case 3:         
                sellPrice = 20;
                break;     
            case 4:        
                sellPrice = 20;
                break;
            case 5:    
                sellPrice = 15;
                break;
        }
    }
}
