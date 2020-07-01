using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventoryIcons : MonoBehaviour {

    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private List<Image> items;
    [SerializeField] private Sprite defaultImage;
	//Update the Ui to display current pickups in inventory
    public void UpdateUI()
    {
        List<PickupInventoryItem> list = inventory.getInventoryItems();

        for (int i=0; i< list.Count; i++)
        {
            items[i].sprite = list[i].getIcon();
            items[i].GetComponentInChildren<TextMeshProUGUI>().text = list[i].GetName();
        }
    }

    //Reset images
    public void ResetImages()
    {
        for(int i = 0; i < items.Count; i++)
        {
            items[i].sprite = defaultImage;
            items[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        UpdateUI();
    }
}
