using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Player player;

    public Player GetPlayer()
    {
        return player;
    }
    public PlayerInventory GetPlayerInventory()
    {
        return inventory;
    }
}
