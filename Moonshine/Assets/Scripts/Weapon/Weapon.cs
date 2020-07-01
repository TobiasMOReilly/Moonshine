using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private FloatReference speedBoostAmount;
    [SerializeField] private FloatReference speedBoostTime;
    [SerializeField] private FloatReference speedReductionAmount;
    [SerializeField] private FloatReference speedReductionTime;
    [SerializeField] private FloatReference invertControlTime;
    [SerializeField] private FloatReference explosionPower;
    [SerializeField] private FloatReference explosionRadius;
    [SerializeField] private FloatReference explosionUpForce;
    [SerializeField] private AudioSource audioSource;

    private PickupInventoryItem weaponType;

    //Set the weapon type
    public void SetWeaponType(PickupInventoryItem item)
    {
        print("I AM A " + item.name);
        weaponType = item;
    }

    //On hitting a collider do something.....
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameObject p = other.gameObject;

            print("Hit Player");
            //Switch on weapon type
            switch(weaponType.name.ToUpper())
            {
                case "SPEEDBOOST": StartCoroutine(SpeedBoost(p));
                    break;
                case "SPEEDREDUCTION": StartCoroutine(SpeedReduction(p));
                    break;
                case "INVERTCONTROLS": StartCoroutine(InvertControl(p));
                    break;
                case "BOMB": Bomb();
                    break;
            }

        }
        else
        {
            print("Missed");
        }
        StartCoroutine(PlayDestroy());
    }
    //Play audio clip, then destroy object
    IEnumerator PlayDestroy()
    {
        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(this.gameObject);
    }
    //Speed Boost
    IEnumerator SpeedBoost(GameObject p)
    {
        print("SPEED BOOST");
        p.GetComponent<PlayerState>().GetPlayer().SetCurrentAccelerateForce(speedBoostAmount.Value);
        yield return new WaitForSeconds(speedBoostTime.Value);
        p.GetComponent<PlayerState>().GetPlayer().ResetAccelerateForce();
    }
    //Speed Reduction
    IEnumerator SpeedReduction(GameObject p)
    {
        print("SPEED REDUCTION");
        p.GetComponent<PlayerState>().GetPlayer().SetCurrentAccelerateForce(-speedReductionAmount.Value);
        yield return new WaitForSeconds(speedReductionTime.Value);
        p.GetComponent<PlayerState>().GetPlayer().ResetAccelerateForce();
    }
    //Invert Controls
    IEnumerator InvertControl(GameObject p)
    {
        print("INVERT CONTROL");
        p.GetComponent<PlayerState>().GetPlayer().InvertControl();
        yield return new WaitForSeconds(invertControlTime.Value);
        p.GetComponent<PlayerState>().GetPlayer().InvertControl();
    }
    //Flip
    private void Bomb()
    {
        print("FLIP");
        //Store weapons current position
        Vector3 position = transform.position;
        //Get all colliders within the specified radius
        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius.Value);
        //for each collider apply the explosion force
        foreach(Collider hit in colliders)
        {
            //Get the rigidbody for the current collider
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            //If rigidbody is not null apply force
            if(rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionPower.Value, position, explosionRadius.Value, explosionUpForce.Value, ForceMode.Impulse);
            }
        }
    }
}
