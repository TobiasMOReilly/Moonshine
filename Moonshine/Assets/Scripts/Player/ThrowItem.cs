using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{

    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Player player;
    [SerializeField] private FloatReference throwWaitTime;
    [SerializeField] private FloatReference throwForceX;
    [SerializeField] private FloatReference throwForceY;
    //[SerializeField] private FloatReference throwForce;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private GameObject leftWeaponSpawn;
    [SerializeField] private GameObject rightWeaponSpawn;

    private PickupInventoryItem itemToThrow;
    private bool canThrow;
    private float throwForce;
    private Vector3 throwDirection;

    // Use this for initialization
    void Start()
    {
        canThrow = true;
    }

    //Throw the first item in the inventory to the left
    public void ThrowItemLeft()
    {
        if (canThrow && inventory.GetItemCount() > 0)
        {
            //print("CHUCKED LEFT");
            StartCoroutine("ThrowTimer");
            itemToThrow = inventory.TakeItem();

            GameObject currentWeapon = Instantiate(weaponPrefab, leftWeaponSpawn.transform.position, Quaternion.identity);              //Instatiate a weapon pefab
            currentWeapon.GetComponent<Weapon>().SetWeaponType(itemToThrow);                                                            //Set the weapon prefab type
            //currentWeapon.GetComponent<Rigidbody>().AddForce(new Vector3(-throwForceX.Value,throwForceY.Value,0), ForceMode.Impulse); //Apply force to the prefab - to the left
            currentWeapon.GetComponent<Rigidbody>().AddForce(CalculateDirectionLeft(), ForceMode.Impulse);
            //increment jugs thrown
            player.jugsThrown += 1;
        }
    }
    //Throw the first item in the inventory to the right
    public void ThrowItemRight()
    {
        if (canThrow && inventory.GetItemCount() > 0)
        {
            //print("CHUCKED RIGHT");
            StartCoroutine("ThrowTimer");
            itemToThrow = inventory.TakeItem();

            GameObject currentWeapon = Instantiate(weaponPrefab, rightWeaponSpawn.transform.position, Quaternion.identity);             //Instatiate a weapon pefab
            currentWeapon.GetComponent<Weapon>().SetWeaponType(itemToThrow);                                                            //Set the weapon prefab type
            //currentWeapon.GetComponent<Rigidbody>().AddForce(new Vector3(throwForceX.Value, throwForceY.Value, 0), ForceMode.Impulse);  //Apply force to the prefab - to the right
            currentWeapon.GetComponent<Rigidbody>().AddForce(CalculateDirectionRight(), ForceMode.Impulse);
            //increment jugs thrown
            player.jugsThrown += 1;
        }
    }

    //Timer to prevent constant throwing
    private IEnumerator ThrowTimer()
    {
        canThrow = false;
        yield return new WaitForSeconds(throwWaitTime.Value);
        canThrow = true;
    }
    //Calculate throwForce
    private float calculateThrowForce()
    {
        float throwForce = player.GetThrowForce() * throwForceX.Value;
        //print("Throw Force: " + throwForce);
        return throwForce;
    }
    //Calculate Direction left
    private Vector3 CalculateDirectionLeft()
    {
        Vector3 direction = (-leftWeaponSpawn.transform.right * calculateThrowForce()) + new Vector3(0, throwForceY.Value, 0);
        return direction;
    }
    //Calculate Direction right
    private Vector3 CalculateDirectionRight()
    {
        Vector3 direction = (rightWeaponSpawn.transform.right * calculateThrowForce()) + new Vector3(0, throwForceY.Value,0);
        return direction;
    }
}
