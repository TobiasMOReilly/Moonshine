using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "InventoryItem/PickUp")]

public class PickupInventoryItem : ScriptableObject
{
    [SerializeField] private string pickupName;
    [SerializeField] private Sprite icon;

    //return icon
    public Sprite getIcon()
    {
        return icon;
    }

    public string GetName()
    {
        return name;
    }
}
