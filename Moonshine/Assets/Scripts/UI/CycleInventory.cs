using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CycleInventory : MonoBehaviour {

    [SerializeField] private PlayerInventory inventory;

    //Cycle through the current items in the inventory
    public void Cycle()
    {
       inventory.Cycle();
    }
    
}

