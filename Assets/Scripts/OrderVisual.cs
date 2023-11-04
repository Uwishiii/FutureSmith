using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderVisual : MonoBehaviour
{
    [SerializeField] private Transform OrderObjPos;
    [SerializeField] private List<GameObject> OrderObjList;
    
    void Start()
    {
        GameObject selectedOrderObj = OrderSelect();
        Instantiate(selectedOrderObj, OrderObjPos);
    }
    
    void Update()
    {

    }

    GameObject OrderSelect()
    {
        int randomNr = Random.Range(0, OrderObjList.Count);
        var selectedOrder = OrderObjList[randomNr];
        return selectedOrder;
    }
}
