using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Player/Inventory")]

public class PlayerInventory : ScriptableObject
{
    [SerializeField] private FloatReference maxInventory;
    [SerializeField] private List<PickupInventoryItem> inventoryItems = new List<PickupInventoryItem>();
    [SerializeField] private GameEvent inventoryChangeEvent;

    //When disabled reset the  list.
    private void OnDisable()
    {
        inventoryItems = new List<PickupInventoryItem>();
    }
    //When Enabled reset the  list.
    private void OnEnable()
    {
        inventoryItems = new List<PickupInventoryItem>();
    }
    //Add an item to the list
    public bool addItem(PickupInventoryItem item)
    {
        if(inventoryItems.Count < maxInventory.Value)   //if inventory is not full, add item and raise itemadded event
        {
            inventoryItems.Add(item);
            inventoryChangeEvent.Raise();
            return true;
        }
        else
        {
            return false;
        }
    }
    //Return the inventory list
    public List<PickupInventoryItem> getInventoryItems()
    {
        return inventoryItems;
    }
    //Cycle through the list, move elements to the left
    public void Cycle()
    {
        if (inventoryItems.Count > 1)
        {
            PickupInventoryItem temp;
            temp = inventoryItems[0];

            for (int i = 0; i < inventoryItems.Count - 1; i++)
            {
                inventoryItems[i] = inventoryItems[i + 1];
            }

            inventoryItems[inventoryItems.Count - 1] = temp;

            inventoryChangeEvent.Raise();
        }
    }
    //Return the first item from the list and remove it
    public PickupInventoryItem TakeItem()
    {

        PickupInventoryItem firstItem = inventoryItems[0];

        inventoryItems.Remove(inventoryItems[0]);
        inventoryChangeEvent.Raise();

        return firstItem;
    }
    //Return list size
    public int GetItemCount()
    {
        return inventoryItems.Count;
    }
}
