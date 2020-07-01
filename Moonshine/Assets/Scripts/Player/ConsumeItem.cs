using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeItem : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private FloatReference speedBoostAmount;
    [SerializeField] private FloatReference speedBoostTime;
    [SerializeField] private FloatReference speedReductionAmount;
    [SerializeField] private FloatReference speedReductionTime;
    [SerializeField] private FloatReference invertControlTime;

    [SerializeField] private FloatReference explosionPower;
    [SerializeField] private FloatReference explosionRadius;
    [SerializeField] private FloatReference explosionUpForce;

    private PickupInventoryItem itemToConsume;

    // Use this for initialization
    void Start () {
	
	}
    
    public void UseItem()
    {
        if (inventory.GetItemCount() > 0)
        {
            //Get the item to consume from inventory
            itemToConsume = inventory.TakeItem();

            switch (itemToConsume.name.ToUpper())
            {
                case "SPEEDBOOST": StartCoroutine(SpeedBoost());
                    break;
                case "SPEEDREDUCTION": StartCoroutine(SpeedReduction());
                    break;
                case "INVERTCONTROL": StartCoroutine(InvertControl());
                    break;
                case "BOMB": Bomb();
                    break;
            }
            print("ITEM USED");
            //increment jugs consumed
            player.jugsConsumed += 1;
        }
        else
            print("INVENTORY EMPTY");
    }
    //Speed Boost
    IEnumerator SpeedBoost()
    {
        print("MMM SPEED BOOST");
        player.SetCurrentAccelerateForce(speedBoostAmount.Value);
        yield return new WaitForSeconds(speedBoostTime.Value);
        player.ResetAccelerateForce();
    }
    //Speed Reduction
    IEnumerator SpeedReduction()
    {
        print("MMM SPEED REDUCTION");
        player.SetCurrentAccelerateForce(speedReductionAmount.Value);
        yield return new WaitForSeconds(speedReductionTime.Value);
        player.ResetAccelerateForce();
    }
    //Invert Controls
    IEnumerator InvertControl()
    {
        print("MMM INVERT CONTROL");
        player.InvertControl();
        yield return new WaitForSeconds(invertControlTime.Value);
        player.InvertControl();
    }
    //Flip
    private void Bomb()
    {
        print("MMM FLIP");
        //Store weapons current position
        Vector3 position = transform.position;
        //Get all colliders within the specified radius
        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius.Value);
        //for each collider apply the explosion force
        foreach (Collider hit in colliders)
        {
            //Get the rigidbody for the current collider
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            //If rigidbody is not null apply force
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionPower.Value, position, explosionRadius.Value, explosionUpForce.Value, ForceMode.Impulse);
            }
        }
    }
}
